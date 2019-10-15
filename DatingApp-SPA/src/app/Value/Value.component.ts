import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { error } from 'util';

@Component({
  // tslint:disable-next-line: component-selector
  selector: 'app-Value',
  templateUrl: './Value.component.html',
  styleUrls: ['./Value.component.css']
})
export class ValueComponent implements OnInit {
  values: any;
  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getValues();
    console.log('here');
  }
  getValues() {
    this.http.get('https://localhost:5001/api/Value').subscribe(response => {
      this.values = response; },
      // tslint:disable-next-line: no-shadowed-variable
      error => {
      console.log(error);
    });
  }


}
