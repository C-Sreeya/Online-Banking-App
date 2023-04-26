import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class SharedService {
  Uname:string='';
  pwd:string='';


  constructor() { }

  setUsername(n:string)
  {
    this.Uname=n;
  }

  getUsername()
  {
    return this.Uname;
  }

}
