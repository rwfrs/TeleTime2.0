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
        // All the data base connections and DbSets that create the tables
        public SchedulerContext() : base("Databas1")
        {
            
        }

        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Day> Days { get; set; }
        public virtual DbSet<Shift> Shifts { get; set; }
        public virtual DbSet<WorkShift> WorkShifts { get; set; }
        public virtual DbSet<WorkDay> WorkDays { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<Role> Roles { get; set; }
        public DbSet<Time> Times { get; set; }
    }
   
}