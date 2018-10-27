using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TeleTime.Models
{
    public class Day
    {
        public int ID { get; set; }
        [DisplayName("Datum")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public List<WorkDay> WorkDay { get; set; }
    }
}