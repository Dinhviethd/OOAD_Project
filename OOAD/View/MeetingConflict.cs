using System;
using System.Collections.Generic;
using System.Data.Entity; // Quan trọng để dùng Include()
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using OOAD.Service;
using OOAD.View;

namespace OOAD
{
    public partial class MeetingConflict : Form
    {
        private GroupMeeting existingMeeting;
        private User currentUser;
        private GroupMeetingService groupService;

        public MeetingConflict(GroupMeeting conflictMeeting, User user, GroupMeetingService service)
        {
            InitializeComponent();
            existingMeeting = conflictMeeting;
            currentUser = user;
            groupService = service;
        }

        private void bJoin_Click(object sender, EventArgs e)
        {
            using (var db = new Model1())
            {
                var userFromDb = db.Users.Find(currentUser.ID_User);
                var meetingFromDb = db.GroupMeetings
                    .Include("Participants")
                    .FirstOrDefault(g => g.ID_Group == existingMeeting.ID_Group);

                if (userFromDb != null && meetingFromDb != null &&
                    !meetingFromDb.Participants.Any(p => p.ID_User == userFromDb.ID_User))
                {
                    meetingFromDb.Participants.Add(userFromDb);
                    db.SaveChanges();

                    MessageBox.Show("Bạn đã tham gia cuộc họp!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void bCreate_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void MeetingConflict_Load(object sender, EventArgs e)
        {
            var box = new UserControlBox();
            box.SetData(existingMeeting.Name, existingMeeting.Location, existingMeeting.StartTime, existingMeeting.EndTime, "Group Meeting");
            box.BackColor = ColorTranslator.FromHtml("#FDF6E3");
            box.Dock = DockStyle.Fill;

            panel1.Controls.Clear();
            panel1.Controls.Add(box);
        }
    }
}
