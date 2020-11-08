import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { services } from 'src/app/services/services.service';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit {
pageTitle:string;
message:string='';
emailAlreadyExist:boolean=false;

signUp:services.SignUpDTO={
  name:"",
  password:"",
  email:"",
  init:null,
  toJSON:null
};
signUpDetails:services.SignUpDTO[];

users:services.UserDTO={
  id:"",
  name:"",
  email:"",
  balance:0,
  password:"",
  init:null,
  toJSON:null
};
usersDetails:services.UserDTO[];
userList:services.UserDTO[]=[];
  constructor(private userServices:services.UserClient,private router:Router) { }

  ngOnInit(): void {

  }
  onSubmit(signup:services.SignUpDTO){
    this.userServices.signUp(signup).subscribe({
      next:register=>{
        alert("User has been registered succesfully");
        this.onSaveComplete();
      }
    })
  }
  onSaveComplete():void{
    this.router.navigate(['/dashboard']);
  }

  emailCheckUnique(email:string){
    alert(email);
    this.userServices.getUserByEmail2(email).subscribe({
      next: user=>{
        console.log(user);
        if(user!=null ){
          this.emailAlreadyExist=true;
          this.message="User with this email Id already exists.Refresh the page before filling up again";
        }
        alert(user.email);
        this.users=user;

      }
    })
  }
}
