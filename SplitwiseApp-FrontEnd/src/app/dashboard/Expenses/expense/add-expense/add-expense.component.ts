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
expenseList:services.Expenses[]=[];

groupDto:services.GroupsDTO;
  groupDtoDetails:services.GroupsDTO[];
  groupDtoList:services.GroupsDTO[]=[];

  constructor(private router:Router,private groupServices:services.GroupsClient,private expenseServices:services.ExpensesClient) { }

  ngOnInit(): void {
    this.groupServices.getGroupsForAUser("ffec802a-f39d-4074-a071-f725d96d14d1").subscribe({
      next: groupDto => {

        console.log(groupDto);
        this.groupDtoDetails=groupDto;

      },
     });

  }
  onSubmit(expenses:services.Expenses){
    expenses.creatorId="ffec802a-f39d-4074-a071-f725d96d14d1";
    this.expenseServices.addExpense(expenses).subscribe({
      next:expense=>{
        alert("Expense successfully added");
        this.onSaveComplete();

      }
    })
  }
  onSaveComplete():void{
    this.router.navigate(['/dashboard']);
  }


}
