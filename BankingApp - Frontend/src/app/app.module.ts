import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { HomeComponent } from './home/home.component';
import { HttpClientModule } from '@angular/common/http';
import { NgForm } from '@angular/forms';
import {FormsModule} from '@angular/forms';
import { AdminComponent } from './admin/admin.component';
import { CustomerComponent } from './customer/customer.component';
import { NavbarComponent } from './navbar/navbar.component';
import { AccountDetailsComponent } from './account-details/account-details.component';
import { CommonNavbarComponent } from './common-navbar/common-navbar.component';
import { LoanComponent } from './loan/loan.component';
import { AdminLoanComponent } from './admin-loan/admin-loan.component';
import { PaymentComponent } from './payment/payment.component'

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    HomeComponent,
    AdminComponent,
    CustomerComponent,
    NavbarComponent,
    AccountDetailsComponent,
    CommonNavbarComponent,
    LoanComponent,
    AdminLoanComponent,
    PaymentComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
