using HW_12.Contracts;
using HW_12.Entities;
using HW_12.Repositories;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_12.Services
{
    public class PlanService : IPlanService
    {
        IPlanRepository repo = new PlanRepository();
        public string NewPlan(string title, string description, DateOnly date,int priorityid, int statusid ,int UserId)
        {
            repo.AddTask(new Plans(title, description, date, priorityid, statusid,UserId ));
            return "plan added";
        }
        public string Delete(int planid,int userid)
        {
            repo.RemoveTask(planid,userid);
            return "plan removed";
        }
        public string ChangeStatus(int planid, int statusid,int userid) 
        {
            repo.ChangeStatus(planid, statusid, userid);
            return "status changed";
        }
        public List<Plans> Search(string search,int userid)
        { return repo.Search(search,userid); }
        public List<Plans> GetAll(int userid)
        {
            if (repo.ViewAll(userid)==null) { throw new Exception("data base is empty"); }
            return repo.ViewAll(userid);
        }
        public string Update(int Id, int op, string New,int userid)
        {
            Plans plan = repo.GetById(Id, userid);
            switch (op)
            {
                case 1:

                    plan.Title = New;
                    repo.UpdateTask(Id, plan, userid);
                    break;


                case 2:
                    plan.Description = New;
                    repo.UpdateTask(Id, plan, userid);

                    break;
                case 3:
                    plan.Date = DateOnly.Parse(New);
                    repo.UpdateTask(Id, plan,userid);
                    break;
                case 4:
                    plan.PriorityId = Convert.ToInt32(New);
                    repo.UpdateTask(Id, plan, userid);
                    break;
             
            }
            return "plan Updated";
        }
    }
}
