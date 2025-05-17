// --- START OF FILE SeedData.cs ---

using System;
using System.Collections.Generic;
using System.Linq;
// using Microsoft.EntityFrameworkCore; // Nếu dùng EF Core
// using System.Data.Entity; // Nếu dùng EF6 (đã có trong code gốc của bạn)

namespace OOAD
{
    public static class SeedData
    {
        public static void Initialize(Model1 context)
        {
            // === 1. Tạo Users (nếu chưa tồn tại) ===
            User user1 = context.Users.FirstOrDefault(u => u.Username == "alice");
            if (user1 == null)
            {
                user1 = new User
                {
                    Name = "Alice",
                    Username = "alice",
                    Password = "password1", // Trong ứng dụng thực tế, hãy băm mật khẩu
                    EmailAddress = "alice@example.com"
                };
                context.Users.Add(user1);
            }

            User user2 = context.Users.FirstOrDefault(u => u.Username == "bob");
            if (user2 == null)
            {
                user2 = new User
                {
                    Name = "Bob",
                    Username = "bob",
                    Password = "password2", // Băm mật khẩu
                    EmailAddress = "bob@example.com"
                };
                context.Users.Add(user2);
            }
            // Lưu thay đổi ngay sau khi thêm user để đảm bảo các ID được tạo ra
            // nếu user1 hoặc user2 vừa được thêm mới.
            // Nếu không có thay đổi nào (user đã tồn tại), SaveChanges() sẽ không làm gì.
            context.SaveChanges();

            // Lấy lại user từ context để đảm bảo rằng các đối tượng user1, user2
            // là các đối tượng được theo dõi bởi context và có ID chính xác.
            // Điều này quan trọng nếu bạn định sử dụng chúng để tạo các thực thể phụ thuộc.
            user1 = context.Users.Single(u => u.Username == "alice"); // Dùng Single vì ta kỳ vọng nó phải tồn tại
            user2 = context.Users.Single(u => u.Username == "bob");

            // === 2. Tạo GroupMeeting (nếu chưa tồn tại và user1, user2 đã có) ===
            if (!context.GroupMeetings.Any(g => g.Name == "Project Kickoff"))
            {
                var groupMeeting = new GroupMeeting
                {
                    Name = "Project Kickoff",
                    Location = "Meeting Room 1",
                    StartTime = DateTime.Now.AddDays(1).AddHours(9),
                    EndTime = DateTime.Now.AddDays(1).AddHours(10),
                    // Đảm bảo user1 và user2 không null và có ID hợp lệ
                    Participants = new List<User> { user1, user2 }
                };
                context.GroupMeetings.Add(groupMeeting);
            }

            // === 3. Tạo Appointments (nếu chưa tồn tại và user1 đã có) ===
            // Giả sử Appointment cho user1 với tên "Doctor Visit" là duy nhất để kiểm tra
            Appoinment appointment1 = context.Appointments
                                       .FirstOrDefault(a => a.UserID == user1.ID_User && a.Name == "Doctor Visit");
            if (appointment1 == null)
            {
                appointment1 = new Appoinment
                {
                    Name = "Doctor Visit",
                    Location = "Clinic",
                    StartTime = DateTime.Now.AddHours(2),
                    EndTime = DateTime.Now.AddHours(3),
                    UserID = user1.ID_User
                };
                context.Appointments.Add(appointment1);
                context.SaveChanges(); // Lưu appointment để có ID cho reminder
                // Lấy lại appointment1 để đảm bảo có ID chính xác
                appointment1 = context.Appointments.Single(a => a.UserID == user1.ID_User && a.Name == "Doctor Visit");
            }


            // === 4. Tạo Reminders (nếu chưa tồn tại và appointment1 đã có) ===
            if (appointment1 != null && !context.Reminders.Any(r => r.ID_Appointment == appointment1.ID_Appointment && r.Message == "Prepare for doctor visit"))
            {
                var reminder1 = new Reminder
                {
                    Time = DateTime.Now.AddHours(1),
                    Message = "Prepare for doctor visit",
                    ID_Appointment = appointment1.ID_Appointment
                };
                context.Reminders.Add(reminder1);
            }

            context.SaveChanges(); // Lưu tất cả các thay đổi còn lại
        }
    }
}