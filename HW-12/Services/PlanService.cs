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
        public string NewPlan(string title, string description, DateOnly date,int priorityid, int statusid )
        {
            repo.AddTask(new Plans(title, description, date, priorityid, statusid));
            return "plan added";
        }
        public string Delete(int planid)
        {
            repo.RemoveTask(planid);
            return "plan removed";
        }
        public string ChangeStatus(int planid, int statusid) 
        {
            repo.ChangeStatus(planid, statusid);
            return "status changed";
        }
        public List<Plans> Search(string search)
        { return repo.Search(search); }
        public List<Plans> GetAll()
        {
            if (repo.ViewAll()==null) { throw new Exception("data base is epty"); }
            return repo.ViewAll();
        }
        public string Update(int Id, int op, string New)
        {
            Plans plan = repo.GetById(Id);
            switch (op)
            {
                case 1:

                    plan.Title = New;
                    repo.UpdateTask(Id, plan);
                    break;


                case 2:
                    plan.Description = New;
                    repo.UpdateTask(Id, plan);

                    break;
                case 3:
                    plan.Date = DateOnly.Parse(New);
                    repo.UpdateTask(Id, plan);
                    break;
                case 4:
                    plan.PriorityId = Convert.ToInt32(New);
                    repo.UpdateTask(Id, plan);
                    break;
             
            }
            return "plan Updated";
        }
    }
}
