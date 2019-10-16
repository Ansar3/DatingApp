import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  registerMode = false;
   /* values: any;*/
    constructor(private http: HttpClient) { }

    ngOnInit() {
    /*  this.getValues();
      console.log('here');*/
    }
   /* getValues() {
      this.http.get('https://localhost:5001/api/Value').subscribe(response => {
        this.values = response; },
        // tslint:disable-next-line: no-shadowed-variable
        error => {
        console.log(error);
      });*/
      cancalregisterMode(check: any) {
        this.registerMode = check;
      }
      registerToggle() {
        this.registerMode = !this.registerMode;
      }
    }



