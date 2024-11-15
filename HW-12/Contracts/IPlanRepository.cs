using HW_12.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_12.Contracts
{
    public interface IPlanRepository
    {
        public void AddTask(Plans p);
        public void ChangeStatus(int id, int status, int userId);
        public void RemoveTask(int id, int userId);
        public List<Plans> Search(string title, int userId);
        public void UpdateTask(int id, Plans p, int userId);
        public List<Plans> ViewAll(int userId);
        public Plans GetById(int id, int userId);

    }
}
