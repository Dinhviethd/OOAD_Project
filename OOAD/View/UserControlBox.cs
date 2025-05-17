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
using System.Drawing.Drawing2D;
using System.Reflection.Emit;

namespace OOAD.View
{
    public partial class UserControlBox: UserControl
    {
        User user;
        AppoinmentService appoint;
        GroupMeetingService groupmeet;
        UserService users;
        ReminderService reminderService;
        private string eventName;
        private string eventLocation;
        private DateTime eventStartTime;
        private DateTime eventEndTime;
        private string eventType;

        public UserControlBox()
        {
            user = Login.user;
            InitializeComponent();
            var db = new Model1();
            appoint = new AppoinmentService(db);
            groupmeet = new GroupMeetingService(db);
            users = new UserService(db);
            reminderService = new ReminderService(db);
            this.Click += UserControlBox_Click;
        }

        public void SetData(string name, string location, DateTime startTime, DateTime endTime, string type)
        {
            eventName = name;
            eventLocation = location;
            eventStartTime = startTime;
            eventEndTime = endTime;
            eventType = type;

            label1.Text = name;
            label2.Text = location;

            if (startTime.Date == DateTime.Today)
                label3.Text = $"Today, {startTime:hh\\:mm tt}";
            else
                label3.Text = startTime.ToString("dd/MM/yyyy hh\\:mm tt");

            TimeSpan duration = endTime - startTime;
            label4.Text = $"Duration: {(int)duration.TotalMinutes} minutes";

            label5.Text = type;
        }

        private void UserControlBox_Click(object sender, EventArgs e)
        {
            var reminderForm = new Reminder();
            reminderForm.SetReminderInfo(eventName, eventLocation, eventStartTime, eventEndTime, eventType);
            reminderForm.ShowDialog();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Color borderColor = ColorTranslator.FromHtml("#EADBC8");
            int borderThickness = 2;

            using (Pen p = new Pen(borderColor, borderThickness))
            {
                p.Alignment = PenAlignment.Inset;
                e.Graphics.DrawRectangle(p, new Rectangle(0, 0, this.Width - 1, this.Height - 1));
            }
        }

        private void UserControlBox_Load(object sender, EventArgs e)
        {

        }
    }
}
