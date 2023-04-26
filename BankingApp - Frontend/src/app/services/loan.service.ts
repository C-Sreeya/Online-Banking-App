import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Loan} from '../models/loanmodel';

@Injectable({
  providedIn: 'root'
})
export class LoanService {

  baseUrl:string='http://localhost:26534/';

  constructor(private obj:HttpClient) { }

  loanDetails()
  {
     return this.obj.get(this.baseUrl+'DisplayAllLoans');
  }

  approveLoan(loanId:any)
  {
    return this.obj.get(this.baseUrl+'ApproveLoan/'+loanId);
  }

  applyForLoan(loanRequest:Loan)
  {
    return this.obj.post(this.baseUrl+'ApplyForLoan',loanRequest);
  }

  getLoanStatus(username:any)
  {
    return this.obj.get(this.baseUrl+'GetLoanStatus/'+username);
  }


}
