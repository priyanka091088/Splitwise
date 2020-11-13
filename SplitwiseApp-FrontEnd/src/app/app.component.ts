import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  token=localStorage.getItem('userToken');
  show:boolean=false;
  ngOnInit(): void {
    console.log(this.token);

  }
  title = 'SplitwiseApp-Application';
}
