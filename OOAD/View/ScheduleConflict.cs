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
using OOAD.View;

namespace OOAD
{
    public partial class ScheduleConflict: Form
    {
        private Appoinment conflictingAppointment;
        private AppoinmentService appointService;
        private User user;
        private string title, location;
        private DateTime originalStart, originalEnd, start_time, end_time;
        public ScheduleConflict(AppoinmentService service, Appoinment conflict, string t, string loc, DateTime start, DateTime end)
        {
            InitializeComponent();
            user = Login.user;
            appointService = service;
            conflictingAppointment = conflict;
            title = t;
            location = loc;
            originalStart = start;
            originalEnd = end;
            var box = new UserControlBox();
            box.SetData(
                conflictingAppointment.Name,
                conflictingAppointment.Location,
                conflictingAppointment.StartTime,
                conflictingAppointment.EndTime,
                "Appointment"
            );
            box.BackColor = ColorTranslator.FromHtml("#FFF3E0");
            box.Dock = DockStyle.Top;
            panel1.Controls.Add(box);

        }

        private void bCreate_Click(object sender, EventArgs e)
        {
            ScheduleConflict2 conflict2 = new ScheduleConflict2(
                appointService,
                conflictingAppointment,
                title,
                location,
                originalStart,
                originalEnd
            );

            var result = conflict2.ShowDialog();

            if (result == DialogResult.OK)
            {
                // Người dùng đã tạo thành công cuộc hẹn mới
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            appointService.DeleteAppointment(conflictingAppointment.ID_Appointment);

            Appoinment newAppointment = new Appoinment
            {
                Name = title,
                Location = location,
                StartTime = originalStart,
                EndTime = originalEnd,
                UserID = user.ID_User,
            };
            appointService.AddAppointment(newAppointment);

            MessageBox.Show("Lịch hẹn đã được ghi đè!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
