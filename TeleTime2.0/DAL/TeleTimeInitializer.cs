using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// using TeleTime.Context;
using TeleTime.Models;

namespace TeleTime.DAL
{
    public class TeleTimeInitializer : System.Data.Entity.DropCreateDatabaseAlways<SchedulerContext>
    // public class TeleTimeInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<SchedulerContext>
    {
        protected override void Seed(SchedulerContext context)
        {
            //        // Creating dummy data to test out the database

            // Create all days for 2018

            // DAY - All for 2018

            var days = new List<Day>();

            var daysInYear = 365;

            DateTime date = new DateTime(2018, 01, 01);

            for (int i = 0; i < daysInYear; i++)
            {
                days.Add(new Day { Date = date.AddDays(i) });
            }

            days.ForEach(s => context.Days.Add(s));
            context.SaveChanges();

            //        // TIME
            //        var times = new List<Time>
            //        {
            //            new Time { StartEndTime = "08-12" },
            //            new Time { StartEndTime = "12-17" }
            //        };

            //        times.ForEach(s => context.Times.Add(s));
            //        // context.SaveChanges();

            //        // TYPEOFSHIFT
            //        var typeOfShifts = new List<TypeOfShift>
            //        {
            //            new TypeOfShift { ShiftName = "Front" },
            //            new TypeOfShift { ShiftName = "Back" },
            //            new TypeOfShift { ShiftName = "CallBack" },
            //        };

            //        typeOfShifts.ForEach(s => context.TypeOfShifts.Add(s));
            //        // context.SaveChanges();

            //        // PERSON
            //        var persons = new List<Person>
            //        {
            //            new Person { Name = "David Welin", EMail = "david@mail.com" },
            //            new Person { Name = "Pelle Anka", EMail = "pelle@mail.com" },
            //            new Person { Name = "Kalle Kråka", EMail = "kalle@mail.com" },
            //            new Person { Name = "Nisse Naprapat", EMail = "nisse@mail.com" },
            //            new Person { Name = "Rille Rille", EMail = "rille@mail.com" },
            //            new Person { Name = "Olle Olsson", EMail = "olle@mail.com" }
            //        };

            //        persons.ForEach(s => context.Persons.Add(s));
            //        // context.SaveChanges();

            //        // WORKSHIFTNAME
            //        var workShiftNames = new List<WorkShiftName>
            //        {
            //            new WorkShiftName { WorkShiftNameName = "Standard" },
            //            new WorkShiftName { WorkShiftNameName = "Legend" }
            //        };

            //        workShiftNames.ForEach(s => context.WorkShiftNames.Add(s));
            //        // context.SaveChanges();

            //        //WORKDAY

            //        DateTime date = DateTime.Now;

            //        var workDays = new List<WorkDay>
            //        {
            //        new WorkDay { Date = date, WorkShiftExist = true },
            //        new WorkDay { Date = date.AddDays(1), WorkShiftExist = true },
            //        new WorkDay { Date = date.AddDays(2), WorkShiftExist = true },
            //        };

            //        workDays.ForEach(s => context.WorkDays.Add(s));
            //        context.SaveChanges();

            //        DateTime toDay = DateTime.Now;

            //        List<WorkShift> workShifts = new List<WorkShift>
            //        { 
            //        // Idag
            //        new WorkShift {
            //            WorkShiftNameName = context.WorkShiftNames.Find("Standard").WorkShiftNameName,
            //            StartEndTime = context.Times.Find("08-12").StartEndTime,
            //            ShiftName = context.TypeOfShifts.Find("Front").ShiftName,
            //            Name = context.Persons.Find("David Welin").Name,
            //            DateID = context.WorkDays.Find(1).DateID },
            //        new WorkShift {
            //            WorkShiftNameName = context.WorkShiftNames.Find("Standard").WorkShiftNameName,
            //            StartEndTime = context.Times.Find("08-12").StartEndTime,
            //            ShiftName = context.TypeOfShifts.Find("Back").ShiftName,
            //            Name = context.Persons.Find("Pelle Anka").Name,
            //            DateID = context.WorkDays.Find(1).DateID },
            //        new WorkShift {
            //            WorkShiftNameName = context.WorkShiftNames.Find("Standard").WorkShiftNameName,
            //            StartEndTime = context.Times.Find("08-12").StartEndTime,
            //            ShiftName = context.TypeOfShifts.Find("CallBack").ShiftName,
            //            Name = context.Persons.Find("Kalle Kråka").Name,
            //            DateID = context.WorkDays.Find(1).DateID },
            //        new WorkShift {
            //            WorkShiftNameName = context.WorkShiftNames.Find("Standard").WorkShiftNameName,
            //            StartEndTime = context.Times.Find("12-17").StartEndTime,
            //            ShiftName = context.TypeOfShifts.Find("Front").ShiftName,
            //            Name = context.Persons.Find("Nisse Naprapat").Name,
            //            DateID = context.WorkDays.Find(1).DateID },
            //        new WorkShift {
            //            WorkShiftNameName = context.WorkShiftNames.Find("Standard").WorkShiftNameName,
            //            StartEndTime = context.Times.Find("12-17").StartEndTime,
            //            ShiftName = context.TypeOfShifts.Find("Back").ShiftName,
            //            Name = context.Persons.Find("Rille Rille").Name,
            //            DateID = context.WorkDays.Find(1).DateID },
            //        new WorkShift {
            //            WorkShiftNameName = context.WorkShiftNames.Find("Standard").WorkShiftNameName,
            //            StartEndTime = context.Times.Find("12-17").StartEndTime,
            //            ShiftName = context.TypeOfShifts.Find("CallBack").ShiftName,
            //            Name = context.Persons.Find("Olle Olsson").Name,
            //            DateID = context.WorkDays.Find(1).DateID },
            //        // Imorgon
            //        new WorkShift {
            //            WorkShiftNameName = context.WorkShiftNames.Find("Legend").WorkShiftNameName,
            //            StartEndTime = context.Times.Find("08-12").StartEndTime,
            //            ShiftName = context.TypeOfShifts.Find("Front").ShiftName,
            //            Name = context.Persons.Find("Olle Olsson").Name,
            //            DateID = context.WorkDays.Find(2).DateID },
            //        new WorkShift {
            //            WorkShiftNameName = context.WorkShiftNames.Find("Legend").WorkShiftNameName,
            //            StartEndTime = context.Times.Find("08-12").StartEndTime,
            //            ShiftName = context.TypeOfShifts.Find("Back").ShiftName,
            //            Name = context.Persons.Find("Nisse Naprapat").Name,
            //            DateID = context.WorkDays.Find(2).DateID },
            //        new WorkShift {
            //            WorkShiftNameName = context.WorkShiftNames.Find("Legend").WorkShiftNameName,
            //            StartEndTime = context.Times.Find("08-12").StartEndTime,
            //            ShiftName = context.TypeOfShifts.Find("CallBack").ShiftName,
            //            Name = context.Persons.Find("Kalle Kråka").Name,
            //            DateID = context.WorkDays.Find(2).DateID },
            //        new WorkShift {
            //            WorkShiftNameName = context.WorkShiftNames.Find("Legend").WorkShiftNameName,
            //            StartEndTime = context.Times.Find("12-17").StartEndTime,
            //            ShiftName = context.TypeOfShifts.Find("Front").ShiftName,
            //            Name = context.Persons.Find("Pelle Anka").Name,
            //            DateID = context.WorkDays.Find(2).DateID },
            //        new WorkShift {
            //            WorkShiftNameName = context.WorkShiftNames.Find("Legend").WorkShiftNameName,
            //            StartEndTime = context.Times.Find("12-17").StartEndTime,
            //            ShiftName = context.TypeOfShifts.Find("Back").ShiftName,
            //            Name = context.Persons.Find("David Welin").Name,
            //            DateID = context.WorkDays.Find(2).DateID },
            //        new WorkShift {
            //            WorkShiftNameName = context.WorkShiftNames.Find("Legend").WorkShiftNameName,
            //            StartEndTime = context.Times.Find("12-17").StartEndTime,
            //            ShiftName = context.TypeOfShifts.Find("CallBack").ShiftName,
            //            Name = context.Persons.Find("David Welin").Name,
            //            DateID = context.WorkDays.Find(2).DateID},
            //        // Övermorgon
            //        new WorkShift {
            //            WorkShiftNameName = context.WorkShiftNames.Find("Legend").WorkShiftNameName,
            //            StartEndTime = context.Times.Find("08-12").StartEndTime,
            //            ShiftName = context.TypeOfShifts.Find("Front").ShiftName,
            //            Name = context.Persons.Find("Olle Olsson").Name,
            //            DateID = context.WorkDays.Find(3).DateID },
            //        new WorkShift {
            //            WorkShiftNameName = context.WorkShiftNames.Find("Legend").WorkShiftNameName,
            //            StartEndTime = context.Times.Find("08-12").StartEndTime,
            //            ShiftName = context.TypeOfShifts.Find("Back").ShiftName,
            //            Name = context.Persons.Find("Nisse Naprapat").Name,
            //            DateID = context.WorkDays.Find(3).DateID },
            //        new WorkShift {
            //            WorkShiftNameName = context.WorkShiftNames.Find("Legend").WorkShiftNameName,
            //            StartEndTime = context.Times.Find("08-12").StartEndTime,
            //            ShiftName = context.TypeOfShifts.Find("CallBack").ShiftName,
            //            Name = context.Persons.Find("Kalle Kråka").Name,
            //            DateID = context.WorkDays.Find(3).DateID },
            //        new WorkShift {
            //            WorkShiftNameName = context.WorkShiftNames.Find("Legend").WorkShiftNameName,
            //            StartEndTime = context.Times.Find("12-17").StartEndTime,
            //            ShiftName = context.TypeOfShifts.Find("Front").ShiftName,
            //            Name = context.Persons.Find("Pelle Anka").Name,
            //            DateID = context.WorkDays.Find(3).DateID },
            //        new WorkShift {
            //            WorkShiftNameName = context.WorkShiftNames.Find("Legend").WorkShiftNameName,
            //            StartEndTime = context.Times.Find("12-17").StartEndTime,
            //            ShiftName = context.TypeOfShifts.Find("Back").ShiftName,
            //            Name = context.Persons.Find("David Welin").Name,
            //            DateID = context.WorkDays.Find(3).DateID },
            //        new WorkShift {
            //            WorkShiftNameName = context.WorkShiftNames.Find("Legend").WorkShiftNameName,
            //            StartEndTime = context.Times.Find("12-17").StartEndTime,
            //            ShiftName = context.TypeOfShifts.Find("CallBack").ShiftName,
            //            Name = context.Persons.Find("David Welin").Name,
            //            DateID = context.WorkDays.Find(3).DateID }
            //};

            //        workShifts.ForEach(s => context.WorkShifts.Add(s));

            //        context.SaveChanges();
            //    }
        }
    }
}