import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { GroupMembers } from 'src/app/Models/groupMembers.model';
import { Groups } from 'src/app/Models/groups.model';
import { services } from 'src/app/services/services.service';

@Component({
  selector: 'app-add-group',
  templateUrl: './add-group.component.html',
  styleUrls: ['./add-group.component.css']
})
export class AddGroupComponent implements OnInit {
public pageTitle:string="Add Group";


members:GroupMembers;
memberDetails:GroupMembers[];
memberList:GroupMembers[]=[];

groups:services.Groups={
  groupId:0,
  groupName:"",
  groupType:"",
  creatorId:"",
  toJSON:null,
  init:null
};
groupDetails:services.Groups[];
groupList:services.Groups[]=[];
check:boolean=false;
  constructor(private groupServices:services.GroupsClient,private router:Router) { }

  ngOnInit(): void {

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
  ShowAndHide(){
    this.check=!this.check;
  }
  onSubmit(groups:services.Groups){
    groups.creatorId="ffec802a-f39d-4074-a071-f725d96d14d1";
    this.groupServices.addAGroup(groups).subscribe(
      res=>{
        alert("group successfully added");
        this.onSaveComplete();
      },
      err=>{
        console.log(err);
      }

    )
    console.log("Add Group And GroupMembers");
  }
  onSaveComplete():void{
    this.router.navigate(['/dashboard']);
  }
}
