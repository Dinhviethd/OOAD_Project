using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOAD
{
    public partial class Calendar: Form
    {
        public static int static_month, static_year;
        int month, year;
        public Calendar()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            displayDays();
        }
        private void displayDays()
        {
            DateTime now = DateTime.Now;
            month = now.Month;
            year = now.Year;
            static_month = month;
            static_year = year;
            // Get the first day of the current month
            DateTime startOfMonth = new DateTime(year,month, 1);
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
            for(int i = 1; i <= days;i++)
            {
                UserControlDay ucd = new UserControlDay();
                ucd.days(i);
                daycontainer.Controls.Add(ucd);
            }
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
                UserControlDay ucd = new UserControlDay();
                ucd.days(i);
                daycontainer.Controls.Add(ucd);
            }
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
                UserControlDay ucd = new UserControlDay();
                ucd.days(i);
                daycontainer.Controls.Add(ucd);
            }
        }
    }
}
