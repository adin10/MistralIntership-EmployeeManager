import { EmployeeTeam } from "./employeeTeam.model";
import { ProjectTeam } from "./projectTeam.model";

export class Tracking{
    constructor(public trackingID:number,public employeeTeamID:number,
        public employeeTeam:EmployeeTeam,public projectTeamID:number,
        public projectTeam:ProjectTeam,public description:string,
        public date:Date,public workHours:number){}
}