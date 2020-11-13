import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { services } from 'src/app/services/services.service';

@Component({
  selector: 'app-friends',
  templateUrl: './friends.component.html',
  styleUrls: ['./friends.component.css']
})
export class FriendsComponent implements OnInit {
  email=localStorage.getItem('userName');

  friends:services.FriendsDTO={
    id:0,
    friendName:"",
    creator:"",
    init:null,
    toJSON:null,
    balance:0
  };
  friendDetails:services.FriendsDTO[];
  friendList:services.FriendsDTO[]=[];

  groupid:number;
  constructor(private userServices:services.UserClient,private friendsServices:services.FriendsClient,private route:ActivatedRoute
    ,private payersServices:services.PayersExpensesClient,private router:Router) { }

  ngOnInit(): void {
    const id=+this.route.snapshot.paramMap.get('id');
    this.groupid=id;
    this.userServices.getUserByEmail(this.email).subscribe({
      next:user=>{
        console.log(user);
        this.GetFriendsBalance(user.id,id);
      }
    })
  }
  totalBalance:number;
  friendsName:string;
  friendsId:string;
  GetFriendsBalance(id:string,friendId:number){
    this.friendsServices.getFriendsBalance(id).subscribe({
      next:friend=>{
        console.log(friend);
        this.friendDetails=friend;
        this.friendList=this.friendDetails.filter(f=>f.id==friendId);
        console.log(this.friendList);
        this.totalBalance=this.friendList[0].balance;
        this.friendsName=this.friendList[0].friendName;
        this.friendsId=this.friendList[0].creator;
      }
    })
  }
DeleteFriend(id:number){
  if(confirm('Really want to delete your friend from splitwise?')){
    this.friendsServices.deleteFriend(id).subscribe(
      res=>{
        this.onSaveComplete();
      },
      err=>{
        console.log(err);
      }
    )
  }
}
onSaveComplete():void{
  this.router.navigate(['/dashboard']);
}
}
