import { Component, OnInit } from '@angular/core';
import { services } from 'src/app/services/services.service';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css']
})
export class DetailsComponent implements OnInit {

  groupDto:services.GroupsDTO;
  groupDtoDetails:services.GroupsDTO[];
  groupDtoList:services.GroupsDTO[]=[];

  friendsDto:services.FriendsDTO;
  friendsDtoDetails:services.FriendsDTO[];
  friendDtoList:services.FriendsDTO[]=[];

   email=localStorage.getItem('userName');

  constructor(private groupServices:services.GroupsClient,private expenseServices:services.ExpensesClient,
    private friendsService:services.FriendsClient,private userServices:services.UserClient ) { }

  ngOnInit(): void {
    this.userServices.getUserByEmail2(this.email).subscribe({
        next: user=>{
        console.log(user);
        this.getFriends(user.id);
        this.getGroups(user.id);
      }
    })
  }
  getGroups(id:string){
    this.groupServices.getGroupsForAUser(id).subscribe({
      next: groupDto => {

        console.log(groupDto);
        this.groupDtoDetails=groupDto;

      },
     });
  }

  getFriends(id:string){
    this.friendsService.getFriends(id).subscribe({
      next:friendDto=>{
        console.log(friendDto);
        this.friendsDtoDetails=friendDto;

      }
    });
  }
}
