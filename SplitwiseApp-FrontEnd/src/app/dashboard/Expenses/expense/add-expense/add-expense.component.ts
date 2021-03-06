import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { services } from 'src/app/services/services.service';

@Component({
  selector: 'app-add-expense',
  templateUrl: './add-expense.component.html',
  styleUrls: ['./add-expense.component.css']
})
export class AddExpenseComponent implements OnInit {
public pageTitle:string="Add Expense";
ctr:number;
lengths:number;
i:number;
expenseData: any = {
  PayerId: null,
  share:0
}
expense:services.Expenses={
  expenseId:0,
  description:"",
  amount:0,
  currency:"",
  splitBy:"",
  creatorId:"",
  groupId:0,
  init:null,
  toJSON:null
};
expenseDetails:services.Expenses[];

payersExpense:services.Payers_Expenses={
  payerId:"",
  expenseId:0,
  paidAmount:0,
  share:0,
  id:0,
  init:null,
  toJSON:null
};
payersExpensesDetails:services.Payers_Expenses[];

payeesExpenses:services.Payees_Expenses={
  pId:0,
  share:0,
  payerId:"",
  receiverId:"",expenseId:0,
  init:null,
  toJSON:null
};
payeesExpensesDetails:services.Payees_Expenses[];

users:services.UserDTO={
  id:"",
  name:"",
  email:"",
  balance:0,
  password:"",
  init:null,
  toJSON:null
};
usersDtoDetails:services.UserDTO[];
usersDtoList:services.UserDTO[]=[];

memberDto:services.GroupMembersDTO
memberDtoDetails:services.GroupMembersDTO[];
memberDtoList:services.GroupMembersDTO[]=[];

groupDto:services.GroupsDTO;
groupDtoDetails:services.GroupsDTO[];

friendsDto:services.FriendsDTO;
friendsDtoDetails:services.FriendsDTO[];

email=localStorage.getItem('userName');
UserId:string;
x:number=0;
listarray:string[]=[];
  constructor(private router:Router,private groupServices:services.GroupsClient,private friendsService:services.FriendsClient,
    private expenseServices:services.ExpensesClient,private userServices:services.UserClient,private payersServices:services.PayersExpensesClient
    ,private payeesServices:services.PayeesExpensesClient,private memberServices:services.GroupMembersClient) { }

  ngOnInit(): void {
    this.userServices.getUserByEmail(this.email).subscribe({
      next: user=>{
      console.log(user);
      this.UserId=user.id;
      this.users=user;
      this.listarray[this.x]=user.id;
      console.log(this.listarray);
      this.x=this.x+1;
      this.lengths=this.listarray.length;

      this.getFriends(user.id);
      this.getGroups(user.id);
    }
  });
}
//get all the groups for that particular user
  getGroups(id:string){
    this.groupServices.getGroupsForAUser(id).subscribe({
      next: groupDto => {

        console.log(groupDto);
        this.groupDtoDetails=groupDto;

      },
     });
  }
  //get the friends of the current user
  getFriends(id:string){
    this.friendsService.getFriends(id).subscribe({
      next:friendDto=>{
        console.log(friendDto);
        this.friendsDtoDetails=friendDto;

      }
    });
  }
  amntList:number[]=[];
  idlist:string[]=[];
  a:number=0;
  //calculating the unequally splitby
  getShare(amount:number,l:string){
    this.idlist[this.a]=l;
    this.amntList[this.a]=amount;
    this.a++;
  }
//calculation of percentage splitby
  getPercentageAmount(percent:number,l:string){
    this.idlist[this.a]=l;
    this.amntList[this.a]=(this.expense.amount*percent)/100;
    this.a++;
  }
  //function for adding expenses
  onSubmit(expenses:services.Expenses,payers:services.Payers_Expenses,payees:services.Payees_Expenses){
    expenses.creatorId=this.UserId;
    this.expenseServices.addExpense(expenses).subscribe({
      next:expense=>{
        console.log(expense);
        console.log(this.counter);
        alert("Expense successfully added");
            if(expense.splitBy=="equally"){
              for(var j=0;j<this.listarray.length;j++){
                if(this.listarray[j]==payers.payerId){
                  payers.share=expense.amount/this.counter;
                  this.AddPayer(payers,expenses,expense.expenseId);
                }
                else{
                  payees.share=expense.amount/this.counter;
                  payees.payerId=this.listarray[j];
                  this.AddPayee(payers,expense.expenseId,payees);
                }
              }
       }
          else if(expense.splitBy=="exact amount"){
            for(var i=0;i<this.idlist.length;i++){
              if(this.idlist[i]==payers.payerId)//checking whether the id is payers id or not
              {
                payers.share=this.amntList[i];
                this.AddPayer(payers,expenses,expense.expenseId);
              }
              else{
                payees.share=this.amntList[i];
                payees.payerId=this.idlist[i];
                this.AddPayee(payers,expense.expenseId,payees);
              }
            }

          }
          else if(expense.splitBy=="percentage"){
            for(var i=0;i<this.idlist.length;i++){
              if(this.idlist[i]==payers.payerId)//checking whether the id is payers id or not
              {
                payers.share=this.amntList[i];
                this.AddPayer(payers,expenses,expense.expenseId);
              }
              else{
                payees.share=this.amntList[i];
                payees.payerId=this.idlist[i];
                this.AddPayee(payers,expense.expenseId,payees);
              }
            }

          }

        }
    });
  }

