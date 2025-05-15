using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OOAD.View;
using System.Drawing.Drawing2D;

namespace OOAD
{
    public partial class UserControlDay: UserControl
    {
        User loggeduser;
        public static string static_day = "1";
        public UserControlDay()
        {
            loggeduser = Login.user;
            InitializeComponent();
            this.BackColor = ColorTranslator.FromHtml("#FDF6E3");
            this.ForeColor = ColorTranslator.FromHtml("#776B5D");
        }
        public void days(int numday)
        {
            label1.Text = numday + "";
        }

        private void UserControlDay_Click(object sender, EventArgs e)
        {
            static_day = label1.Text;
            Schedule sche = new Schedule();
            sche.Show();
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
