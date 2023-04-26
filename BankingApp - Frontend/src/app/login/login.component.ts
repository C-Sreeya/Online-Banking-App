import {  Component, Output } from '@angular/core';
import { Login } from '../models/loginmodel';
import { LoginService } from '../login.service';
import { Router } from '@angular/router';
import {SharedService} from '../services/shared.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})

export class LoginComponent 
{
  loginRequest:Login={
    UserName:'',
    Password:''
  };

  username:string = '';


  loginArr:any=[];
  UserRole:string='';

  constructor(private loginservice:LoginService,private router:Router,private shared:SharedService){
    
  }

  ngOnInit():void{
  }
  
  loginUser()
  {
    console.log(this.loginRequest)
    this.username=this.loginRequest.UserName;

    this.loginservice.loginUser(this.loginRequest).subscribe
      (
          data =>{
                      this.loginArr=data;
                      this.UserRole=this.loginArr.role;
                      console.log(data);
                      const value=this.loginRequest.UserName;
                      localStorage.setItem('loginRequest.UserName',value);
                      window.alert("Logged in successfully");
                },
          error => {
                      Swal.fire('OOps..',error.error,'error');
                      // window.alert("Invalid Credentials");
                      console.log(error.error);
                 },
          () => {
                  if(this.UserRole=="Admin" || this.UserRole=="admin")
                  {
                    this.router.navigate(["adminview"]);
                  }
                  else if(this.UserRole=="Customer" || this.UserRole=="customer")
                  {
                    this.router.navigate(["customerview"]);
                  }
                  else
                  {
                    window.alert("Enter valid credentials");
                  }
                }
      );
  }

  public resetStorage()
  {
    localStorage.removeItem('loginRequest.UserName');
  }





  // loginUser(){
  //   console.log(this.loginRequest)
  //     this.loginservice.loginUser(this.loginRequest)    
  //   .subscribe( {
  //     next:(user)=>{
  //       if(user){
  //         // if(this.loginRequest.Role=="Customer"||this.loginRequest.Role=="customer"){
  //         // this.router.navigate(['customerview']);
  //         // }
  //         // else if(this.loginRequest.Role=="Admin"||this.loginRequest.Role=="admin"){
  //         //   this.router.navigate(['adminview']);
  //         // }
  //         // else{
  //         //   window.alert("Please Enter valid details");
  //         // }
  //         if(user.Role=="Customer" || user.Role=="customer")
  //         {
  //           this.router.navigate(['customerview']);
  //         }
  //         else if(user.Role=="admin" || user.Role=="Admin")
  //         {
  //           this.router.navigate(['adminview']);
  //         }
  //         else
  //         {
  //           window.alert("Please Enter valid credentials");
  //         }
  //       }
  //     },
  //     error: error => {
  //       window.alert("Invalid Credentials");
  //       console.log(error);
  //     }
  //   });
  // }

}
