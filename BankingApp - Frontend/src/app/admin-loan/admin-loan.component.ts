import { Component, OnInit } from '@angular/core';
import {SharedService} from '../services/shared.service';
import {LoanService} from '../services/loan.service';


@Component({
  selector: 'app-admin-loan',
  templateUrl: './admin-loan.component.html',
  styleUrls: ['./admin-loan.component.css']
})
export class AdminLoanComponent {

  uname:string='';
  loandtllst:any=[];

  constructor(private shared:SharedService, private loanService:LoanService){}

  ngOnInit():void
  {
     this.uname=this.shared.getUsername();
     this.loandtllst=this.getLoanDetails();
  }

  getLoanDetails()
  {
      this.loanService.loanDetails().subscribe(data =>
      {
        this.loandtllst=data;
        console.log(data);
      }   
    );
  }

  approveloan(loanId:number)
  {
    console.log(loanId);
    this.loanService.approveLoan(loanId).subscribe(data =>
      {
        console.log(data);
        let status=data;
        if(status==true)
        {
           window.alert("Loan is approved");
        }
        else if(status==false)
        {
          window.alert("Loan is already approved");
        }
        else
        {
          window.alert("Cannot approve loan");
        }
      })

  }

  

}
