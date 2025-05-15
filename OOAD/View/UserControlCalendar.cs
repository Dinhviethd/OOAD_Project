using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace OOAD.View
{
    public partial class UserControlCalendar: UserControl
    {
        public static int static_month = 1, static_year = 1;
        int month, year;
        public UserControlCalendar()
        {
            InitializeComponent();
            this.BackColor = ColorTranslator.FromHtml("#FFF7F1");
            daycontainer.BackColor = ColorTranslator.FromHtml("#FFF7F1");
            label1.ForeColor = ColorTranslator.FromHtml("#776B5D");
            label2.ForeColor = ColorTranslator.FromHtml("#776B5D");
            label3.ForeColor = ColorTranslator.FromHtml("#776B5D");
            label4.ForeColor = ColorTranslator.FromHtml("#776B5D");
            label5.ForeColor = ColorTranslator.FromHtml("#776B5D");
            label6.ForeColor = ColorTranslator.FromHtml("#776B5D");
            label7.ForeColor = ColorTranslator.FromHtml("#776B5D");
            bNext.BackColor = ColorTranslator.FromHtml("#B2C8BA");
            bNext.ForeColor = ColorTranslator.FromHtml("#776B5D");
            bPrevious.BackColor = ColorTranslator.FromHtml("#B2C8BA");
            bPrevious.ForeColor = ColorTranslator.FromHtml("#776B5D");
        }
        private void bPrevious_Click(object sender, EventArgs e)
        {
            daycontainer.Controls.Clear();
            month--;
            if (month < 1)
            {
                month = 12;
                year--;
            }
            String monthname = DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
            static_month = month;
            static_year = year;
            lmy.Text = monthname + " " + year;
            DateTime startOfMonth = new DateTime(year, month, 1);
            // Get the count of days of the current month
            int days = DateTime.DaysInMonth(year, month);
            int dayofweek = Convert.ToInt32(startOfMonth.DayOfWeek.ToString("d"));
            for (int i = 1; i <= dayofweek; i++)
            {
                UserControlBlank ucblank = new UserControlBlank();
                daycontainer.Controls.Add(ucblank);
            }
            for (int i = 1; i <= days; i++)
            {
                AddDayControl(i);
            }
        }

        private void UserControlCalendar_Load(object sender, EventArgs e)
        {
            displayDays();
        }

        private void bNext_Click(object sender, EventArgs e)
        {
            daycontainer.Controls.Clear();
            month++;
            if (month > 12)
            {
                month = 1;
                year++;
            }
            String monthname = DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
            static_month = month;
            static_year = year;
            lmy.Text = monthname + " " + year;
            DateTime startOfMonth = new DateTime(year, month, 1);
            // Get the count of days of the current month
            int days = DateTime.DaysInMonth(year, month);
            int dayofweek = Convert.ToInt32(startOfMonth.DayOfWeek.ToString("d"));
            for (int i = 1; i <= dayofweek; i++)
            {
                UserControlBlank ucblank = new UserControlBlank();
                daycontainer.Controls.Add(ucblank);
            }
            for (int i = 1; i <= days; i++)
            {
               AddDayControl(i);
            }
        }
        private void displayDays()
        {
            DateTime now = DateTime.Now;
            month = now.Month;
            year = now.Year;
            static_month = month;
            static_year = year;
            // Get the first day of the current month
            DateTime startOfMonth = new DateTime(year, month, 1);
            String monthname = DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
            lmy.Text = monthname + " " + year;
            // Get the count of days of the current month
            int days = DateTime.DaysInMonth(year, month);
            int dayofweek = Convert.ToInt32(startOfMonth.DayOfWeek.ToString("d"));
            for (int i = 1; i <= dayofweek; i++)
            {
                UserControlBlank ucblank = new UserControlBlank();
                daycontainer.Controls.Add(ucblank);
            }
            for (int i = 1; i <= days; i++)
            {
                AddDayControl(i);
            }
        }
        private void AddDayControl(int day)
        {
            UserControlDay ucd = new UserControlDay();
            ucd.days(day);
            DateTime thisDate = new DateTime(year, month, day);
            if (thisDate.Date == DateTime.Today)
            {
                ucd.BackColor = ColorTranslator.FromHtml("#FFCBCB");
                foreach (Control c in ucd.Controls)
                {
                    if (c is Label lbl)
                        lbl.ForeColor = ColorTranslator.FromHtml("#776B5D");
                } 
            }
            daycontainer.Controls.Add(ucd);
        }

    }
}
