using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManager.API.Models
{
    public class ProjectRestUpsertModel
    {
        public string ProjectName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }

        public List<ProjectTeamRestUpsertModel> Teams { get; set; }

    }
}
