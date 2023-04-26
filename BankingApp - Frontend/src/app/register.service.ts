import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http'
import { Register } from './models/registermodel';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RegisterService {
  baseUrl:string="http://localhost:26534";

  constructor(private obj:HttpClient) { }


  registerUser(registerRequest:Register):Observable<Register>{
    return this.obj.post<Register>(this.baseUrl+'/RegisterUser',registerRequest);
  }
}