  //Function for adding payers
  AddPayer(payers:services.Payers_Expenses,expense:services.Expenses,expenseId:number){
    payers.expenseId=expenseId;
    payers.paidAmount=expense.amount;

    this.payersServices.addPayersExpense(payers).subscribe({
      next:res=>{
        alert("payer successfully added");
      }
    });
  }
//Function for adding payee
  AddPayee(payers:services.Payers_Expenses,expenseId:number,payee:services.Payees_Expenses){
    const payees=new services.Payees_Expenses();
    payees.receiverId=payers.payerId;
    payees.expenseId=expenseId;
    payees.share=payee.share;
    payees.payerId=payee.payerId;
    this.payeesServices.addPayeesExpense(payees).subscribe({
      next:res=>{
        this.onSaveComplete();
      }
    })
  }

  //Show And Hide a div When Required
  check:boolean=false;
  check2:boolean=false;
  ShowAndHide(value:string){
    if(value=="groups"){
      this.check=!this.check;
      if(this.check2==true){
        this.check2=false;
      }

    }
    else if(value=="non-groups"){
      this.check2=!this.check2;
      if(this.check==true){
        this.check=false;
      }
    }
  }
public listarray2:string[]=[];
//To get the id of all the users selected from the list
  ListOfUserId(event:any,i:number){
  if(event.target.checked){

      this.listarray[this.x]=this.friendsDtoDetails[i].creator;
      console.log(this.listarray[this.x]);
      this.x=this.x+1;
      this.lengths=this.listarray.length;
      console.log(this.lengths);
    }
  }

  //to get the names of all the members of the selected group
  ListOfGroupId(event:any,j:number){
    if(event.target.checked){
      this.memberServices.getMembersOfAGroup(this.groupDtoDetails[j].groupId).subscribe({
        next:members=>{
        this.memberDtoDetails=members;
        this.memberDtoList=this.memberDtoDetails;
        this.getMembers(this.memberDtoList);
        }
      })
    }
  }
  getMembers(members:services.GroupMembersDTO[]){

    for(this.ctr=0;this.ctr<members.length;this.ctr++){

      this.userServices.getUserByEmail(members[this.ctr].email).subscribe({

        next:user=>{
          this.listOfMembers(user);
        }
      });

    }
  }
  memberList:string[];
  m:number=0;
  listOfMembers(users:services.UserDTO){
    if(this.listarray[0]!=users.id){
      this.listarray2[this.m]=users.id;
      this.m=this.m+1;
    }
  }

  //SPLITBY CALCULATIONS
  counter:number;
  TotalAmount:number=0;
  exactAmnt:boolean=false;
  percentage:boolean=false;
  check1:boolean=false;
  userListArray:string[]=[];

  SplitByCalculations(amnt:number,splitby:string){
    console.log(splitby);
    //transferring all the group-members of the selected group into a single listarray
    if(this.listarray2!=null){
      for(var j=0;j<this.listarray2.length;j++){
        this.listarray[this.lengths]=this.listarray2[j];
        this.lengths++;
      }
    }
    console.log(this.listarray);
    this.counter=this.listarray.length;
    if(splitby=="equally"){
      this.TotalAmount=amnt/this.counter;
      this.check1=!this.check1;
    }
    else if(splitby=="exact amount"){
      this.exactAmnt=!this.exactAmnt;
      for(this.i=0;this.i<this.listarray.length;this.i++){
        this.userServices.getUser(this.listarray[this.i]).subscribe({
          next:user=>{
            console.log(user);
            this.users=user;
            this.usersDtoList.push(user);
          }
        })
      }
    }
    else if(splitby=="percentage"){
      this.percentage=!this.percentage;
      for(this.i=0;this.i<this.listarray.length;this.i++){
        this.userServices.getUser(this.listarray[this.i]).subscribe({
          next:user=>{
            console.log(user);
            this.users=user;
            this.usersDtoList.push(user);
          }
        })
      }
    }
  }
  onSaveComplete():void{
    this.router.navigate(['/dashboard']);
  }
}
