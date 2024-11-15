using HW_12.Contracts;
using HW_12.Entities;
using HW_12.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_12.Services
{
    public class Authentication : IAuthentication
    {
       IUserRepository repo=new UserRepository();
        public User Login(string username, string password)
        {
            User user = repo.GetByUserName(username);
            if (user.CheckPassword(password) == false) { throw new Exception("password incorrect"); }
            return user;
        }

        public string Register(string username, string password)
        {
            repo.AddUser(new User(username, password));
            return "User registered";
        }
    }
}
