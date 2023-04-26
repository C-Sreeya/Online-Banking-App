import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AccountDetailsComponent } from './account-details/account-details.component';
import { AdminLoanComponent } from './admin-loan/admin-loan.component';
import { AdminComponent } from './admin/admin.component';
import { AppComponent } from './app.component';
import { CustomerComponent } from './customer/customer.component';
import { HomeComponent } from './home/home.component';
import { LoanComponent } from './loan/loan.component';
import { LoginComponent } from './login/login.component';
import { PaymentComponent } from './payment/payment.component';
import { RegisterComponent } from './register/register.component';

const routes: Routes = [
  {path:'', component:HomeComponent},
  {path:'signin', component:LoginComponent},
  {path:'signup', component:RegisterComponent},
  {path:'adminview',component:AdminComponent},
  {path:'customerview',component:CustomerComponent},
  {path:'actdetls',component:AccountDetailsComponent},
  {path:'adminloanpage',component:AdminLoanComponent},
  {path:'customerloanpage',component:LoanComponent},
  {path:'paymentpage',component:PaymentComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
