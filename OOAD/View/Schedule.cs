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

            // --------- 1. Kiểm tra trùng appointment ----------
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
                if (meeting.Name == title1.Text &&
                    meeting.StartTime == start_time &&
                    meeting.EndTime == end_time)
                {
                    MeetingConflict conflictForm = new MeetingConflict(meeting, user, groupmeet);
                    var result = conflictForm.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        // Người dùng đã tham gia cuộc họp
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                        return;
                    }
                    else
                    {
                        // Người dùng đã hủy
                        return;
                    }
                }
            }
        }



        private void Schedule_Load(object sender, EventArgs e)
        {
           
        }

    }
}
