using System;
using System.Collections.Generic;
using System.Linq;

namespace OOAD
{
    public static class SeedData
    {
        public static void Initialize(Model1 context)
        {
            // Tránh seed nhiều lần
            if (context.Users.Any()) return;

            // === 1. Tạo Users ===
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
            context.SaveChanges(); // Lưu trước để user có ID

            // === 2. Tạo GroupMeeting ===
            var groupMeeting = new GroupMeeting
            {
                Name = "Project Kickoff",
                Location = "Meeting Room 1",
                StartTime = DateTime.Now.AddDays(1).AddHours(9),
                EndTime = DateTime.Now.AddDays(1).AddHours(10),
                Participants = new List<User> { user1, user2 }
            };
            context.GroupMeetings.Add(groupMeeting);

            // === 3. Tạo Appointments ===
            var appointment1 = new Appoinment
            {
                Name = "Doctor Visit",
                Location = "Clinic",
                StartTime = DateTime.Now.AddHours(2),
                EndTime = DateTime.Now.AddHours(3),
                UserID = user1.ID_User
            };
            context.Appointments.Add(appointment1);

            // === 4. Tạo Reminders ===
            var reminder1 = new Reminder
            {
                Time = DateTime.Now.AddHours(1),
                Message = "Prepare for doctor visit",
                UserID = user1.ID_User
            };
            context.Reminders.Add(reminder1);

            context.SaveChanges();
        }
    }
}
