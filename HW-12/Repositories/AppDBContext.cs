using HW_12.Entities;
using HW_12.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_12.Repositories
{
    public class AppDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = DESKTOP-03R7JG5\\SQLEXPRESS; Database=ToDoList;Trusted_Connection=True;TrustServerCertificate=True;");
            base.OnConfiguring(optionsBuilder);
        }

        
        public DbSet<Status> statuses { get; set; }
        public DbSet<Priority> Priorities { get; set; }
        public DbSet<Entities.Plans> plans { get; set; }
        public DbSet<User> Users { get; set; }


    }
}
