using EmployeeManager.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManager.Infrastructure.Response
{
   public class TrackingResponse
    {
        public int TrackingID { get; set; }
        public int EmployeeTeamID { get; set; }
        public EmployeeTeam EmployeeTeam { get; set; }
        public int ProjectTeamID { get; set; }
        public ProjectTeam ProjectTeam { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int WorkHours { get; set; }
    }
}
