namespace OOAD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Appoinments",
                c => new
                    {
                        ID_Appointment = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Location = c.String(),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID_Appointment)
                .ForeignKey("dbo.User", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        ID_User = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Username = c.String(),
                        Password = c.String(),
                        EmailAddress = c.String(),
                    })
                .PrimaryKey(t => t.ID_User);
            
            CreateTable(
                "dbo.GroupMeetings",
                c => new
                    {
                        ID_Group = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID_Group);
            
            CreateTable(
                "dbo.Reminders",
                c => new
                    {
                        ID_Reminder = c.Int(nullable: false, identity: true),
                        Time = c.DateTime(nullable: false),
                        Message = c.String(),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID_Reminder)
                .ForeignKey("dbo.User", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.GroupMeetingUsers",
                c => new
                    {
                        GroupMeeting_ID_Group = c.Int(nullable: false),
                        User_ID_User = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.GroupMeeting_ID_Group, t.User_ID_User })
                .ForeignKey("dbo.GroupMeetings", t => t.GroupMeeting_ID_Group, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.User_ID_User, cascadeDelete: true)
                .Index(t => t.GroupMeeting_ID_Group)
                .Index(t => t.User_ID_User);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Appoinments", "UserID", "dbo.User");
            DropForeignKey("dbo.Reminders", "UserID", "dbo.User");
            DropForeignKey("dbo.GroupMeetingUsers", "User_ID_User", "dbo.User");
            DropForeignKey("dbo.GroupMeetingUsers", "GroupMeeting_ID_Group", "dbo.GroupMeetings");
            DropIndex("dbo.GroupMeetingUsers", new[] { "User_ID_User" });
            DropIndex("dbo.GroupMeetingUsers", new[] { "GroupMeeting_ID_Group" });
            DropIndex("dbo.Reminders", new[] { "UserID" });
            DropIndex("dbo.Appoinments", new[] { "UserID" });
            DropTable("dbo.GroupMeetingUsers");
            DropTable("dbo.Reminders");
            DropTable("dbo.GroupMeetings");
            DropTable("dbo.User");
            DropTable("dbo.Appoinments");
        }
    }
}
