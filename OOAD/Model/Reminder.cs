using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOAD
{
    public class Reminder
    {
        [Key]
        public int ID_Reminder { get; set; }
        public DateTime Time { get; set; }
        public string Message { get; set; }

        [ForeignKey("Appoinment")]
        public int ID_Appointment { get; set; }
        public virtual Appoinment Appoinment { get; set; }
    }
}
