using HW_12.Entities;
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
        public List<Plans> ViewAll();
        public void UpdateTask(int id, Plans p);
        public void RemoveTask(int id);
        public void ChangeStatus(int id, int status);
        public List<Plans> Search(string title);
        public Plans GetById(int id);

    }
}
