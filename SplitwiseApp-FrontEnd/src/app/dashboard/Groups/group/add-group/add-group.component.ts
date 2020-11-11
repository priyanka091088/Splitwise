import { NullVisitor } from '@angular/compiler/src/render3/r3_ast';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { services } from 'src/app/services/services.service';

@Component({
  selector: 'app-add-group',
  templateUrl: './add-group.component.html',
  styleUrls: ['./add-group.component.css']
})
export class AddGroupComponent implements OnInit {
public pageTitle:string="Add Group";


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

friendsDto:services.FriendsDTO;
friendsDtoDetails:services.FriendsDTO[];
friendDtoList:services.FriendsDTO[]=[];

members:services.GroupMembers={
  memberId:0,
  groupId:0,
  userId:"",

  init:null,
  toJSON:null
};
memberDetails:services.GroupMembers[];
memberList:services.GroupMembers[]=[];

email=localStorage.getItem('userName');
UserId:string;
check:boolean=false;
  constructor(private groupServices:services.GroupsClient,private router:Router,
    private friendsService:services.FriendsClient,private memberServices:services.GroupMembersClient
    ,private userServices:services.UserClient) { }

  ngOnInit(): void {
    this.userServices.getUserByEmail2(this.email).subscribe({
      next: user=>{
      console.log(user);
      this.UserId=user.id;
      this.getFriends(user.id);
    }
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

  ShowAndHide(){
    this.check=!this.check;
  }

listarray:string[]=[];
x:number;

  onSubmit(groups:services.Groups){
    console.log(this.listarray);
    groups.creatorId=this.UserId;
    this.groupServices.addAGroup(groups).subscribe(
      res=>{
        console.log(res);
        this.onSaveComplete(res);
        alert("group successfully updated");
      },
      err=>{
        console.log(err);
      })
  }
 onSaveComplete(id:number):void{
    const groupMember=new services.GroupMembers();
    for(this.x=0;this.x<this.listarray.length;this.x++){
      groupMember.groupId=id;
      groupMember.userId=this.listarray[this.x];
      this.memberServices.addMember(groupMember).subscribe({
        next:res=>{
          alert('member successfully updated');
          this.router.navigate(['/dashboard']);
        }
      })
    }
  }

  getMembers(event:any,i:number){
    if(event.target.checked){
      this.listarray[i]=this.friendsDtoDetails[i].creator;
      console.log(this.listarray[i]);
    }
  }
}
