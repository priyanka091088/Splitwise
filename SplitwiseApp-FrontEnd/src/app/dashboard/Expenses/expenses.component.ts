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
  UserId:string;
  expensesDto:services.ExpensesDTO;
  expensesDtoDetails:services.ExpensesDTO[];
  expensesDtoList:services.ExpensesDTO[]=[];

  payersExpensesDto:services.Payers_ExpensesDTO;
  payersExpensesDetails:services.Payers_ExpensesDTO[];

  payeesExpensesDto:services.Payees_ExpensesDTO;
  payeesExpensesDetails:services.Payees_ExpensesDTO[];
  payeesExpensesList:services.Payees_ExpensesDTO[]=[];

  settlementDto:services.SettlementDTO;
  settlementDtoDetails:services.SettlementDTO[];
  constructor(private userServices:services.UserClient,private settlementServices:services.SettlementClient,private payeesSevices:services.PayeesExpensesClient,
    private payersServices:services.PayersExpensesClient) { }

  ngOnInit(): void {
     this.userServices.getUserByEmail(this.email).subscribe({
      next:user=>{
        console.log(user);
        this.UserId=user.id;
        this.UpdateUserBalance(user.id);
        this.getSettlement(user.id);
        this.getExpenses(user.id);
      }
    })
  }

  getSettlement(id:string){
    this.settlementServices.getSettlement(id).subscribe({
      next:settle=>{
        console.log(settle);
        this.settlementDtoDetails=settle;
      }
    })
  }
  getExpenses(id:string){
    this.payersServices.getPayersExpensesByUserId(id).subscribe({
      next:payers=>{
        console.log(payers);
        this.payersExpensesDetails=payers;
        this.getPayees(this.payersExpensesDetails,id);
      }
    })
  }
  ctr:number=0;
  getPayees(payer:services.Payers_ExpensesDTO[],id:string){
    this.payeesSevices.getPayeesExpensesByUserId(id).subscribe({
      next:payee=>{
        console.log(payee);
        for(var i=0;i<payee.length;i++){
          for(var j=0;j<payer.length;j++){
            if(payer[j].expense==payee[i].expense){
              continue;
            }
            else{
              this.payeesExpensesList[this.ctr]=payee[i];
              this.ctr++;
            }
          }
        }
      }
    })
  }
  UpdateUserBalance(id:string){
    this.userServices.getUserBalance(id).subscribe({
      next:res=>{
        this.getBalance(id);
      }
    });
  }
  getBalance(id:string){
    this.userServices.getUser(id).subscribe({
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
  showPayerExpense:boolean=false;
  showPayeeExpense:boolean=false;
  ShowExpenses(){
    this.showPayerExpense=!this.showPayerExpense;
    this.showPayeeExpense=!this.showPayeeExpense;
  }
  showSettlement:boolean=false;
  ShowSettlements(){
    this.showSettlement=!this.showSettlement;
  }
}
