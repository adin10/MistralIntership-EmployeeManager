import { Employee } from "../employee.model";

export class AuthenticationResult{
    constructor(public token:string,public expiration:Date,public user:string,public employee:Employee){}
}