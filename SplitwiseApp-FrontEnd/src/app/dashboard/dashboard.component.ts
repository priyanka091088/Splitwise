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
  token=localStorage.getItem('userToken');
  friends:services.FriendsDTO;

  friendDetails:services.FriendsDTO[];
  friendList:services.FriendsDTO[]=[];

  constructor(private userServices:services.UserClient,private friendsServices:services.FriendsClient) { }

  ngOnInit(): void {
    if(this.token!=null){
      alert("token is not null");
      this.userServices.getUserByEmail(this.email).subscribe({
        next:user=>{
          console.log(user);
          this.GetFriendsBalance(user.id);
        }
      })
    }

}
i:number;

GetFriendsBalance(id:string){
  this.friendsServices.getFriendsBalance(id).subscribe({
    next:friend=>{
      console.log(friend);
      this.friendDetails=friend;
      console.log(this.friendDetails.length);
    }
  })
}
}
