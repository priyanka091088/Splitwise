import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-add-members',
  templateUrl: './add-members.component.html',
  styleUrls: ['./add-members.component.css']
})
export class AddMembersComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  createNewElement() {
    // First create a DIV element.
	var txtNewInputBox = document.createElement('div');

    // Then add the content (a new input box) of the element.
  txtNewInputBox.innerHTML = "<input type='text' id='newInputBox' placeholder='Name'>";
  txtNewInputBox.innerHTML = "<input type='text' id='newInputBox' placeholder='Name'>";

    // Finally put it where it is supposed to appear.
	document.getElementById("newElementId").appendChild(txtNewInputBox);
}
}
