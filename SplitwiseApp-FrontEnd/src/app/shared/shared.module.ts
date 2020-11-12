import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { Routes, RouterModule } from '@angular/router';
import { TopNavComponent } from './top-nav/top-nav.component';
import { AddExpenseComponent } from '../dashboard/Expenses/expense/add-expense/add-expense.component';
import { RightSideNavComponent } from './right-side-nav/right-side-nav.component';

import { HttpClientModule } from '@angular/common/http';
import { services } from '../services/services.service';
import { DetailComponent } from './detail/detail.component';


@NgModule({
  declarations: [ TopNavComponent,DetailComponent],
  imports: [
    CommonModule,
    RouterModule,
    HttpClientModule
  ],
  providers:[services.ExpensesClient,services.GroupsClient,services.FriendsClient,
    services.PayersExpensesClient,services.PayeesExpensesClient,services.GroupMembersClient,services.UserClient,services.PayeesExpensesClient,
    services.PayersExpensesClient,services.SettlementClient],
  exports:[TopNavComponent,DetailComponent]
})
export class SharedModule { }
