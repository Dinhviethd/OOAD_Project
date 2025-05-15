using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OOAD.Service;

namespace OOAD.View
{
    public partial class UserControlDashboard: UserControl
    {
        User user;
        AppoinmentService appoint;
        GroupMeetingService groupmeet;
        UserService users;
        public UserControlDashboard()
        {
            user = Login.user;
            InitializeComponent();
            this.BackColor = ColorTranslator.FromHtml("#FFF7F1");
            mainpan.BackColor = ColorTranslator.FromHtml("#FFF7F1");
            var db = new Model1();
            appoint = new AppoinmentService(db);
            groupmeet = new GroupMeetingService(db);
            users = new UserService(db);
            panel1.BackColor = ColorTranslator.FromHtml("#EADBC8");
            panel2.BackColor = ColorTranslator.FromHtml("#EADBC8");
        }

        private void UserControlDashboard_Load(object sender, EventArgs e)
        {
            label3.Text = appoint.GetAppointmentCountByUser(user.ID_User).ToString();
            label4.Text = groupmeet.GetGroupMeetingCountByUser(user.ID_User).ToString();
            panel3.Controls.Clear();

            // Load Appointments
            var appointments = appoint.GetAppointmentsByUser(user.ID_User);
            foreach (var appt in appointments)
            {
                var box = new UserControlBox();
                box.SetData(appt.Name, appt.Location, appt.StartTime, appt.EndTime);
                box.BackColor = ColorTranslator.FromHtml("#FDF6E3");
                panel3.Controls.Add(box);
            }

            // Load GroupMeetings
            var meetings = groupmeet.GetGroupMeetingsByUser(user.ID_User);
            foreach (var meeting in meetings)
            {
                var box = new UserControlBox();
                box.SetData(meeting.Name, meeting.Location, meeting.StartTime, meeting.EndTime);
                box.BackColor = ColorTranslator.FromHtml("#FDF6E3");
                panel3.Controls.Add(box);
            }
        }
    }
}
