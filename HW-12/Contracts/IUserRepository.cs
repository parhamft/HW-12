using HW_12.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_12.Contracts
{
    public interface IUserRepository
    {
        public List<User> GetAllUsers();

        public User GetByUserName(string Username);
        public void AddUser(User user);

    }
}
