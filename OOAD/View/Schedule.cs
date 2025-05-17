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
    public partial class Schedule : Form
    {
        User user;
        AppoinmentService appoint;
        GroupMeetingService groupmeet;
        UserService users;
        //DateTime start_time,end_time; // These class members for date part can be removed if pickers are initialized correctly

        // Fields to store the original event if rescheduling
        private Appoinment originalAppointmentToReschedule = null;
        private GroupMeeting originalGroupMeetingToReschedule = null;

        public Schedule()
        {
            user = Login.user;
            InitializeComponent();
            var db = new Model1(); // Consider making db context life cycle managed (e.g., passed in or using block)
            appoint = new AppoinmentService(db);
            groupmeet = new GroupMeetingService(db);
            users = new UserService(db);

            // Initialize DateTimePickers with the selected date from calendar and a default time
            DateTime initialPickerDateTime = new DateTime(
                UserControlCalendar.static_year,
                UserControlCalendar.static_month,
                Convert.ToInt32(UserControlDay.static_day),
                DateTime.Now.Hour, // Default to current hour
                0, // Default to 0 minutes
                0);
            dateTimePicker1.Value = initialPickerDateTime;
            dateTimePicker2.Value = initialPickerDateTime.AddHours(1); // Default duration 1 hour
        }

        // Method to pre-fill for rescheduling an Appointment
        public void SetExistingAppointment(Appoinment appointment)
        {
            originalAppointmentToReschedule = appointment;
            originalGroupMeetingToReschedule = null;

            title1.Text = appointment.Name;
            location1.Text = appointment.Location;
            dateTimePicker1.Value = appointment.StartTime;
            dateTimePicker2.Value = appointment.EndTime;
            groupmeeting.Checked = false;
            // TODO: Handle reminder.Checked if reminder status needs to be carried over
        }

        // Method to pre-fill for rescheduling a GroupMeeting
        public void SetExistingGroupMeeting(GroupMeeting meeting)
        {
            originalGroupMeetingToReschedule = meeting;
            originalAppointmentToReschedule = null;

            title1.Text = meeting.Name;
            location1.Text = meeting.Location;
            dateTimePicker1.Value = meeting.StartTime;
            dateTimePicker2.Value = meeting.EndTime;
            groupmeeting.Checked = true;
            // TODO: Handle reminder.Checked if reminder status needs to be carried over
        }

        private void ok_Click(object sender, EventArgs e)
        {
            DateTime eventStartTime = dateTimePicker1.Value;
            DateTime eventEndTime = dateTimePicker2.Value;

            if (eventEndTime < eventStartTime)
            {
                MessageBox.Show("Thời gian kết thúc phải sau thời gian bắt đầu.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(title1.Text) || string.IsNullOrWhiteSpace(location1.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool isReschedulingAppointment = (originalAppointmentToReschedule != null);
            bool isReschedulingGroupMeeting = (originalGroupMeetingToReschedule != null);

            // --- Conflict Checking for Appointments ---
            IEnumerable<Appoinment> appointmentsToCheck = appoint.GetAppointmentsByUser(user.ID_User);
            if (isReschedulingAppointment)
            {
                appointmentsToCheck = appointmentsToCheck.Where(a => a.ID_Appointment != originalAppointmentToReschedule.ID_Appointment);
            }

            foreach (var appt in appointmentsToCheck)
            {
                bool timeConflict = !(eventEndTime <= appt.StartTime || eventStartTime >= appt.EndTime);
                if (timeConflict)
                {
                    ScheduleConflict conflictForm = new ScheduleConflict(appoint, appt, title1.Text, location1.Text, eventStartTime, eventEndTime);
                    var result = conflictForm.ShowDialog();
                    if (result == DialogResult.OK) // User resolved (e.g., overwrite)
                    {
                        // The conflict form itself might handle creation/deletion.
                        // If it does, original might need deletion here.
                        // For now, assume conflict form leads to a state where we can proceed or stop.
                        // If DialogResult.OK, it means the user in ScheduleConflict form decided to proceed (e.g. overwrite or create new time)
                        // and that form completed its action. We now need to delete the *original* appointment being rescheduled.
                        if (isReschedulingAppointment)
                        {
                            appoint.DeleteAppointment(originalAppointmentToReschedule.ID_Appointment);
                            originalAppointmentToReschedule = null;
                        }
                        this.DialogResult = DialogResult.OK; // Signal success to Reminder form
                        this.Close();
                        return;
                    }
                    else // User cancelled conflict resolution
                    {
                        return;
                    }
                }
            }

            // --- Conflict Checking for Group Meetings (similar existing meeting) ---
            var allGroupMeetings = groupmeet.GetAllGroups();
            foreach (var meeting in allGroupMeetings)
            {
                if (isReschedulingGroupMeeting && meeting.ID_Group == originalGroupMeetingToReschedule.ID_Group)
                {
                    continue;
                }
                if (meeting.Participants.Any(p => p.ID_User == user.ID_User))
                {
                    continue;
                }
                DateTime meetingStartDb = new DateTime(meeting.StartTime.Year, meeting.StartTime.Month, meeting.StartTime.Day, meeting.StartTime.Hour, meeting.StartTime.Minute, 0);
                DateTime currentEventStart = new DateTime(eventStartTime.Year, eventStartTime.Month, eventStartTime.Day, eventStartTime.Hour, eventStartTime.Minute, 0);
                bool sameStartMinute = meetingStartDb == currentEventStart;
                TimeSpan durationMeetingDb = meeting.EndTime - meeting.StartTime;
                TimeSpan durationCurrentEvent = eventEndTime - eventStartTime;
                bool durationCloseEnough = Math.Abs((durationMeetingDb - durationCurrentEvent).TotalSeconds) <= 60;

                if (sameStartMinute && durationCloseEnough)
                {
                    MeetingConflict meetingConflictForm = new MeetingConflict(meeting, user, groupmeet);
                    var result = meetingConflictForm.ShowDialog();
                    if (result == DialogResult.OK) // User chose to JOIN
                    {
                        if (isReschedulingGroupMeeting) { groupmeet.DeleteGroup(originalGroupMeetingToReschedule.ID_Group); originalGroupMeetingToReschedule = null; }
                        if (isReschedulingAppointment) { appoint.DeleteAppointment(originalAppointmentToReschedule.ID_Appointment); originalAppointmentToReschedule = null; }
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                        return;
                    }
                    else // User chose CANCEL on MeetingConflict (don't join, create their own)
                    {
                        // Proceed to create their own event, so break from checking other similar meetings.
                        break;
                    }
                }
            }

            // --- If rescheduling, delete the original event now that conflicts are handled/checked ---
            if (isReschedulingAppointment)
            {
                appoint.DeleteAppointment(originalAppointmentToReschedule.ID_Appointment);
            }
            if (isReschedulingGroupMeeting)
            {
                groupmeet.DeleteGroup(originalGroupMeetingToReschedule.ID_Group);
            }

            // --- Create the new/rescheduled event ---
            if (groupmeeting.Checked)
            {
                var trackedUser = users.GetUserById(user.ID_User);
                if (trackedUser == null)
                {
                    MessageBox.Show("Lỗi: Không tìm thấy thông tin người dùng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                GroupMeeting newGroupMeeting = new GroupMeeting
                {
                    Name = title1.Text,
                    Location = location1.Text,
                    StartTime = eventStartTime,
                    EndTime = eventEndTime,
                    Participants = new List<User> { trackedUser }
                };
                groupmeet.AddGroup(newGroupMeeting);
                MessageBox.Show("Cuộc họp nhóm đã được tạo thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Appoinment newAppointment = new Appoinment
                {
                    Name = title1.Text,
                    Location = location1.Text,
                    StartTime = eventStartTime,
                    EndTime = eventEndTime,
                    UserID = user.ID_User
                };
                appoint.AddAppointment(newAppointment);
                MessageBox.Show("Cuộc hẹn đã được tạo thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Schedule_Load(object sender, EventArgs e)
        {
            // If needed, additional load logic.
            // Pickers are initialized in constructor or SetExisting... methods.
        }
    }
}