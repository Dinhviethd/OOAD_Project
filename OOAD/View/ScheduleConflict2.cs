using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OOAD.Service;

namespace OOAD.View
{
    public partial class ScheduleConflict2: Form
    {
        private Appoinment conflictingAppointment;
        private AppoinmentService appointService;
        private User user;
        private string title, location;
        private DateTime originalStart, originalEnd, start_time, end_time;
        public ScheduleConflict2(AppoinmentService service, Appoinment conflict, string t, string loc, DateTime start, DateTime end)
        {
            InitializeComponent();
            user = Login.user;
            appointService = service;
            conflictingAppointment = conflict;
            title = t;
            location = loc;
            originalStart = start;
            originalEnd = end;
            start_time = new DateTime(UserControlCalendar.static_year, UserControlCalendar.static_month, Convert.ToInt32(UserControlDay.static_day), 0, 0, 0);
            end_time = new DateTime(UserControlCalendar.static_year, UserControlCalendar.static_month, Convert.ToInt32(UserControlDay.static_day), 0, 0, 0);
        }

        private void bCreate_Click(object sender, EventArgs e)
        {
            TimeSpan temp = dtpStart.Value.TimeOfDay;
            TimeSpan temp2 = dtpEnd.Value.TimeOfDay;
            start_time = start_time + temp;
            end_time = end_time + temp2;

            if (end_time <= start_time)
            {
                MessageBox.Show("Thời gian kết thúc phải sau thời gian bắt đầu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra trùng thời gian
            var appointments = appointService.GetAppointmentsByUser(user.ID_User);
            bool overlap = appointments.Any(a =>
                a.ID_Appointment != conflictingAppointment.ID_Appointment &&
                !(end_time <= a.StartTime || start_time >= a.EndTime));

            if (overlap)
            {
                MessageBox.Show("Vẫn bị trùng lịch khác! Vui lòng chọn thời gian khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Appoinment newAppointment = new Appoinment
            {
                Name = title,
                Location = location,
                StartTime = start_time,
                EndTime = end_time,
                UserID = user.ID_User,
            };
            appointService.AddAppointment(newAppointment);

            MessageBox.Show("Lịch hẹn mới đã được tạo!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
