using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using TeleTime.Models;

namespace TeleTime.DAL
{

    public partial class SchedulerContext : DbContext
    {
        public SchedulerContext() : base("Databas1")
        {
            
        }

        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<Time> Times { get; set; }
        public virtual DbSet<TypeOfShift> TypeOfShifts { get; set; }
        public virtual DbSet<WorkShift> WorkShifts { get; set; }
        public virtual DbSet<WorkShiftName> WorkShiftNames { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
   
}