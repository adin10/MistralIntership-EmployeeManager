import { EmployeeTeam } from "./employeeTeam.model";
import { UserModel } from "./userModel.model";


export class Employee{
    constructor(public employeeID:number,
                public firstName:string,
                public lastName:string,
                public dateEmployment:Date,
                public skils:string,
                public gender:string,
                public ProfilePhotoPath:string,
                public active:boolean,
                public user:UserModel,
                public employeeTeams:EmployeeTeam[]
        ){}
}




// public int EmployeeID{ get; set; }
// public string FirstName {get; set; }
// public string LastName { get; set; }

// public int UserID { get; set; }
// public IdentityUser<int> User { get; set; }

// public DateTime DateEmployment { get; set; }
// public string Skils { get; set; }
// public string Gender { get; set; }
// public bool Active { get; set; }
// public DateTime CreatedDate { get ; set ; }
// public int CreatedUserId { get; set; }
// public IdentityUser<int> CreatedUser { get; set; }
// public DateTime? ModifiedDate { get; set ; }
// public int? ModifiedUserId { get ; set ; }
// public IdentityUser<int> ModifiedUser { get; set; }
// public DateTime? DeletedDate { get ; set; }
// public int? DeletedUserId { get ; set; }
// public IdentityUser<int> DeletedUser { get; set; }