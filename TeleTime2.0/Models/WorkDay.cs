using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TeleTime.Models
{
    public class WorkDay
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DateID { get; set; }
        public DateTime Date { get; set; }
        public bool WorkShiftExist { get; set; }
        
        public List<WorkShift> WorkShifts { get; set; }
    }
}