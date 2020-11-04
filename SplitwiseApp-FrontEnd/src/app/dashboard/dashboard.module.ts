import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './dashboard.component';
import { SharedModule } from '../shared/shared.module';
import { AddExpenseComponent } from './Expenses/expense/add-expense/add-expense.component';
import { AddMembersComponent } from './Groups/groupMember/add-members/add-members.component';
import { ExpensesComponent } from './expenses/expenses.component';
import { GroupsComponent } from './groups/groups.component';
import { FriendsComponent } from './friends/friends.component';

const appRoutes: Routes = [
  {
    path: 'dashboard',
    component: DashboardComponent ,
    children: [
      {
        path: 'groups',
        data: { preload: false },
        loadChildren: () =>
          import('./Groups/groups.module').then(m => m.GroupsModule)
      },
      {
        path: 'expense',
        data: { preload: false },
        loadChildren: () =>
          import('./Expenses/expenses.module').then(m => m.ExpensesModule)
      },
      {
        path: 'friends',
        data: { preload: false },
        loadChildren: () =>
          import('./Friends/friends.module').then(m => m.FriendsModule)
      },


    ]
}
];

@NgModule({
  declarations: [
    DashboardComponent],
  imports: [
    CommonModule,
    SharedModule,
    RouterModule.forChild([
      { path: 'dashboard', component:DashboardComponent},
      { path: '', redirectTo: 'dashboard', pathMatch: 'full' },


  ])
]
})
export class DashboardModule { }
