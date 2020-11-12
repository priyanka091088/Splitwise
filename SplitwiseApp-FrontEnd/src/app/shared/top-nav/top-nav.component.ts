import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-top-nav',
  templateUrl: './top-nav.component.html',
  styleUrls: ['./top-nav.component.css']
})
export class TopNavComponent implements OnInit {

  constructor(private router:Router) { }

  ngOnInit(): void {
  }

  logout(){
    if(confirm('Do you really want to log out of splitwise?')){
      localStorage.removeItem('userToken');
      let token=localStorage.getItem('userToken');
      console.log(token);
      this.router.navigate(['/login']);
    }

  }
}
