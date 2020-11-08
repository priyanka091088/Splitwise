import { Component, OnInit } from '@angular/core';
import { services } from 'src/app/services/services.service';

@Component({
  selector: 'app-add-members',
  templateUrl: './add-members.component.html',
  styleUrls: ['./add-members.component.css']
})
export class AddMembersComponent implements OnInit {

  members:services.GroupMembers;
memberDetails:services.GroupMembers[];
memberList:services.GroupMembers[]=[];
  constructor() { }

  ngOnInit(): void {
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

}
