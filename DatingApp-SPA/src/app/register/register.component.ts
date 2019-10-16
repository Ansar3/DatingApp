import { Component, OnInit, Output, Input, EventEmitter } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { AlertifyService } from '../_services/alertify.service';


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  model: any = {};

 @Input() valuesFromHome: any;
 @Output() cancelRegister: EventEmitter<boolean> = new EventEmitter<boolean>();
  constructor(private authservices: AuthService, private alertify: AlertifyService) { }

  ngOnInit() {
  }
   register() {
     console.log(this.model);
     this.authservices.register(this.model).subscribe(() => {
       this.alertify.success('registration successful');
     }, error => {
       this.alertify.error('Registration Failed');
     });
   }
   cancel() {
     this.cancelRegister.emit(false);
     this.alertify.message('cancel');
   }

}
