import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { services } from 'src/app/services/services.service';


@Component({
  selector: 'app-addfriend',
  templateUrl: './addfriend.component.html',
  styleUrls: ['./addfriend.component.css']
})
export class AddfriendComponent implements OnInit {
public pageTitle:string="Add Friend";
message:string='';
emailAlreadyExist:boolean=true;

friends:services.Friends={
  id:0,
  balance:0,
  friendId:"",
  creatorId:"",
  init:null,
  toJSON:null
};

friendDetails:services.Friends[];
friendList:services.Friends[]=[];

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

email=localStorage.getItem('userName');
UserId:string;
  constructor(private friendServices:services.FriendsClient,private userServices:services.UserClient,private router:Router) { }

  ngOnInit(): void {
    this.userServices.getUserByEmail2(this.email).subscribe({
      next: user=>{
      console.log(user);
      this.UserId=user.id;
    }
  });
  }

  emailCheckUnique(email:string){

    this.userServices.getUserByEmail2(email).subscribe({
      next: user=>{
        console.log(user);
        if(user==null ){
          this.emailAlreadyExist=false;
          this.message="User is not on Splitwise.Please refresh the page before adding again";
        }

        this.users=user;

      }
    });
  }

  onSubmit(){

    this.friends.balance=0;
    this.friends.creatorId=this.UserId;
    this.friends.friendId=this.users.id;

    this.friendServices.addAFriend(this.friends).subscribe(
      res=>{
        alert("Friend successfully added");
        this.onSaveComplete();
      },
      err=>{
        console.log(err);
      }

    )
console.log("Add Friend Details");
  }
  onSaveComplete():void{
    this.router.navigate(['/dashboard']);
  }
}
