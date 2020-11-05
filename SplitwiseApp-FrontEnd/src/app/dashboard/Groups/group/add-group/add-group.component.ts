import { Component, OnInit } from '@angular/core';
import { GroupMembers } from 'src/app/Models/groupMembers.model';
import { Groups } from 'src/app/Models/groups.model';

@Component({
  selector: 'app-add-group',
  templateUrl: './add-group.component.html',
  styleUrls: ['./add-group.component.css']
})
export class AddGroupComponent implements OnInit {
public pageTitle:string="Add Group";
groups:Groups;
groupDetails:Groups[];
groupList:Groups[]=[];

members:GroupMembers;
memberDetails:GroupMembers[];
memberList:GroupMembers[]=[];
  constructor() { }

  ngOnInit(): void {
    this.groups=this.initializeGroup();
    this.members=this.initializeGroupMembers();
  }

  private initializeGroup():Groups{
    return{
      groupId:0,
      groupName:"",
      groupType:"",
      creatorId:"",
    }
  }

  private initializeGroupMembers():GroupMembers{
    return{
      memberId:0,
      groupId:0,
      userId:""
    }
  }
  onSubmit(groups:Groups,members:GroupMembers){
    console.log("Add Group And GroupMembers");
  }
}
