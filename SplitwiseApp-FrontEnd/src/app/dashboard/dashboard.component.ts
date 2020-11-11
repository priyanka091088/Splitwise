import { Component, OnInit } from '@angular/core';
import { services } from '../services/services.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  title: "Dashboard"
  email=localStorage.getItem('userName');

  friends:services.FriendsDTO;

  friendDetails:services.FriendsDTO[];
  friendList:services.FriendsDTO[]=[];

  constructor(private userServices:services.UserClient,private friendsServices:services.FriendsClient) { }

  ngOnInit(): void {
    this.userServices.getUserByEmail2(this.email).subscribe({
      next:user=>{
        console.log(user);
        this.GetFriendsBalance(user.id);
      }
    })
}
i:number;
friendOwing:string[]=[];
friendOwed:string[]=[];
amountOwing:number[]=[];
amountOwed:number[]=[];
owed:number=0;

GetFriendsBalance(id:string){
  this.friendsServices.getFriendsBalance(id).subscribe({
    next:friend=>{
      console.log(friend);
      this.friendDetails=friend;
      console.log(this.friendDetails.length);
      //this.friendList=this.friendDetails;
      for(this.i=0;this.i<this.friendDetails.length;this.i++){
        if(this.friendDetails[this.i].balance>0){
          this.friendOwing[this.owed]=this.friendDetails[this.i].friendName;
          this.amountOwing[this.owed]=this.friendDetails[this.i].balance;
          this.owed++;
        }
        else{
          this.friendOwed[this.owed]=this.friendDetails[this.i].friendName;
          this.amountOwed[this.owed]= -(this.friendDetails[this.i].balance);
          this.owed++;
        }
      }
    }
  })
}
}
