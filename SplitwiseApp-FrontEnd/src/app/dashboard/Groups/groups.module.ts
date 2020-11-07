import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GroupsComponent } from '../groups/groups.component';
import { RouterModule } from '@angular/router';
import { AddGroupComponent } from './group/add-group/add-group.component';
import { UpdateGroupComponent } from './group/update-group/update-group.component';
import { AddMembersComponent } from './groupMember/add-members/add-members.component';
import { UpdateGroupMembersComponent } from './groupMember/update-group-members/update-group-members.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { FormsModule } from '@angular/forms';
import { ExpensesModule } from '../Expenses/expenses.module';



@NgModule({
  declarations: [GroupsComponent,AddGroupComponent,UpdateGroupComponent,AddMembersComponent,UpdateGroupMembersComponent],
  imports: [
    CommonModule,
    SharedModule,
    FormsModule,
    ExpensesModule,
    RouterModule.forChild([
      { path: 'groups/:id', component: GroupsComponent },
      { path: '', redirectTo: 'groups/:id', pathMatch: 'full' },
      { path: 'addgroup/:id', component: AddGroupComponent},
      { path: 'editgroup/:id', component: UpdateGroupComponent },
      { path: 'addmember/:id', component: AddMembersComponent},
      { path: 'editmember/:id', component: UpdateGroupMembersComponent},

    ])
  ],
  exports: [RouterModule]
})
export class GroupsModule { }
