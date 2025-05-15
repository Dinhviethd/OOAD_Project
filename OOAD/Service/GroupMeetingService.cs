using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOAD.Service
{
    public class GroupMeetingService
    {
        private readonly Model1 _context;

        public GroupMeetingService(Model1 context)
        {
            _context = context;
        }

        public List<GroupMeeting> GetAllGroups()
        {
            return _context.GroupMeetings
                .Include(g => g.Participants)
                .ToList();
        }

        public void AddGroup(GroupMeeting group)
        {
            _context.GroupMeetings.Add(group);
            
            _context.SaveChanges();
        }

        public void UpdateGroup(GroupMeeting group)
        {
            _context.GroupMeetings.Attach(group);
            _context.Entry(group).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteGroup(int id)
        {
            var group = _context.GroupMeetings.Find(id);
            if (group != null)
            {
                _context.GroupMeetings.Remove(group);
                _context.SaveChanges();
            }
        }
        public int GetGroupMeetingCountByUser(int userId)
        {
            return _context.GroupMeetings
                .Count(g => g.Participants.Any(u => u.ID_User == userId));
        }
        public List<GroupMeeting> GetGroupMeetingsByUser(int userId)
        {
            return _context.GroupMeetings
                .Include(g => g.Participants)
                .Where(g => g.Participants.Any(u => u.ID_User == userId))
                .ToList();
        }
    }

}
