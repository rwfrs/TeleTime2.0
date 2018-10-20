using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TeleTime.Models;

namespace TeleTime.Context
{

        public partial class SchedulerContext :DbContext
    {
        public SchedulerContext() : base("name=Databas1") {}
        public virtual DbSet<Event> Events { get; set; }
    }
   
}