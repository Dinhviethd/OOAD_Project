using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OOAD.Service;

namespace OOAD.View
{
    public partial class Schedule: Form
    {
        User user;
        AppoinmentService appoint;
        GroupMeetingService groupmeet;
        UserService users;
        DateTime start_time,end_time;
        public Schedule()
        {
            user = Login.user;
            InitializeComponent(); 
            var db = new Model1();
            appoint = new AppoinmentService(db);
            groupmeet = new GroupMeetingService(db);
            users = new UserService(db);
            start_time = new DateTime(UserControlCalendar.static_year, UserControlCalendar.static_month, Convert.ToInt32(UserControlDay.static_day), 0, 0, 0);
            end_time = new DateTime(UserControlCalendar.static_year, UserControlCalendar.static_month, Convert.ToInt32(UserControlDay.static_day), 0, 0, 0);
        }
        private void ok_Click(object sender, EventArgs e)
        {
            TimeSpan temp = dateTimePicker1.Value.TimeOfDay;
            TimeSpan temp2 = dateTimePicker2.Value.TimeOfDay;
            start_time = new DateTime(start_time.Year, start_time.Month, start_time.Day, 0, 0, 0);
            end_time = new DateTime(end_time.Year, end_time.Month, end_time.Day, 0, 0, 0);
            start_time = start_time + temp;
            end_time = end_time + temp2;

            if (end_time < start_time)
            {
                MessageBox.Show("Thời gian kết thúc phải sau thời gian bắt đầu.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(title1.Text) || string.IsNullOrWhiteSpace(location1.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var allAppointments = appoint.GetAppointmentsByUser(user.ID_User);
            foreach (var appt in allAppointments)
            {
                bool timeConflict = !(end_time <= appt.StartTime || start_time >= appt.EndTime);
                if (timeConflict)
                {
                    ScheduleConflict conflictForm = new ScheduleConflict(appoint, appt, title1.Text, location1.Text, start_time, end_time);
                    var result = conflictForm.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                        return;
                    }
                }
            }
            
            var allGroupMeetings = groupmeet.GetAllGroups();
            foreach (var meeting in allGroupMeetings)
            {
                if (meeting.Participants.Any(p => p.ID_User == user.ID_User))
                {
                    continue;
                }
                DateTime meetingStart = new DateTime(meeting.StartTime.Year, meeting.StartTime.Month, meeting.StartTime.Day,
                                                     meeting.StartTime.Hour, meeting.StartTime.Minute, 0);
                DateTime appointmentStart = new DateTime(start_time.Year, start_time.Month, start_time.Day,
                                                         start_time.Hour, start_time.Minute, 0);

                bool sameStartMinute = meetingStart == appointmentStart;

                TimeSpan durationMeeting = meeting.EndTime - meeting.StartTime;
                TimeSpan durationAppointment = end_time - start_time;
                double diffSeconds = Math.Abs((durationMeeting - durationAppointment).TotalSeconds);
                bool durationCloseEnough = diffSeconds <= 60;

                if (sameStartMinute && durationCloseEnough)
                {
                    MeetingConflict conflictForm = new MeetingConflict(meeting, user, groupmeet);
                    var result = conflictForm.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                        return;
                    }
                    else
                    {
                        return;
                    }
                }
            }
            if (groupmeeting.Checked)
            {
                var trackedUser = users.GetUserById(user.ID_User);

                GroupMeeting newGroupMeeting = new GroupMeeting
                {
                    Name = title1.Text,
                    Location = location1.Text,
                    StartTime = start_time,
                    EndTime = end_time,
                    Participants = new List<User> { trackedUser }
                };

                groupmeet.AddGroup(newGroupMeeting);

                MessageBox.Show("Cuộc họp nhóm đã được tạo thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
                return;
            }

            Appoinment newAppointment = new Appoinment
            {
                Name = title1.Text,
                Location = location1.Text,
                StartTime = start_time,
                EndTime = end_time,
                UserID = user.ID_User
            };

            appoint.AddAppointment(newAppointment);

            MessageBox.Show("Cuộc hẹn đã được tạo thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
            return;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Schedule_Load(object sender, EventArgs e)
        {
           
        }

    }
}
