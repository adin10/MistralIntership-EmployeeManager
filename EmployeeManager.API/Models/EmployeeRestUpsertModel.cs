using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManager.API.Models
{
    public class EmployeeRestUpsertModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateEmployment { get; set; }
        public string Skils { get; set; }
        public string Gender { get; set; }
        public bool Active { get; set; }
        //[Url]
        //public string PhotoPath { get; set; }
        public UserUpsertRestModel User { get; set; }
        public List<EmployeeTeamRestUpsertModel> Teams { get; set; }
    }
}
