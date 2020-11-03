import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GroupsComponent } from '../groups/groups.component';
import { RouterModule } from '@angular/router';
import { ViewListGroupComponent } from './group/view-list-group/view-list-group.component';
import { AddGroupComponent } from './group/add-group/add-group.component';
import { UpdateGroupComponent } from './group/update-group/update-group.component';
import { AddMembersComponent } from './groupMember/add-members/add-members.component';
import { UpdateGroupMembersComponent } from './groupMember/update-group-members/update-group-members.component';



@NgModule({
  declarations: [GroupsComponent],
  imports: [
    CommonModule,
    RouterModule.forChild([
      { path: 'groups', component: ViewListGroupComponent },
      { path: '', redirectTo: 'groups', pathMatch: 'full' },
      { path: 'addgroup/:id', component: AddGroupComponent},
      { path: 'editgroup/:id', component: UpdateGroupComponent },
      { path: 'addmember/:id', component: AddMembersComponent},
      { path: 'editmember/:id', component: UpdateGroupMembersComponent},

    ])
  ]
})
export class GroupsModule { }
