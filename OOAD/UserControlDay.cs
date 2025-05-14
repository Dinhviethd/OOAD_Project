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

namespace OOAD
{
    public partial class UserControlDay: UserControl
    {
        public static int static_day;
        public UserControlDay()
        {
            InitializeComponent();
        }

        public void days(int numday)
        {
            label1.Text = numday + "";
        }

        private void UserControlDay_Click(object sender, EventArgs e)
        {
            static_day = int.Parse(label1.Text);
            Schedule sche = new Schedule();
        }
    }
}
