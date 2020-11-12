import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FriendsComponent } from '../friends/friends.component';
import { RouterModule } from '@angular/router';

import { AddfriendComponent } from './addfriend/addfriend.component';
import { UpdatefriendComponent } from './updatefriend/updatefriend.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { FormsModule } from '@angular/forms';



@NgModule({
  declarations: [FriendsComponent,AddfriendComponent,UpdatefriendComponent],
  imports: [
    CommonModule,
    SharedModule,
    FormsModule,
    RouterModule.forChild([
      { path: 'friends/:id', component: FriendsComponent },
      { path: '', redirectTo: 'friends/:id', pathMatch: 'full' },
      { path: 'addfriend/:id', component: AddfriendComponent},
      { path: 'editfriend/:id', component: UpdatefriendComponent},

    ])
  ],
  exports:[RouterModule]
})
export class FriendsModule { }
