namespace OOAD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDB : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Reminders", name: "ID_AppointmentID", newName: "ID_Appointment");
            RenameIndex(table: "dbo.Reminders", name: "IX_ID_AppointmentID", newName: "IX_ID_Appointment");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Reminders", name: "IX_ID_Appointment", newName: "IX_ID_AppointmentID");
            RenameColumn(table: "dbo.Reminders", name: "ID_Appointment", newName: "ID_AppointmentID");
        }
    }
}
