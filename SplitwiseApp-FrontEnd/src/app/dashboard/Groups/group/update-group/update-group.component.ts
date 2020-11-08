import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { GroupMembers } from 'src/app/Models/groupMembers.model';
import { Groups } from 'src/app/Models/groups.model';
import { services } from 'src/app/services/services.service';

@Component({
  selector: 'app-update-group',
  templateUrl: './update-group.component.html',
  styleUrls: ['./update-group.component.css']
})
export class UpdateGroupComponent implements OnInit {
public pageTitle:string="Update Group";
check:boolean=false;
GroupId:number;
groupDto:services.GroupsDTO;
  groupDtoDetails:services.GroupsDTO[];
  groupDtoList:services.GroupsDTO[]=[];

members:services.GroupMembersDTO;
memberDetails:services.GroupMembersDTO[];
memberList:services.GroupMembersDTO[]=[];

  constructor(private memberServices:services.GroupMembersClient,private route:ActivatedRoute) { }

  ngOnInit(): void {
    const id=+this.route.snapshot.paramMap.get('id');
this.GroupId=id;
    this.memberServices.getMembersOfAGroup(id).subscribe({
      next:members=>{
        console.log(members);
        this.memberDetails=members;
      }

    })
    //this.members=this.initializeGroupMembers();
  }
  ShowAndHide(){
    this.check=!this.check;
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
  onSubmit(groups:services.GroupsDTO){
console.log("Group And Group Members Updated");
  }
}
