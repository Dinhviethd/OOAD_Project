using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOADProject
{
    public class GroupMeeting
    {
        [Key]
        public string ID_Group { get; set; }
        public string Name { get; set; }
        public virtual ICollection<User> Participants { get; set; } = new List<User>();
    }
}
