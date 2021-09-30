using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace EmployeeManager.Database
{
    public class Employee : IAuditable
    {
        public int EmployeeID { get; set; }
        public string FirstName {get; set; }
        
        public string LastName { get; set; }

        public string ProfilePhotoPath { get; set; }
        //public byte[] Slika { get; set; }
        //public string PictureName { get; set; }
        //public string PicturePath { get; set; }

        public int UserID { get; set; }
        public IdentityUser<int> User { get; set; }

        public DateTime DateEmployment { get; set; }
        public string Skils { get; set; }
        public string Gender { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedDate { get ; set ; }
        public int CreatedUserId { get; set; }
        public IdentityUser<int> CreatedUser { get; set; }
        public DateTime? ModifiedDate { get; set ; }
        public int? ModifiedUserId { get ; set ; }
        public IdentityUser<int> ModifiedUser { get; set; }
        public DateTime? DeletedDate { get ; set; }
        public int? DeletedUserId { get ; set; }
        public IdentityUser<int> DeletedUser { get; set; }

        public ICollection<EmployeeTeam> EmployeeTeams { get; set; }
    }
}
