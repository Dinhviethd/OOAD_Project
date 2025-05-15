using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OOAD.Service;
using OOAD.View;

namespace OOAD
{
    public partial class MeetingConflict: Form
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
            if (!existingMeeting.Participants.Any(p => p.ID_User == currentUser.ID_User))
            {
                existingMeeting.Participants.Add(currentUser);
                groupService.UpdateGroup(existingMeeting);
                MessageBox.Show("Bạn đã tham gia cuộc họp!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void bCreate_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
