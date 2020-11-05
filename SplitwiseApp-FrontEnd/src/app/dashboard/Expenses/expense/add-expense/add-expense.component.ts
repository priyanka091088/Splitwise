import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Expense } from 'src/app/Models/expense.model';

@Component({
  selector: 'app-add-expense',
  templateUrl: './add-expense.component.html',
  styleUrls: ['./add-expense.component.css']
})
export class AddExpenseComponent implements OnInit {
public pageTitle:string="Add Expense";
expense:Expense;
expenseDetails:Expense[];
expenseList:Expense[]=[];
  constructor(private router:Router) { }

  ngOnInit(): void {
    this.expense=this.initializeExpense();
  }

  private initializeExpense():Expense{
    return{
      expenseId:0,
      Description:"",
      Amount:0,
      Currency:"",
      SplitBy:"",
      groupId:0,
      creatorId:""
    }
  }

}
