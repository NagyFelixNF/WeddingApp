import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from '../models/user';
import { AccountService } from '../services/account.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  model:any = {}
  usern:any;

  constructor(public accountService: AccountService) { }

  ngOnInit(): void {
  }

  login():void{
      this.accountService.login(this.model).subscribe(response => {
        console.log(response);
        this.usern = response.username;
      }, error =>{
        console.log(error);
      });
  }


  logout()
  {
    this.accountService.logout();
  }
}
