using HW_12.Contracts;
using HW_12.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_12.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDBContext _dbContext = new AppDBContext();
        public List<User> GetAllUsers()
        {
            return _dbContext.Users.ToList();
        }

        public User GetByUserName(string Username)
        {
            User user = _dbContext.Users.FirstOrDefault(x => x.UserName == Username);
            if (user == null) { throw new Exception("User does not exist"); }
            return user;
        }
        public void AddUser(User user)
        {
            if (_dbContext.Users.FirstOrDefault(x => x.UserName == user.UserName) != null ) { throw new Exception("Username already exists"); }
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
        }
    }
}
