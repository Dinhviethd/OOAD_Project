using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace OOAD
{
    public static class SeedData
    {
        public static void Initialize(Login context)
        {
            // Avoid duplicate seed
            if (context.Users.Any()) return;

            // Seed Users
            var user1 = new User
            {
                Name = "Alice",
                Username = "alice",
                Password = "password1",
                EmailAddress = "alice@example.com"
            };
            var user2 = new User
            {
                Name = "Bob",
                Username = "bob",
                Password = "password2",
                EmailAddress = "bob@example.com"
            };

            context.Users.Add(user1);
            context.Users.Add(user2);

            // Seed GroupMeeting
            var groupMeeting = new GroupMeeting
            {
                Name = "Project Kickoff",
                Participants = new List<User> { user1, user2 }
            };
            context.GroupMeetings.Add(groupMeeting);

            // Seed Appointments
            var appointment1 = new Appoinment
            {
                Name = "Doctor Visit",
                Location = "Clinic",
                StartTime = DateTime.Now.AddHours(2),
                EndTime = DateTime.Now.AddHours(3),
                UserID = user1.ID_User,
                User = user1
            };
            context.Appointments.Add(appointment1);

            // Seed Reminders
            var reminder1 = new Reminder
            {
                Time = DateTime.Now.AddHours(1),
                Message = "Prepare for doctor visit",
                UserID = user1.ID_User,
                User = user1
            };
            context.Reminders.Add(reminder1);

            context.SaveChanges();
        }
    }
}
