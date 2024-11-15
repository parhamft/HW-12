using HW_12.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_12.Entities
{
    public class Plans
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public String Title { get; set; }
        [MaxLength(300)]
        public String? Description { get; set; }
        public DateOnly Date { get; set; }
        public int PriorityId { get; set; }
        public int StatusId { get; set; }
        public  int UserId{ get; set; }

        public Plans(string title, string description, DateOnly date, int PriorityId, int StatusId,int UserId)
        {
            Title = title;
            Description = description;
            Date = date;
            this.PriorityId = PriorityId;
            this.StatusId = StatusId;
            this.UserId= UserId;
        }
        public Plans()
        {
            
        }

    }
}
