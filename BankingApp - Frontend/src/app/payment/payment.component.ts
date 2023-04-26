import { Component } from '@angular/core';
import {PaymentService} from '../services/payment.service';
import {Transaction} from '../models/transactionmodel';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-payment',
  templateUrl: './payment.component.html',
  styleUrls: ['./payment.component.css']
})
export class PaymentComponent {

  paymentRequest:Transaction=
  {
    CustomerId:'',
    AccountNo:'',
    ReceiverUserName:'',
    ReceiverAccountNo:'',
    Amount:''
  };

  data:any='';
  response:string='';

  constructor(private paymentservice:PaymentService){}


  CreatePayment()
  {
    if(this.paymentRequest.CustomerId.length>0 && this.paymentRequest.AccountNo.length>0
      && this.paymentRequest.ReceiverUserName.length>0 && this.paymentRequest.ReceiverAccountNo.length>0
      && this.paymentRequest.Amount.length>0)
    {
      console.log(this.paymentRequest);
      this.paymentservice.makeTransaction(this.paymentRequest).subscribe( {
           next:(user)=>
           {
             console.log(user);
             if(user)
             {
               this.data=user;
               console.log(this.data);
               if(user==true)
               {
                  window.alert("Payment is successful");
               }
               else
               {
                 window.alert("Payment Failed due to insufficient Balance");
               }
             }
             else
             {
               window.alert("Payment failed due to insufficient balance");
             }
           },
           error: Error => {
             this.response=Error.error;
             Swal.fire('OOps..',this.response,'error');
             // window.alert(this.response);
             console.log(this.response);
           }
           
         });
    }
    else
    {
      Swal.fire('OOps..','Enter All fields','error');
    }
    
  }

  getCard(data:any)
  {
    if(data==1)
    {
        console.log("clicked!!");
        const card = <HTMLElement>document.getElementById("popUp_payment");
        card.classList.add("getCard");
    }
  }

  removeCard(data:any)
  {
    if(data==1)
    {
      console.log("clicked");
      const card=<HTMLElement>document.getElementById("popUp_payment");
      card.classList.remove("getCard");
    }
  }

}
