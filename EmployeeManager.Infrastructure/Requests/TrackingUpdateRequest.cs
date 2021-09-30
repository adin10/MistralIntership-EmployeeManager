using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManager.Infrastructure.Requests
{
   public class TrackingUpdateRequest
    {
        public int EmployeeTeamID { get; set; }
        public int ProjectTeamID { get; set; }
        public DateTime Date { get; set; }
        public int WorkHours { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int ModifiedUserId { get; set; }
    }
}
