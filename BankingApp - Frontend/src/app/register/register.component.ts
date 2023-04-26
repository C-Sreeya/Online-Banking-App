import { Component } from '@angular/core';
import {FormsModule} from '@angular/forms';
import {RegisterService} from '../register.service';
import {Register} from '../models/registermodel';
import {Router} from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent 
{
      registerRequest:Register={
      UserName:'',
      Password:'',
      ConfirmPassword:'',
      CustomerId:'',
      MobileNo:'',
      UserRole:''
  };

  constructor(private registerservice:RegisterService,private router:Router){}

  ngOnInit():void{
  }

  registerUser()
  {
    console.log(this.registerRequest)
    this.registerservice.registerUser(this.registerRequest)
    .subscribe({
      next:(user)=>{
        if(user){
          this.router.navigate(['signin']);
          // alert("Login SuccessFully");
        }
      },
      error: error => {
        alert("Please Enter Valid Details");
        console.log(error);
      }
    });
  }


}
