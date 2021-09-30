export class TrackingUpdateRequest{
    constructor(public EmployeeTeamID:number,public ProjectTeamID:number,public Description:string,public Date:Date,public WorkHours:number){}
}