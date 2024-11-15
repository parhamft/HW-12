using HW_12.Entities;
using HW_12.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_12.Contracts
{
    public interface IPlanService
    {
        public string NewPlan(string title, string description, DateOnly date, int priorityid, int statusid, int UserId);
        public string Delete(int planid, int userid);
        public string ChangeStatus(int planid, int statusid, int userid);
        public List<Plans> Search(string search, int userid);
        public List<Plans> GetAll(int userid);
        public string Update(int Id, int op, string New, int userid);
    }
}
