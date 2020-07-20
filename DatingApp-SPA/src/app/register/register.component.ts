import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { AlertifyService } from '../_services/alertify.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  @Output() cancelRegister = new EventEmitter(); // child to parent, EventEmitter from @angular/core
  model: any = {}; // specify empty obj

  constructor(private authSeervice: AuthService, private alertify: AlertifyService) { }

  ngOnInit() {
  }

  register() {
    this.authSeervice.register(this.model).subscribe(() => {
      this.alertify.success('registration successful');
    }, err => {
      this.alertify.error(err);
    });
  }
  cancel() {
    this.cancelRegister.emit(false);
    console.log('cancelled');
  }

}
