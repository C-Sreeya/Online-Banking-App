import { Component,OnInit } from '@angular/core';
import {AcctDetailsService} from '../services/acct-details.service';
import {HttpClient} from '@angular/common/http';
import {Login} from '../models/loginmodel';
import {SharedService} from '../services/shared.service';

@Component({
  selector: 'app-account-details',
  templateUrl: './account-details.component.html',
  styleUrls: ['./account-details.component.css']
})
export class AccountDetailsComponent 
{
  TransactionList: any;
  isVerified : any;

  pwdchangeRequest:Login={
    UserName:'',
    Password:''
  };

  ConfirmPassword:string=''

  uname:string='';
  pwd:string='';
  userdtl:any=[];
  oldpwd:string='';
  flag:number=0;

  actdtllst:any=[];
  balance:any='';

  translst:any=[];
  status:number=0;

  constructor(private actdelservice:AcctDetailsService, private shared:SharedService){}

  ngOnInit():void
  {
    this.uname=this.shared.getUsername();
    this.actdtllst=this.accountSummary();
  }


  getTransactionList()
  {
    console.log(this.uname);
    this.actdelservice.RecentFiveTransactions(this.uname).subscribe(
      {next:(user) =>
        {
          if(user)
          {
             console.log(user);
             this.translst=user;
          }
          else
          {
            window.alert("Something went wrong..");
          }
        },
        error: error =>
        {
          window.alert(error);
        }
    });
  }

  accountSummary()
  {
    console.log(this.uname);
    this.actdelservice.AccountSummary(this.uname).subscribe(
      {next:(user) =>
        {
          if(user)
          {
             console.log(user);
             this.actdtllst=user;
          }
          else
          {
            window.alert("Something went wrong..");
          }
        },
        error: error =>
        {
          window.alert(error);
        }
    });
  
  }

  checkBalance(bal:any)
  {
    this.balance=bal;
  }


  verifyOldPassword()
  {
    console.log(this.oldpwd);
    this.actdelservice.getUserDetails(this.uname).subscribe
        ({next:(user) =>
          {
            if(user)
            {
              this.userdtl=user;
              console.log(this.userdtl);
              this.pwd=this.userdtl.password;

              if(this.pwd == this.oldpwd)
              {
                 window.alert("Password is Verified");
                 this.verifyNewPassword();
              }
              else
              {
                window.alert("Old Password is wrong");
              }
            }
            else
            {
              window.alert("Verification Failed");
            }
          },
          error: error =>
          {
            window.alert("Failed to change Password");
          }
        });  
    console.log(this.flag,"flag val");
    return this.flag; 
  }


  verifyNewPassword()
  {
    if(this.pwd==this.pwdchangeRequest.Password)
    {
       window.alert("Old password and new password must be different");
    }
    else
    {
      if(this.pwdchangeRequest.Password==this.ConfirmPassword)
      {
       this.pwdchangeRequest.UserName=this.uname;
       console.log(this.pwdchangeRequest);
       this.actdelservice.verifyNewPassword(this.pwdchangeRequest).subscribe
       ({next:(user) =>
            {
              if(user)
              {
                 window.alert("Password changed successfully");
              }
              else
              {
                window.alert("unable to change password");
              }
            },
            error: error =>
            {
              window.alert("Failed to change Password");
            }
       });
      }
      else
      {
        window.alert("Password and Confirm Password must be same");
      }       
    }
  }


  getCard = (data : any)=>{
    console.log("clicked")
    console.log()
      if(data == "1"){
        console.log("clicked!!")
         const card = <HTMLElement>document.getElementById("popUp_changePassword");
         card.classList.add("getCard")
      }
      else if(data == "2"){
         //popUp_accountSummary
         const card = <HTMLElement>document.getElementById("popUp_accountSummary");
         card.classList.add("getCard")
      }
      else if(data == "3"){
        //popUp_recentTransaction
        const card = <HTMLElement>document.getElementById("popUp_recentTransaction");
        card.classList.add("getCard")
      }
      else {
        //popUp_checkbook
        const card = <HTMLElement>document.getElementById("popUp_orderCheckbook");
        card.classList.add("getCard")
      }
  }
  removeCard = (data : any)=>{
    if(data == "1"){
      console.log("clicked!!")
       const card = <HTMLElement>document.getElementById("popUp_changePassword");
       card.classList.remove("getCard")
    }
    else if(data == "2"){
       //popUp_accountSummary
       const card = <HTMLElement>document.getElementById("popUp_accountSummary");
       card.classList.remove("getCard")
    }
    else if(data == "3"){
      //popUp_recentTransaction
      const card = <HTMLElement>document.getElementById("popUp_recentTransaction");
      card.classList.remove("getCard")
    }
    else {
      //popUp_ordercheckbook
      const card = <HTMLElement>document.getElementById("popUp_orderCheckbook");
      card.classList.remove("getCard")
    }
  }
  


}
