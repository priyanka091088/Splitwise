import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { services } from 'src/app/services/services.service';

@Component({
  selector: 'app-add-settlement',
  templateUrl: './add-settlement.component.html',
  styleUrls: ['./add-settlement.component.css']
})
export class AddSettlementComponent implements OnInit {
  pageTitle:string="Add Settlement";
  email=localStorage.getItem('userName');
  currentUserId:string;
  settlement:services.Settlement={
    settlemntId:0,
    amount:0,
    groupId:0,
    payerId:"",
    receiverId:"",
    init:null,
    toJSON:null
  };

  friendsDto:services.FriendsDTO;
  friendsDtoDetails:services.FriendsDTO[];
  friendDtoList:services.FriendsDTO[]=[];

  groupDto:services.GroupsDTO;
  groupDtoDetails:services.GroupsDTO[];
  groupDtoList:services.GroupsDTO[]=[];

  constructor(private userServices:services.UserClient,private friendsService:services.FriendsClient,
    private groupServices:services.GroupsClient,private settlementServices:services.SettlementClient,private router:Router) { }

  ngOnInit(): void {
    this.userServices.getUserByEmail2(this.email).subscribe({
      next: user=>{
      console.log(user);
      this.currentUserId=user.id;
      this.getFriends(user.id);
      this.getGroups(user.id);
    }
  })
  }
  getFriends(id:string){
    this.friendsService.getFriends(id).subscribe({
      next:friendDto=>{
        console.log(friendDto);
        this.friendsDtoDetails=friendDto;
      }
    });
  }
  getGroups(id:string){
    this.groupServices.getGroupsForAUser(id).subscribe({
      next: groupDto => {

        console.log(groupDto);
        this.groupDtoDetails=groupDto;

      },
     });
  }
  onSubmit(settle:services.Settlement){
    this.settlementServices.addASettlement(settle).subscribe({
      next:res=>{
        alert("settlement added successfully");
        this.onSaveComplete();
      }
    })
  }
  onSaveComplete():void{
    this.router.navigate(['/dashboard']);
  }
}
