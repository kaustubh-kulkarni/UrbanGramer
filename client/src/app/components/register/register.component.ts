import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  @Input() usersFromHomeComponent: any;
  @Output() cancelRegister = new EventEmitter();
  data: any = {};

  constructor() { }

  ngOnInit(): void {
  }

  register()
  {
    console.log("You pressed register button");
  }

  cancel()
  {
    this.cancelRegister.emit(false);
  }

}
