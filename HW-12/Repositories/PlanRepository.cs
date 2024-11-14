using HW_12.Contracts;
using HW_12.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_12.Repositories
{
    public class PlanRepository : IPlanRepository
    {
        private readonly AppDBContext _dbContext =new AppDBContext();

        public void AddTask(Plans p)
        {
            _dbContext.plans.Add(p);
            _dbContext.SaveChanges();
        }

        public void ChangeStatus(int id, int status)
        {
            Plans plan=_dbContext.plans.FirstOrDefault(x=> x.Id==id);
            if (plan==null ) { throw new Exception("item does not exist"); }
            plan.StatusId = status;
            _dbContext.SaveChanges();
        }

        public void RemoveTask(int id)
        {
            Plans plan =_dbContext.plans.FirstOrDefault(x=> x.Id ==id);
            if (plan == null) { throw new Exception("item does not exist"); }
            _dbContext.plans.Remove(plan);
            _dbContext.SaveChanges();
        }

        public List<Plans> Search(string title)
        {
            return _dbContext.plans.Where(x=>x.Title.Contains (title)).ToList();
            
        }

        public void UpdateTask(int id, Plans p)
        {
            Plans plan = _dbContext.plans.FirstOrDefault(x => x.Id == id);
            if (plan == null) { throw new Exception("item does not exist"); }
            plan.Title=p.Title;
            plan.Description=p.Description;
            plan.Date=p.Date;
            plan.StatusId=p.StatusId;
            plan.PriorityId=p.PriorityId;
            _dbContext.SaveChanges();
        }

        public List<Plans> ViewAll()
        {
            if (_dbContext.plans.ToList() == null) { throw new Exception("data base is empty"); }
            return _dbContext.plans.OrderByDescending(x=> x.PriorityId).ToList();
        }
        public Plans GetById(int id)
        {
            Plans plan = _dbContext.plans.FirstOrDefault(x => x.Id == id);
            if (plan==null) { throw new Exception("item does not exist"); }
            return plan;
        }
    }
}
