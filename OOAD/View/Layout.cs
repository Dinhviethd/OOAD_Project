using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOAD.View
{
    public partial class Layout: Form
    {
        UserControlCalendar cal;
        UserControlDashboard dash;
        Login log = Login.log;
        public Layout()
        {
            InitializeComponent();
            contentPanel.BackColor = ColorTranslator.FromHtml("#FFF7F1");
            label1.Text = "Hello, " + Login.user.Name;
            panel1.BackColor = ColorTranslator.FromHtml("#EADBC8");
            bCal.BackColor = ColorTranslator.FromHtml("#F8F6F4");
            bCal.ForeColor = ColorTranslator.FromHtml("#5A8F7B");
            bCal.FlatAppearance.BorderColor = ColorTranslator.FromHtml("#C2C2C2");
            bDash.BackColor = ColorTranslator.FromHtml("#F8F6F4");
            bDash.ForeColor = ColorTranslator.FromHtml("#5A8F7B");
            bDash.FlatAppearance.BorderColor = ColorTranslator.FromHtml("#C2C2C2");
            bLog.BackColor = ColorTranslator.FromHtml("#F8F6F4");
            bLog.ForeColor = ColorTranslator.FromHtml("#5A8F7B");
            bLog.FlatAppearance.BorderColor = ColorTranslator.FromHtml("#C2C2C2");
        }

        private void bDash_Click(object sender, EventArgs e)
        {
            if (dash == null || !contentPanel.Contains(dash))
            {
                contentPanel.Controls.Clear();
                dash = new UserControlDashboard();
                dash.Dock = DockStyle.Fill;
                contentPanel.Controls.Add(dash);
            }
            else
            {
                dash.Visible = true;
                dash.BringToFront();
            }

        }
        private void bCal_Click(object sender, EventArgs e)
        {
            if (cal == null || !contentPanel.Contains(cal))
            {
                contentPanel.Controls.Clear();
                cal = new UserControlCalendar();
                cal.Dock = DockStyle.Fill;
                contentPanel.Controls.Add(cal);
            }
            else
            {
                cal.Visible = true; 
                cal.BringToFront();
            }
        }
        private void bLog_Click(object sender, EventArgs e)
        {
            log.Show();
            this.Dispose();
            Login.user = null;
        }
    }
}
