using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOAD.Service
{
    public class AppoinmentService
    {
        private readonly Model1 _context;

        public AppoinmentService(Model1 context)
        {
            _context = context;
        }

        public List<Appoinment> GetAppointmentsByUser(int userId)
        {
            return _context.Appointments
                .Where(a => a.UserID == userId)
                .ToList();
        }

        public void AddAppointment(Appoinment appointment)
        {
            _context.Appointments.Add(appointment);
            _context.SaveChanges();
        }

        public void UpdateAppointment(Appoinment appointment)
        {
            _context.Appointments.Attach(appointment);
            _context.Entry(appointment).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteAppointment(int id)
        {
            var appointment = _context.Appointments.Find(id);
            if (appointment != null)
            {
                _context.Appointments.Remove(appointment);
                _context.SaveChanges();
            }
        }
    }

}
