using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManager.Infrastructure.Requests
{
   public class TrackingInsertRequest
    {
        public int EmployeeTeamID { get; set; }
        public int ProjectTeamID { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public int WorkHours { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedUserId { get; set; }
    }
}
