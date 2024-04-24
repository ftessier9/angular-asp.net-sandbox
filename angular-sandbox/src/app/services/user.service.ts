import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { catchError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(public http: HttpClient) { }

  getUserInfoById(userId: string){
    return this.http.get('https://localhost:7268/api/v1/User/' + userId)
  }

  createUser(body: any) {
    return this.http.post('https://localhost:7268/api/v1/User/', body)
  }
}
