import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DetailsComponent } from './details/details.component';
import { Routes, RouterModule } from '@angular/router';
import { TopNavComponent } from './top-nav/top-nav.component';
import { AddExpenseComponent } from '../dashboard/Expenses/expense/add-expense/add-expense.component';


@NgModule({
  declarations: [DetailsComponent, TopNavComponent],
  imports: [
    CommonModule,
    RouterModule
  ],
  exports:[DetailsComponent,TopNavComponent]
})
export class SharedModule { }
