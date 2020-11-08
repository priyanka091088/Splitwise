import { Component, OnInit } from '@angular/core';


@Component({
  selector: 'app-updatefriend',
  templateUrl: './updatefriend.component.html',
  styleUrls: ['./updatefriend.component.css']
})
export class UpdatefriendComponent implements OnInit {
  public pageTitle:string="Update Friend";
  message:string='';
  emailAlreadyExist:boolean=false;


  constructor() { }

  ngOnInit(): void {

  }
  emailCheckUnique(email:string){
    console.log("check if email exists in the user tabl or not");
  }
onSubmit(){
  console.log("Update Friend Details");
}

}
