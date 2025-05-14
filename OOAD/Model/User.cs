using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOAD
{
    [Table("User")]
    public class User
    {
        [Key]
        public int ID_User { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string EmailAddress { get; set; }

        public virtual ICollection<Reminder> Reminders { get; set; } = new List<Reminder>();
        public virtual ICollection<GroupMeeting> GroupMeetings { get; set; } = new List<GroupMeeting>();
    }
}
