import { Component, OnInit, Output, Input, EventEmitter } from '@angular/core';
import { AuthService } from '../_services/auth.service';


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  model: any = {};

 @Input() valuesFromHome: any;
 @Output() cancelRegister: EventEmitter<boolean> = new EventEmitter<boolean>();
  constructor(private authservices: AuthService) { }

  ngOnInit() {
  }
   register() {
     console.log(this.model);
     this.authservices.register(this.model).subscribe(() =>{
       console.log('registration successful');
     }, error => {
       console.log(error);
     });
   }
   cancel() {
     this.cancelRegister.emit(false);
     console.log('cancel');
   }

}
