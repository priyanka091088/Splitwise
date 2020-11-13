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
token=localStorage.getItem('userToken');
  constructor(private userServices:services.UserClient,private router:Router) { }

  ngOnInit(): void {
    console.log(this.token);
  }
  onSubmit(signup:services.SignUpDTO){
    this.userServices.signUp(signup).subscribe({
      next:register=>{
        alert("User has been registered succesfully");
        this.generateToken(signup);

      }
    })
  }
  generateToken(signup:services.SignUpDTO){
    const login=new services.LoginDTO();
    login.email=signup.email;
    login.password=signup.password;
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
        this.onSaveComplete();
    })
  }
  onSaveComplete():void{
    this.router.navigate(['/dashboard']);
  }

  emailCheckUnique(email:string){

    this.userServices.getUserByEmail(email).subscribe({
      next: user=>{
        if(user!=null ){
          this.emailAlreadyExist=true;
          this.message="User with this email Id already exists.Refresh the page before filling up again";
        }

      }
    })
  }
}
