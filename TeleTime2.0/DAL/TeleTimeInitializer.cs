using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// using TeleTime.Context;
using TeleTime.Models;

namespace TeleTime.DAL
{
    // You can choose here if you want to reload the data base with fresh seed data. It's DropCreateDatabaseAlways will reload it. Änd DropCreateDatabaseIfModelChanges reloads the seed data if we changes models/entitys.
    // public class TeleTimeInitializer : System.Data.Entity.DropCreateDatabaseAlways<SchedulerContext>
    public class TeleTimeInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<SchedulerContext>
    {
        protected override void Seed(SchedulerContext context)
        {
            // Creating dummy data to test out the database

            // Create all days for 2018
            // DAY - All for 2018 - If you want 2019 just add more days. We seed this because it was hard to build front end logic to create specific days.

            var days = new List<Day>();

            var daysInYear = 365;

            DateTime date = new DateTime(2018, 01, 01);

            for (int i = 0; i < daysInYear; i++)
            {
                days.Add(new Day { Date = date.AddDays(i) });
            }

            days.ForEach(s => context.Days.Add(s));
            context.SaveChanges();

            // We can add more data here if we want to have start values to choose from.
        }
    }
}