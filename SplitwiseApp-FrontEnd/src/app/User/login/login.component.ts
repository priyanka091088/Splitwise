import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { services } from 'src/app/services/services.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  login:services.LoginDTO={
    email:"",
    password:"",
    rememberMe:false,
    init:null,
    toJSON:null
  };
  loginDetails:services.LoginDTO[];
  loginList:services.LoginDTO[]=[];

  constructor(private router:Router,private userServices:services.UserClient) { }

  ngOnInit(): void {
  }
  Login(login:services.LoginDTO){
    this.userServices.login(login).subscribe(
      (next:any)=>{
        localStorage.setItem('userToken',next)

        let token=localStorage.getItem('userToken');
        console.log(token);

        let jwtData=token.split('.')[1]
        let decodedJwtJsonData=window.atob(jwtData);
        let decodedJwtData=JSON.parse(decodedJwtJsonData);
        localStorage.setItem('userName',decodedJwtData.name);
        console.log("name: "+decodedJwtData.name);

        alert("login successful");
        this.router.navigate(['/dashboard']);
      }
    )


  }

}
