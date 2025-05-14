using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOADProject
{
    public class Reminder
    {
        [Key]
        public int ID_Reminder { get; set; }
        public DateTime Time { get; set; }
        public string Message { get; set; }

        [ForeignKey("User")]
        public string UserID { get; set; }
        public virtual User User { get; set; }
    }
}
