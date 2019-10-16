import { Component, OnInit } from '@angular/core';
import { ConstantPool } from '@angular/compiler';
import { AuthService } from '../_services/auth.service';
import { AlertifyService } from '../_services/alertify.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
model: any = {};
check: any;

  constructor(public authService: AuthService, private alertify: AlertifyService) { }

  ngOnInit() {
  }
  login() {
  this.authService.login(this.model).subscribe(next => {
    this.alertify.success('Logged in Successfully');
    this.check = true;
  },
  error => {
    this.alertify.error('Please Try Again with correct password and username');
  });
  }
  loggedIn() {
    this.authService.loggedIn();
  }
  logout() {
    localStorage.removeItem('token');
    this.alertify.message('logged out');
    this.check = false;
  }

}
