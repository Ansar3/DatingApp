import { Component, OnInit, Output, Input, EventEmitter } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { AlertifyService } from '../_services/alertify.service';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  model: any = {};
  registerForm: FormGroup;

 @Input() valuesFromHome: any;
 @Output() cancelRegister: EventEmitter<boolean> = new EventEmitter<boolean>();
  constructor(private authservices: AuthService, private alertify: AlertifyService,private fb: FormBuilder) { }

  ngOnInit() {
 this.createRegisterForm();
   
  }
  createRegisterForm()
  {
    this.registerForm=this.fb.group({
      gender: ['male'],
      username: ['',Validators.required],
      knownAs:['',Validators.required],
      dateOfBirth:[null,Validators.required],
      city: ['',Validators.required],
      country: ['',Validators.required],
      password: ['',[Validators.required,Validators.minLength(4),Validators.maxLength(8)]],
      confirmPassword:['',Validators.required],
    },{Validators:this.passwordMatchValidator});
  }
  passwordMatchValidator(g: FormGroup)
  {
    return g.get('password').value===g.get('confirmPassword').value? null:{'mismatch':true};
  }
   register() {
    //  console.log(this.model);
    //  this.authservices.register(this.model).subscribe(() => {
    //    this.alertify.success('registration successful');
    //  }, error => {
    //    this.alertify.error('Registration Failed');
    //  });
    console.log(this.registerForm.value)
   }
   cancel() {
     this.cancelRegister.emit(false);
     this.alertify.message('cancel');
   }

}
