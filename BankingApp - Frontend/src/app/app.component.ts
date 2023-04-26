import { Component,OnInit } from '@angular/core';
import {SharedService} from './services/shared.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'BankingApp';

  constructor(private shared:SharedService)
  {}

  ngOnInit():void
  {
    const value=localStorage.getItem('loginRequest.UserName');
    if(value)
    {
      this.shared.setUsername(value);
    }
  }
}
