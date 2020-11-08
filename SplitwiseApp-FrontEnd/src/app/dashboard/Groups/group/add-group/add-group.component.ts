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
check:boolean=false;
  constructor(private groupServices:services.GroupsClient,private router:Router) { }

  ngOnInit(): void {

  }

  ShowAndHide(){
    this.check=!this.check;
  }

  createNewElement() {
    // First create a DIV element.
  var txtNewInputBox = document.createElement('div');
  var txtNewInputBox2 = document.createElement('div');

    // Then add the content (a new input box) of the element.
  txtNewInputBox.innerHTML = "<input type='text' id='nameInputBox' placeholder='Name' [(ngModel)]=''>";
  txtNewInputBox2.innerHTML = "<input type='text' id='EmailInputBox' placeholder='Email' [(ngModel)]=''>";

    // Finally put it where it is supposed to appear.
  document.getElementById("newElementId").appendChild(txtNewInputBox);
  document.getElementById("newElementId2").appendChild(txtNewInputBox2);
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
