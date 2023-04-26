import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';
import { Login } from './models/loginmodel';
import { BehaviorSubject } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class LoginService {

  baseUrl:string="http://localhost:26534";

  constructor( private obj:HttpClient) {}

  loginUser(loginRequest:Login):Observable<Login>{
    return this.obj.post<Login>(this.baseUrl+'/ValidateUser',loginRequest);
  }
  
}
