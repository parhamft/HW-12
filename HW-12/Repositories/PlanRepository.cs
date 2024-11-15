using HW_12.Contracts;
using HW_12.Entities;
using HW_12.Migrations;
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
        public void ChangeStatus(int id, int status, int userId)
        {
            Plans plan=_dbContext.plans.Where(x => x.UserId == userId).FirstOrDefault(x=> x.Id==id);
            if (plan==null ) { throw new Exception("item does not exist"); }
            plan.StatusId = status;
            _dbContext.SaveChanges();
        }
        public void RemoveTask(int id, int userId)
        {
            Plans plan =_dbContext.plans.Where(x => x.UserId == userId).FirstOrDefault(x=> x.Id ==id);
            if (plan == null) { throw new Exception("item does not exist"); }
            _dbContext.plans.Remove(plan);
            _dbContext.SaveChanges();
        }
        public List<Plans> Search(string title,int userId)
        {
            return _dbContext.plans.Where(x=> x.UserId== userId && x.Title.Contains (title)).ToList();
            
        }
        public void UpdateTask(int id, Plans p, int userId)
        {
            Plans plan = _dbContext.plans.Where(x => x.UserId == userId).FirstOrDefault(x => x.Id == id);
            if (plan == null) { throw new Exception("item does not exist"); }
            plan.Title=p.Title;
            plan.Description=p.Description;
            plan.Date=p.Date;
            plan.StatusId=p.StatusId;
            plan.PriorityId=p.PriorityId;
            _dbContext.SaveChanges();
        }
        public List<Plans> ViewAll(int userId)
        {
            List<Plans> plans = _dbContext.plans.Where(x => x.UserId == userId).OrderByDescending(x => x.PriorityId).ToList();
            if (plans == null) { throw new Exception("data base is empty"); }

            return plans;
        }
        public Plans GetById(int id, int userId)
        {
            Plans plan = _dbContext.plans.Where(x => x.UserId == userId).FirstOrDefault(x => x.Id == id);
            if (plan==null) { throw new Exception("item does not exist"); }
            return plan;
        }
    }
}
