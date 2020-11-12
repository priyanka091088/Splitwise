import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GroupsComponent } from '../groups/groups.component';
import { RouterModule } from '@angular/router';
import { AddGroupComponent } from './group/add-group/add-group.component';

import { AddMembersComponent } from './groupMember/add-members/add-members.component';

import { SharedModule } from 'src/app/shared/shared.module';
import { FormsModule } from '@angular/forms';
import { ExpensesModule } from '../Expenses/expenses.module';




@NgModule({
  declarations: [GroupsComponent,AddGroupComponent,AddMembersComponent],
  imports: [
    CommonModule,
    SharedModule,
    FormsModule,
    ExpensesModule,
    RouterModule.forChild([
      { path: 'groups/:id', component: GroupsComponent },
      { path: '', redirectTo: 'groups/:id', pathMatch: 'full' },
      { path: 'addgroup/:id', component: AddGroupComponent},
      { path: 'addmember/:id', component: AddMembersComponent}

    ])
  ],
  exports: [RouterModule]
})
export class GroupsModule { }
