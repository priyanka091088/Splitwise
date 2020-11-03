import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DashboardComponent } from './dashboard/dashboard.component';
import { LoginComponent } from './User/login/login.component';
import { SignupComponent } from './User/signup/signup.component';


const routes: Routes = [
  { path: 'signup', component:SignupComponent},
  { path: 'login', component:LoginComponent},
  {
    path: 'dashboard',
    data: { preload: false },
    loadChildren: () =>
      import('./dashboard/dashboard.module').then(m => m.DashboardModule)
  },
  {
    path: 'groups',
    data: { preload: false },
    loadChildren: () =>
      import('./dashboard/Groups/groups.module').then(m => m.GroupsModule)
  },
  {
    path: 'expense',
    data: { preload: false },
    loadChildren: () =>
      import('./dashboard/Expenses/expenses.module').then(m => m.ExpensesModule)
  },
  {
    path: 'friends',
    data: { preload: false },
    loadChildren: () =>
      import('./dashboard/Friends/friends.module').then(m => m.FriendsModule)
  },

  { path: '', redirectTo: 'signup', pathMatch: 'full' },



];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
