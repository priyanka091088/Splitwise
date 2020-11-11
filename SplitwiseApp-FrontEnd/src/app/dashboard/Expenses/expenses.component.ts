import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { services } from 'src/app/services/services.service';

@Component({
  selector: 'app-expenses',
  templateUrl: './expenses.component.html',
  styleUrls: ['./expenses.component.css']
})
export class ExpensesComponent implements OnInit {
  pageTitle:string="All Expenses";
  public totalBalance:number;
  public positiveTotalBalance:number;
  balanceOwed:boolean=false;
  balanceOwe:boolean=false;
  email=localStorage.getItem('userName');

  expensesDto:services.ExpensesDTO;
  expensesDtoDetails:services.ExpensesDTO[];
  expensesDtoList:services.ExpensesDTO[]=[];

  payersExpensesDto:services.Payers_ExpensesDTO;
  payersExpensesDetails:services.Payers_ExpensesDTO[];

  payeesExpensesDto:services.Payees_ExpensesDTO;
  payeesExpensesDetails:services.Payees_ExpensesDTO[];
  constructor(private userServices:services.UserClient) { }

  ngOnInit(): void {
     this.userServices.getUserByEmail2(this.email).subscribe({
      next:user=>{
        console.log(user);
        this.UpdateUserBalance(user.id);
      }
    })

  }
  UpdateUserBalance(id:string){
    this.userServices.getUserBalance2(id).subscribe({
      next:res=>{
        alert("updated successfully");
        this.getBalance(id);
      }
    });
  }
  getBalance(id:string){
    this.userServices.getUser2(id).subscribe({
      next:user=>{
        console.log(user);
        console.log(user.balance);
        this.totalBalance=user.balance;
        if(this.totalBalance>0){
          this.balanceOwed=true;
        }
       if(this.totalBalance<0){
          this.positiveTotalBalance= -(this.totalBalance);
          this.balanceOwe=true;
        }
      }
    })
  }
  showExpense:boolean=false;
  ShowExpenses(){
    this.showExpense=!this.showExpense;
  }
  showSettlement:boolean=false;
  ShowSettlements(){
    this.showSettlement=!this.showSettlement;
  }
}
