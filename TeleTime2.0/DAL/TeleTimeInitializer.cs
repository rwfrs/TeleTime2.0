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
            // Creating dummy data to test out the database

            // TODO - Should we try to create events that are ready here..

            

            // TIME
            var times = new List<Time>
            {
                new Time { StartEndTime = "08-12" },
                new Time { StartEndTime = "12-17" }
            };

            times.ForEach(s => context.Times.Add(s));
            // context.SaveChanges();

            // TYPEOFSHIFT
            var typeOfShifts = new List<TypeOfShift>
            {
                new TypeOfShift { ShiftName = "Front" },
                new TypeOfShift { ShiftName = "Back" },
                new TypeOfShift { ShiftName = "CallBack" },
            };

            typeOfShifts.ForEach(s => context.TypeOfShifts.Add(s));
            // context.SaveChanges();

            // PERSON
            var persons = new List<Person>
            {
                new Person { Name = "David Welin", EMail = "david@mail.com" },
                new Person { Name = "Pelle Anka", EMail = "pelle@mail.com" },
                new Person { Name = "Kalle Kråka", EMail = "kalle@mail.com" },
                new Person { Name = "Nisse Naprapat", EMail = "nisse@mail.com" },
                new Person { Name = "Rille Rille", EMail = "rille@mail.com" },
                new Person { Name = "Olle Olsson", EMail = "olle@mail.com" }
            };

            persons.ForEach(s => context.Persons.Add(s));
            // context.SaveChanges();

            // WORKSHIFTNAME
            var workShiftNames = new List<WorkShiftName>
            {
                new WorkShiftName { WorkShiftNameName = "Standard" },
                new WorkShiftName { WorkShiftNameName = "Legend" }
            };

            workShiftNames.ForEach(s => context.WorkShiftNames.Add(s));
            // context.SaveChanges();

            DateTime date = new DateTime();
            

            // EVENT

            //var events = new List<Event>
            //{
            //    new Event { start_date=date, end_date=date.AddHours(2), text="Text" }
            //};

            //events.ForEach(s => context.Events.Add(s));

            context.SaveChanges();

            DateTime toDay = DateTime.Now;

            List<WorkShift> workShifts = new List<WorkShift>
            { 
            // Idag
            new WorkShift {
                WorkShiftNameName = context.WorkShiftNames.Find("Standard").WorkShiftNameName,
                StartEndTime = context.Times.Find("08-12").StartEndTime,
                ShiftName = context.TypeOfShifts.Find("Front").ShiftName,
                Name = context.Persons.Find("David Welin").Name,
                Date = toDay },
            new WorkShift {
                WorkShiftNameName = context.WorkShiftNames.Find("Standard").WorkShiftNameName,
                StartEndTime = context.Times.Find("08-12").StartEndTime,
                ShiftName = context.TypeOfShifts.Find("Back").ShiftName,
                Name = context.Persons.Find("Pelle Anka").Name,
                Date = toDay },
            new WorkShift {
                WorkShiftNameName = context.WorkShiftNames.Find("Standard").WorkShiftNameName,
                StartEndTime = context.Times.Find("08-12").StartEndTime,
                ShiftName = context.TypeOfShifts.Find("CallBack").ShiftName,
                Name = context.Persons.Find("Kalle Kråka").Name,
                Date = toDay },
            new WorkShift {
                WorkShiftNameName = context.WorkShiftNames.Find("Standard").WorkShiftNameName,
                StartEndTime = context.Times.Find("12-17").StartEndTime,
                ShiftName = context.TypeOfShifts.Find("Front").ShiftName,
                Name = context.Persons.Find("Nisse Naprapat").Name,
                Date = toDay },
            new WorkShift {
                WorkShiftNameName = context.WorkShiftNames.Find("Standard").WorkShiftNameName,
                StartEndTime = context.Times.Find("12-17").StartEndTime,
                ShiftName = context.TypeOfShifts.Find("Back").ShiftName,
                Name = context.Persons.Find("Rille Rille").Name,
                Date = toDay },
            new WorkShift {
                WorkShiftNameName = context.WorkShiftNames.Find("Standard").WorkShiftNameName,
                StartEndTime = context.Times.Find("12-17").StartEndTime,
                ShiftName = context.TypeOfShifts.Find("CallBack").ShiftName,
                Name = context.Persons.Find("Olle Olsson").Name,
                Date = toDay },
            // Imorgon
            new WorkShift {
                WorkShiftNameName = context.WorkShiftNames.Find("Legend").WorkShiftNameName,
                StartEndTime = context.Times.Find("08-12").StartEndTime,
                ShiftName = context.TypeOfShifts.Find("Front").ShiftName,
                Name = context.Persons.Find("Olle Olsson").Name,
                Date = toDay.AddDays(1) },
            new WorkShift {
                WorkShiftNameName = context.WorkShiftNames.Find("Legend").WorkShiftNameName,
                StartEndTime = context.Times.Find("08-12").StartEndTime,
                ShiftName = context.TypeOfShifts.Find("Back").ShiftName,
                Name = context.Persons.Find("Nisse Naprapat").Name,
                Date = toDay.AddDays(1) },
            new WorkShift {
                WorkShiftNameName = context.WorkShiftNames.Find("Legend").WorkShiftNameName,
                StartEndTime = context.Times.Find("08-12").StartEndTime,
                ShiftName = context.TypeOfShifts.Find("CallBack").ShiftName,
                Name = context.Persons.Find("Kalle Kråka").Name,
                Date = toDay.AddDays(1) },
            new WorkShift {
                WorkShiftNameName = context.WorkShiftNames.Find("Legend").WorkShiftNameName,
                StartEndTime = context.Times.Find("12-17").StartEndTime,
                ShiftName = context.TypeOfShifts.Find("Front").ShiftName,
                Name = context.Persons.Find("Pelle Anka").Name,
                Date = toDay.AddDays(1) },
            new WorkShift {
                WorkShiftNameName = context.WorkShiftNames.Find("Legend").WorkShiftNameName,
                StartEndTime = context.Times.Find("12-17").StartEndTime,
                ShiftName = context.TypeOfShifts.Find("Back").ShiftName,
                Name = context.Persons.Find("David Welin").Name,
                Date = toDay.AddDays(1) },
            new WorkShift {
                WorkShiftNameName = context.WorkShiftNames.Find("Legend").WorkShiftNameName,
                StartEndTime = context.Times.Find("12-17").StartEndTime,
                ShiftName = context.TypeOfShifts.Find("CallBack").ShiftName,
                Name = context.Persons.Find("David Welin").Name,
                Date = toDay.AddDays(1) },
            // Övermorgon
            new WorkShift {
                WorkShiftNameName = context.WorkShiftNames.Find("Legend").WorkShiftNameName,
                StartEndTime = context.Times.Find("08-12").StartEndTime,
                ShiftName = context.TypeOfShifts.Find("Front").ShiftName,
                Name = context.Persons.Find("Olle Olsson").Name,
                Date = toDay.AddDays(2) },
            new WorkShift {
                WorkShiftNameName = context.WorkShiftNames.Find("Legend").WorkShiftNameName,
                StartEndTime = context.Times.Find("08-12").StartEndTime,
                ShiftName = context.TypeOfShifts.Find("Back").ShiftName,
                Name = context.Persons.Find("Nisse Naprapat").Name,
                Date = toDay.AddDays(2) },
            new WorkShift {
                WorkShiftNameName = context.WorkShiftNames.Find("Legend").WorkShiftNameName,
                StartEndTime = context.Times.Find("08-12").StartEndTime,
                ShiftName = context.TypeOfShifts.Find("CallBack").ShiftName,
                Name = context.Persons.Find("Kalle Kråka").Name,
                Date = toDay.AddDays(2) },
            new WorkShift {
                WorkShiftNameName = context.WorkShiftNames.Find("Legend").WorkShiftNameName,
                StartEndTime = context.Times.Find("12-17").StartEndTime,
                ShiftName = context.TypeOfShifts.Find("Front").ShiftName,
                Name = context.Persons.Find("Pelle Anka").Name,
                Date = toDay.AddDays(2) },
            new WorkShift {
                WorkShiftNameName = context.WorkShiftNames.Find("Legend").WorkShiftNameName,
                StartEndTime = context.Times.Find("12-17").StartEndTime,
                ShiftName = context.TypeOfShifts.Find("Back").ShiftName,
                Name = context.Persons.Find("David Welin").Name,
                Date = toDay.AddDays(2) },
            new WorkShift {
                WorkShiftNameName = context.WorkShiftNames.Find("Legend").WorkShiftNameName,
                StartEndTime = context.Times.Find("12-17").StartEndTime,
                ShiftName = context.TypeOfShifts.Find("CallBack").ShiftName,
                Name = context.Persons.Find("David Welin").Name,
                Date = toDay.AddDays(2) }
    };

            workShifts.ForEach(s => context.WorkShifts.Add(s));

            context.SaveChanges();
        }
    }
}