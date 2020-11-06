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
  friends:Friends;
  friendDetails:Friends[];
  friendList:Friends[]=[];

  users:User;
  usersDetails:User[];
  userList:User[]=[];

  groups:Groups;
  groupDetails:Groups[];
  groupList:Groups[]=[];

  groupDto:services.GroupsDTO;
  groupDtoDetails:services.GroupsDTO[];
  groupDtoList:services.GroupsDTO[]=[];


  constructor(private groupServices:services.GroupsClient,private expenseServices:services.ExpensesClient,
    private friendsService:services.FriendsClient ) { }

  ngOnInit(): void {
    this.groups=this.initializeGroup();
    this.friends=this.initializeFriends();
    this.users=this.initializeUsers();
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
       }
     });

    /*this.expenseServices.expenseForAGroup(14).subscribe({
      next:expenseDto=>{
        console.log(expenseDto);
      }
    });*/


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
