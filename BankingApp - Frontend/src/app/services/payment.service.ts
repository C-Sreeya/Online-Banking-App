import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Transaction} from '../models/transactionmodel';

@Injectable({
  providedIn: 'root'
})
export class PaymentService {

  constructor(private http:HttpClient) { }

  baseUrl:string='http://localhost:26534/';

  makeTransaction(paymentRequest:Transaction)
  {
      return this.http.post(this.baseUrl+'CreateNewTransaction',paymentRequest);
  }
}
