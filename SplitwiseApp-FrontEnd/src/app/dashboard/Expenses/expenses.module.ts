import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ExpensesComponent } from '../expenses/expenses.component';
import { RouterModule } from '@angular/router';
import { ViewExpenseComponent } from './expense/view-expense/view-expense.component';
import { AddExpenseComponent } from './expense/add-expense/add-expense.component';
import { UpdateExpenseComponent } from './expense/update-expense/update-expense.component';
import { AddSettlementComponent } from './Settlement/add-settlement/add-settlement.component';
import { UpdateSettlementComponent } from './Settlement/update-settlement/update-settlement.component';
import { ViewSettlementComponent } from './Settlement/view-settlement/view-settlement.component';



@NgModule({
  declarations: [ExpensesComponent],
  imports: [
    CommonModule,
    RouterModule.forChild([
      { path: 'expense', component: ViewExpenseComponent },
      { path: '', redirectTo: 'expense', pathMatch: 'full' },
      { path: 'addexpense/:id', component: AddExpenseComponent},
      { path: 'editexpense/:id', component: UpdateExpenseComponent },
      { path: 'addsettlement/:id', component: AddSettlementComponent},
      { path: 'editsettlement/:id', component: UpdateSettlementComponent},
      { path: 'viewsettlement', component: ViewSettlementComponent},

    ])
  ]
})
export class ExpensesModule { }
