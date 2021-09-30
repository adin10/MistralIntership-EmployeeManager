using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManager.Infrastructure.Requests
{
    public class ProjectSearchRequest
    {

        public string ProjectName { get; set; }
        public DateTime? FinishDateStartRange { get; set; }
        public DateTime? FinishDateEndRange { get; set; }
    }
    
}
