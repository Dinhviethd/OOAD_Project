using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOAD
{
    public class GroupMeeting
    {
        [Key]
        public int ID_Group { get; set; }
        public string Name { get; set; }
        public virtual ICollection<User> Participants { get; set; } = new List<User>();
    }
}
