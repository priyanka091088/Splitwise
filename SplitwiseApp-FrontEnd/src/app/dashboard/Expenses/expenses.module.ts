import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ExpensesComponent } from '../expenses/expenses.component';
import { RouterModule } from '@angular/router';
import { AddExpenseComponent } from './expense/add-expense/add-expense.component';
import { UpdateExpenseComponent } from './expense/update-expense/update-expense.component';
import { AddSettlementComponent } from './Settlement/add-settlement/add-settlement.component';
import { UpdateSettlementComponent } from './Settlement/update-settlement/update-settlement.component';
import { ViewSettlementComponent } from './Settlement/view-settlement/view-settlement.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { FormsModule } from '@angular/forms';



@NgModule({
  declarations: [ExpensesComponent,AddExpenseComponent,UpdateExpenseComponent,AddSettlementComponent,UpdateSettlementComponent],
  imports: [
    CommonModule,
    SharedModule,
    FormsModule,
    RouterModule.forChild([
      { path: 'expense/:id', component: ExpensesComponent },

      { path: 'addexpense/:id', component: AddExpenseComponent},
      { path: 'editexpense/:id', component: UpdateExpenseComponent },
      { path: 'addsettlement/:id', component: AddSettlementComponent},
      { path: 'editsettlement/:id', component: UpdateSettlementComponent},
      { path: 'viewsettlement', component: ViewSettlementComponent},
      { path: '', redirectTo: 'expense/:id', pathMatch: 'full' },

    ])
  ],
  exports:[RouterModule]
})
export class ExpensesModule { }
