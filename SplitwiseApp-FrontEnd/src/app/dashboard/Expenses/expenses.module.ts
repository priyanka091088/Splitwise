import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ExpensesComponent } from '../expenses/expenses.component';
import { RouterModule } from '@angular/router';
import { AddExpenseComponent } from './expense/add-expense/add-expense.component';
import { AddSettlementComponent } from './Settlement/add-settlement/add-settlement.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { FormsModule } from '@angular/forms';
import { ViewExpenseComponent } from './expense/view-expense/view-expense.component';



@NgModule({
  declarations: [ExpensesComponent,AddExpenseComponent,AddSettlementComponent, ViewExpenseComponent],
  imports: [
    CommonModule,
    SharedModule,
    FormsModule,
    RouterModule.forChild([
      { path: 'expense', component: ExpensesComponent },
      { path: 'addexpense/:id', component: AddExpenseComponent},
      { path: 'viewexpense/:id', component: ViewExpenseComponent },
      { path: 'addsettlement/:id', component: AddSettlementComponent},
      { path: '', redirectTo: 'expense', pathMatch: 'full' },

    ])
  ],
  exports:[RouterModule,ExpensesComponent]
})
export class ExpensesModule { }
