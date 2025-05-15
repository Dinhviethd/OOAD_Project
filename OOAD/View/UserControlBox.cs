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

namespace OOAD.View
{
    public partial class UserControlBox: UserControl
    {
        User user;
        AppoinmentService appoint;
        GroupMeetingService groupmeet;
        UserService users;
        public UserControlBox()
        {
            user = Login.user;
            InitializeComponent();
            var db = new Model1();
            appoint = new AppoinmentService(db);
            groupmeet = new GroupMeetingService(db);
            users = new UserService(db);
        }
        public void SetData(string name, string location, DateTime startTime, DateTime endTime)
        {
            label1.Text = name;
            label2.Text = location;

            if (startTime.Date == DateTime.Today)
                label3.Text = $"Today, {startTime:hh\\:mm tt}";
            else
                label3.Text = startTime.ToString("dd/MM/yyyy hh\\:mm tt");

            // Duration
            TimeSpan duration = endTime - startTime;
            label4.Text = $"Duration: {(int)duration.TotalMinutes} minutes";
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Color borderColor = ColorTranslator.FromHtml("#EADBC8"); // màu pastel nâu nhạt
            int borderThickness = 2;

            using (Pen p = new Pen(borderColor, borderThickness))
            {
                p.Alignment = PenAlignment.Inset; // Viền nằm bên trong control
                e.Graphics.DrawRectangle(p, new Rectangle(0, 0, this.Width - 1, this.Height - 1));
            }
        }
    }
}
