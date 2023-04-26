import { Component , OnInit} from '@angular/core';
import {SharedService} from '../services/shared.service';
import {Router} from '@angular/router';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent {
  Uname:string='';

  constructor(private shared:SharedService, private router:Router){}

  ngOnInit():void
  {
    this.Uname=this.shared.getUsername();

  }

  redirectTo()
  {
    this.router.navigate(['']);
  }

  redirectToHome()
  {
    this.router.navigate(['/customerview']);
  }

  

}
