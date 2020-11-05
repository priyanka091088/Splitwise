import { Component, OnInit } from '@angular/core';
import { Friends } from 'src/app/Models/friends.model';
import { User } from 'src/app/Models/user.model';

@Component({
  selector: 'app-updatefriend',
  templateUrl: './updatefriend.component.html',
  styleUrls: ['./updatefriend.component.css']
})
export class UpdatefriendComponent implements OnInit {
  public pageTitle:string="Update Friend";
  message:string='';
  emailAlreadyExist:boolean=false;

  friends:Friends;
  friendDetails:Friends[];
  friendList:Friends[]=[];

  users:User;
  usersDetails:User[];
  userList:User[]=[];
  constructor() { }

  ngOnInit(): void {
    this.friends=this.initializeFriends();
    this.users=this.initializeUsers();
  }
  emailCheckUnique(email:string){
    console.log("check if email exists in the user tabl or not");
  }
onSubmit(friends:Friends){
  console.log("Update Friend Details");
}
  private initializeFriends():Friends{
    return{
      Id:0,
      Balance:0,
      creatorId:"",
      friendId:"",

    }
  }

  private initializeUsers():User{
    return{
      Id:"",
      Name:"",
      Balance:0,
      Email:"",
      Password:""
    }
  }
}
