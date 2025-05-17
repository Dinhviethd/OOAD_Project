using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOAD.Service
{
    public class UserService
    {
        private readonly Model1 _context;

        public UserService(Model1 context)
        {
            _context = context;
        }

        public List<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public User GetUserById(int id)
        {
            return _context.Users.Find(id);
        }

        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            _context.Users.Attach(user);
            _context.Entry(user).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public void DeleteUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }
        public User Login(string username, string password)
        {
            return _context.Users
                .FirstOrDefault(u => u.Username == username && u.Password == password);
        }
        public bool Register(string name, string username, string password, string email)
        {
            if (_context.Users.Any(u => u.Username == username) || _context.Users.Any(u => u.EmailAddress == email))
                return false;

            var user = new User
            {
                Name = name,
                Username = username,
                Password = password,
                EmailAddress = email
            };

            _context.Users.Add(user);
            _context.SaveChanges();
            return true;
        }
    }
}
