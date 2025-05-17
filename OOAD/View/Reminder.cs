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
    public partial class Reminder : Form
    {
        private string eventName;
        private string eventLocation;
        private DateTime eventStartTime;
        private DateTime eventEndTime;
        private string eventType;
        private ReminderService reminderService;
        private AppoinmentService appointmentService;
        private GroupMeetingService groupMeetingService;
        private Model1 db;

        public Reminder()
        {
            InitializeComponent();
            db = new Model1();
            reminderService = new ReminderService(db);
            appointmentService = new AppoinmentService(db);
            groupMeetingService = new GroupMeetingService(db);
            this.BackColor = ColorTranslator.FromHtml("#FFF7F1");
            panel1.BackColor = ColorTranslator.FromHtml("#EADBC8");

            // Add event handlers for buttons
            button1.Click += button1_Click;
            button2.Click += button2_Click;
            button3.Click += button3_Click;
        }

        public void SetReminderInfo(string name, string location, DateTime startTime, DateTime endTime, string type)
        {
            eventName = name;
            eventLocation = location;
            eventStartTime = startTime;
            eventEndTime = endTime;
            eventType = type;

            textBox5.Text = name;
            textBox3.Text = startTime.ToString("dd/MM/yyyy");
            textBox4.Text = startTime.ToString("hh:mm tt");
            textBox2.Text = location;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Confirm button
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Reschedule button
            var scheduleForm = new Schedule();
            
            // Set the current event details in the Schedule form
            if (eventType == "Appointment")
            {
                var appointment = appointmentService.GetAppointmentsByUser(Login.user.ID_User)
                    .FirstOrDefault(a => a.Name == eventName && a.StartTime == eventStartTime);
                if (appointment != null)
                {
                    scheduleForm.SetExistingAppointment(appointment);
                }
            }
            else if (eventType == "Group Meeting")
            {
                var meeting = groupMeetingService.GetGroupMeetingsByUser(Login.user.ID_User)
                    .FirstOrDefault(m => m.Name == eventName && m.StartTime == eventStartTime);
                if (meeting != null)
                {
                    scheduleForm.SetExistingGroupMeeting(meeting);
                }
            }

            if (scheduleForm.ShowDialog() == DialogResult.OK)
            {
                // Refresh the dashboard if needed
                this.DialogResult = DialogResult.OK;
            }
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Delete button
            if (MessageBox.Show("Are you sure you want to delete this event?", "Confirm Delete",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (eventType == "Appointment")
                {
                    var appointment = appointmentService.GetAppointmentsByUser(Login.user.ID_User)
                        .FirstOrDefault(a => a.Name == eventName && a.StartTime == eventStartTime);
                    if (appointment != null)
                    {
                        appointmentService.DeleteAppointment(appointment.ID_Appointment);
                    }
                }
                else if (eventType == "Group Meeting")
                {
                    var meeting = groupMeetingService.GetGroupMeetingsByUser(Login.user.ID_User)
                        .FirstOrDefault(m => m.Name == eventName && m.StartTime == eventStartTime);
                    if (meeting != null)
                    {
                        groupMeetingService.DeleteGroup(meeting.ID_Group);
                    }
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
