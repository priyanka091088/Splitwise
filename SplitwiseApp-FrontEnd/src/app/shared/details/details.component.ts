import { Component, OnInit } from '@angular/core';
import { Friends } from 'src/app/Models/friends.model';
import { Groups } from 'src/app/Models/groups.model';
import { User } from 'src/app/Models/user.model';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css']
})
export class DetailsComponent implements OnInit {
  friends:Friends;
  friendDetails:Friends[];
  friendList:Friends[]=[];

  users:User;
  usersDetails:User[];
  userList:User[]=[];

  groups:Groups;
  groupDetails:Groups[];
  groupList:Groups[]=[];

  constructor() { }

  ngOnInit(): void {
    this.groups=this.initializeGroup();
    this.friends=this.initializeFriends();
    this.users=this.initializeUsers();
  }
  private initializeGroup():Groups{
    return{
      groupId:0,
      groupName:"",
      groupType:"",
      creatorId:"",
    }
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
