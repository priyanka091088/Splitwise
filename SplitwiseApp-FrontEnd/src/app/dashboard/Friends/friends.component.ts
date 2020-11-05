import { Component, OnInit } from '@angular/core';
import { Friends } from 'src/app/Models/friends.model';
import { User } from 'src/app/Models/user.model';

@Component({
  selector: 'app-friends',
  templateUrl: './friends.component.html',
  styleUrls: ['./friends.component.css']
})
export class FriendsComponent implements OnInit {
  friends:Friends;
  friendDetails:Friends[];
  friendList:Friends[]=[];

  users:User;
  usersDetails:User[];
  userList:User[]=[];

  constructor() { }

  ngOnInit(): void {
  }

}
