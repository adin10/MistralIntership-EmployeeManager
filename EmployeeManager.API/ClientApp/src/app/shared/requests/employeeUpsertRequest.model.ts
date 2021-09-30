import { Team } from "../team.model";
import { UserInsertRequest } from "./UserInsertRequest.model";
import { UserUpdateRequest } from "./UserUpdateRequest.model";
export class EmployeeInsertRequest{
    constructor(public FirstName:string,public LastName:string,
         public DateEmployment:Date,public Skils:string,
         public Gender:string,public Active:boolean, public user:UserInsertRequest,public teams:Team[]
        //  public photoPath: string
        )
        {}
}
export class EmployeeUpdateRequest{
    constructor(public FirstName:string,public LastName:string,
        public DateEmployment:Date,public Skils:string,
        public Gender:string,public Active:boolean,public user:UserUpdateRequest,public teams: Team[]){}
}




// Employee

// public string FirstName { get; set; }
// public string LastName { get; set; }
// public DateTime DateEmployment { get; set; }
// public string Skils { get; set; }
// public string Gender { get; set; }
// public bool Active { get; set; }



// User
// Email: ["",Validators.required],
// Username:["",[Validators.required]],
// Password:["",[Validators.required]],
// ConfirmationPassword:["",Validators.required].