import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
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

email=localStorage.getItem('userName');
UserId:string;

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

groupDto:services.GroupsDTO={
  groupId:0,
  groupName:"",
  groupType:"",
  creatorId:"",
  init:null,
  toJSON:null
}
groupDtoDetails:services.GroupsDTO[];
groupDtoList:services.GroupsDTO[]=[];

friendsDto:services.FriendsDTO;
friendsDtoDetails:services.FriendsDTO[];
friendDtoList:services.FriendsDTO[]=[];

memberDto:services.GroupMembersDTO
memberDtoDetails:services.GroupMembersDTO[];
memberDtoList:services.GroupMembersDTO[]=[];

members:services.GroupMembers={
  memberId:0,
  groupId:0,
  userId:"",
  init:null,
  toJSON:null
};
memberDetails:services.GroupMembers[];
memberList:services.GroupMembers[]=[];

  constructor(private memberServices:services.GroupMembersClient,private route:ActivatedRoute,
    private groupServices:services.GroupsClient,private router:Router
    ,private userServices:services.UserClient,private friendsService:services.FriendsClient) { }

  ngOnInit(): void {
    const id=+this.route.snapshot.paramMap.get('id');
    this.GroupId=id;
    this.groupServices.getGroup2(id).subscribe({
      next:group=>{
        console.log(group);
        this.groupDto=group;
      }
    })
    this.memberServices.getMembersOfAGroup(id).subscribe({
      next:members=>{
        console.log(members);
        this.memberDtoDetails=members;
      }

    });
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
  onSubmit(group:services.GroupsDTO){
    console.log(this.listarray);
    console.log(this.GroupId);
    const groups=new services.Groups();
    groups.groupId=this.GroupId;
    groups.creatorId=this.UserId;
    groups.groupName=group.groupName;
    groups.groupType=group.groupType;
    this.groupServices.updateGroup(groups,this.GroupId).subscribe(
      res=>{
        console.log(res);
        this.onSaveComplete(this.groups.groupId);
        alert("group successfully updated");
      },
      err=>{
        console.log(err);
      });

    console.log("Group And Group Members Updated");
  }

  onSaveComplete(id:number):void{
    const groupMember=new services.GroupMembers();
    for(this.x=0;this.x<this.listarray.length;this.x++){
      groupMember.groupId=id;
      groupMember.userId=this.listarray[this.x];
      this.memberServices.addMember(groupMember).subscribe({
        next:res=>{
          alert('member successfully added');
          this.router.navigate(['/dashboard']);
        }
      })
    }
  }
  listarray:string[]=[];
  x:number;
  getMembers(event:any,i:number){
    if(event.target.checked){
      this.listarray[i]=this.friendsDtoDetails[i].creator;
      console.log(this.listarray[i]);
    }
  }
}
