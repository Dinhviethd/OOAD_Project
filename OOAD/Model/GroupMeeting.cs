using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OOAD
{
    public class GroupMeeting
    {
        [Key]
        public int ID_Group { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public virtual ICollection<User> Participants { get; set; } = new List<User>();
    }
}
