using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOAD.Service
{
    public class ReminderService
    {
        private readonly Model1 _context;

        public ReminderService(Model1 context)
        {
            _context = context;
        }

        public List<Reminder> GetRemindersByUser(int userId)
        {
            return _context.Reminders
                .Where(r => r.Appoinment.UserID == userId)
                .ToList();
        }

        public void AddReminder(Reminder reminder)
        {
            _context.Reminders.Add(reminder);
            _context.SaveChanges();
        }

        public void UpdateReminder(Reminder reminder)
        {
            _context.Reminders.Attach(reminder);
            _context.Entry(reminder).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteReminder(int id)
        {
            var reminder = _context.Reminders.Find(id);
            if (reminder != null)
            {
                _context.Reminders.Remove(reminder);
                _context.SaveChanges();
            }
        }
    }

}
