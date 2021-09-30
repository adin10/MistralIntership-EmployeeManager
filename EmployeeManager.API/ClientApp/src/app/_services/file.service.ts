import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";


@Injectable({providedIn:'root'})
export class FileService{
    constructor(private http: HttpClient){}

    uploadFile(file: File){
        var formData = new FormData();
        formData.append('file', file, file.name);
        return this.http.post<any>('https://localhost:5001/api/Image', formData);
    }
}
