using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TeleTime.Models
{
    // Class for storing the actual date and has a connection to WorkDay
    public class Day
    {
        // Primary key
        public int ID { get; set; }
        // DateTime object for storing the dates. The other code is for populating it in a correct format.
        [DisplayName("Datum")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime Date { get; set; }

        // Read only propery that returns string instead of DateTime. And in short format.
        public string DateText { get { return Date.ToShortDateString(); } }

        // The connection to WorkDay.
        public List<WorkDay> WorkDay { get; set; }
    }
}