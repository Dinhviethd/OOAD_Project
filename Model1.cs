using System;
using System.Data.Entity;
using System.Linq;

namespace OOADProject
{
    public class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Appoinment> Appointments { get; set; }
        public virtual DbSet<Reminder> Reminders { get; set; }
        public virtual DbSet<GroupMeeting> GroupMeetings { get; set; }
        public virtual DbSet<Reminder> Reminders { get; set; }

    }
}