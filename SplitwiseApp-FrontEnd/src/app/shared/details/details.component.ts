import { Component, OnInit } from '@angular/core';
import { Friends } from 'src/app/Models/friends.model';
import { Groups } from 'src/app/Models/groups.model';
import { User } from 'src/app/Models/user.model';
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

  constructor(private groupServices:services.GroupsClient,private expenseServices:services.ExpensesClient,
    private friendsService:services.FriendsClient ) { }

  ngOnInit(): void {

    //this.groupDto=this.initializeGroupDto();

    this.groupServices.getGroupsForAUser("ffec802a-f39d-4074-a071-f725d96d14d1").subscribe({
      next: groupDto => {

        console.log(groupDto);
        this.groupDtoDetails=groupDto;

      },
     });
     this.friendsService.getFriends("ac146507-e123-4fda-a9d9-178d92921ebf").subscribe({
       next:friendDto=>{
         console.log(friendDto);
         this.friendsDtoDetails=friendDto;

       }
     });




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
