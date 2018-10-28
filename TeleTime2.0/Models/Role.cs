﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeleTime.Models
{
    public class Role
    {
        public int ID { get; set; }
        public string RoleName { get; set; }

        public List<WorkShift> WorkShifts { get; set; }
    }
}