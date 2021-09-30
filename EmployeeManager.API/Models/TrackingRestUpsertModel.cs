using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManager.API.Models
{
    public class TrackingRestUpsertModel
    {
        public int EmployeeTeamID { get; set; }
        public int ProjectTeamID { get; set; }
        public DateTime Date { get; set; }
        public int WorkHours { get; set; }
        public string Description { get; set; }
    }
}
