import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { services } from 'src/app/services/services.service';

@Component({
  selector: 'app-view-expense',
  templateUrl: './view-expense.component.html',
  styleUrls: ['./view-expense.component.css']
})
export class ViewExpenseComponent implements OnInit {
  pageTitle:string;
  public ExpenseId:number;

  expensesDto:services.ExpensesDTO;
  expensesDtoDetails:services.ExpensesDTO[];
  expensesDtoList:services.ExpensesDTO[]=[];

  payersExpensesDto:services.Payers_ExpensesDTO;
  payersExpensesDetails:services.Payers_ExpensesDTO[];

  payeesExpensesDto:services.Payees_ExpensesDTO;
  payeesExpensesDetails:services.Payees_ExpensesDTO[];

  constructor(private payeeServices:services.PayeesExpensesClient,
    private payerServices:services.PayersExpensesClient,private route:ActivatedRoute,private expenseServices:services.ExpensesClient,
    private router:Router) { }

  ngOnInit(): void {
    const id=+this.route.snapshot.paramMap.get('id');
    this.ExpenseId=id;
alert(id);
alert("hii"+this.ExpenseId);
    this.expenseServices.getExpenseByExpenseId2(id).subscribe({
      next:expenseDto=>{
        console.log(expenseDto);
        this.expensesDto=expenseDto;

      }
    });
    this.payeeServices.getPayeesExpensesById(id).subscribe({
      next:payee=>{
        console.log(payee);
        this.payeesExpensesDetails=payee;
        this.pageTitle=this.payeesExpensesDetails[0].expense;
      }
    });
    this.payerServices.getPayersExpensesByexpenseId(id).subscribe({
      next:payer=>{
        console.log(payer);
    this.payersExpensesDetails=payer;
      }
    })
  }
  DeleteExpense(id:number){
    if(confirm('Really want to delete the expense from splitwise?')){
      this.expenseServices.deleteExpense(id).subscribe(
        res=>{
          this.onSaveComplete();
        },
        err=>{
          console.log(err);
        }
      )
    }
  }
  onSaveComplete():void{
    this.router.navigate(['/dashboard']);
  }
}
