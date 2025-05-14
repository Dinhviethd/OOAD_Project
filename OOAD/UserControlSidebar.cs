using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOAD
{
    public partial class UserControlSidebar: UserControl
    {
        public UserControlSidebar()
        {
            InitializeComponent();
        }

        private void bDashboard_Click(object sender, EventArgs e)
        {

        }

        private void bCalendar_Click(object sender, EventArgs e)
        {
            Calendar calen = new Calendar();
            calen.Show();
        }
    }
}
