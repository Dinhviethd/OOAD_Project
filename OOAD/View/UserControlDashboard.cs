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

            DateTime now = DateTime.Now;

            // Lấy danh sách appointment còn hiệu lực
            var appointments = appoint.GetAppointmentsByUser(user.ID_User)
                .Where(a => a.EndTime > now)
                .Select(a => new
                {
                    Title = a.Name,
                    Location = a.Location,
                    Start = a.StartTime,
                    End = a.EndTime,
                    Type = "Appointment"
                });

            // Lấy danh sách meeting còn hiệu lực
            var meetings = groupmeet.GetGroupMeetingsByUser(user.ID_User)
                .Where(m => m.EndTime > now)
                .Select(m => new
                {
                    Title = m.Name,
                    Location = m.Location,
                    Start = m.StartTime,
                    End = m.EndTime,
                    Type = "Group Meeting"
                });

            // Gộp và sắp xếp theo thời gian bắt đầu
            var allEvents = appointments
                .Concat(meetings)
                .OrderBy(item => item.Start)
                .ToList();

            // Hiển thị từng sự kiện
            foreach (var evt in allEvents)
            {
                var box = new UserControlBox();
                box.SetData(evt.Title, evt.Location, evt.Start, evt.End, evt.Type); // Thêm evt.Type
                box.BackColor = ColorTranslator.FromHtml("#FDF6E3");
                panel3.Controls.Add(box);
            }
        }


    }
}
