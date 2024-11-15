using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_12.Entities
{
    public class User
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string UserName { get; set; }
        [MaxLength(50)]
        public string Password { get; set; }

        public User(string UserName,string password)
        {
            this.UserName = UserName;
            this.Password = password;
        }
        public User()
        {
            
        }
        public bool CheckPassword(string Password)
        {
            if (this.Password == Password) { return true; } else { return false; }
        }
    }                                                              
}
