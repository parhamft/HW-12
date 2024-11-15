using HW_12.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_12.Contracts
{
    public interface IAuthentication
    {
        public User Login(string username, string password);

        public string Register(string username, string password);
    }
}
