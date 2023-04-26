import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { Observable } from 'rxjs';
import { Login } from '../models/loginmodel';

@Injectable({
  providedIn: 'root'
})
export class AcctDetailsService {
  baseUrl:string='http://localhost:26534/';


  constructor(private obj:HttpClient) { }

  verifyNewPassword(pwdchangeRequest:Login):Observable<Login>
  {
    return this.obj.post<Login>(this.baseUrl+'ChangePassword',pwdchangeRequest)
  }

  getUserDetails(username:string)
  {
    return this.obj.get(this.baseUrl+'GetUserDetails/'+username);
  }

  AccountSummary(username:any)
  {
    return this.obj.get(this.baseUrl+'AccountSummary/'+username);
  }

  RecentFiveTransactions(username:any)
  {
    return this.obj.get(this.baseUrl+'RecentTransactions/'+username);
  }

  
}



