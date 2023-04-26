import { Component, OnInit } from '@angular/core';
import {Loan} from '../models/loanmodel';
import {LoanService} from '../services/loan.service';
import {SharedService} from '../services/shared.service';

@Component({
  selector: 'app-loan',
  templateUrl: './loan.component.html',
  styleUrls: ['./loan.component.css']
})
export class LoanComponent {
  loanRequest:Loan=
  {
    CustomerId:'',
    AccountNo:'',
    Amount:'',
    DurationInMonths:''
  };
  uname:string='';
  loandtllst:any=[];

  ngOnInit():void
  {
     this.uname=this.shared.getUsername();
     this.loandtllst=this.getLoanStatus();
  }

  constructor(private loanservice:LoanService, private shared:SharedService){}

  getLoanStatus()
  {
    this.loanservice.getLoanStatus(this.uname).subscribe(data =>
      {
         console.log(data);
         if(data!=null)
         {
          this.loandtllst=data;
         }
      }
    )
      
  }

  applyForLoan()
  {
    console.log(this.loanRequest);
    this.loanservice.applyForLoan(this.loanRequest).subscribe(data =>
      {
          console.log(data);
          if(data==true)
          {
            window.alert("Applied for loan successfully");
            window.location.reload()
          }
          else
          {
            window.alert("Something went wrong, try again after some time");
          }
      });
  }

  getCard(data:any)
  {
    if(data==1)
    {
        console.log("clicked!!");
        const card = <HTMLElement>document.getElementById("popUp_checkloanstatus");
        card.classList.add("getCard");
    }
    else
    {
        const card = <HTMLElement>document.getElementById("popUp_loanapplication");
        card.classList.add("getCard");
    }
  }

  removeCard(data:any)
  {
    if(data==1)
    {
      console.log("clicked");
      const card=<HTMLElement>document.getElementById("popUp_checkloanstatus");
      card.classList.remove("getCard");
    }
    else
    {
      const card=<HTMLElement>document.getElementById("popUp_loanapplication");
      card.classList.remove("getCard");
    }
  }

}
