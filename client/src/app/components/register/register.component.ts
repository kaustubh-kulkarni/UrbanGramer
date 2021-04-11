import { Component, OnInit } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { AccountService } from 'src/app/_services/account.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  data: any;
  registerToggle: boolean;

  constructor(private accountService: AccountService) { }

  ngOnInit(): void {
  }

  register()
  {
    console.log("You pressed register button");
    this.registerToggle = true;
  }

  cancel()
  {
    this.registerToggle = false;
    RouterLink["/homepage"];
  }

}
