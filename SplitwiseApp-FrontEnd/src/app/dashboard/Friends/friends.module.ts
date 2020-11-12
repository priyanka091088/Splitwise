import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FriendsComponent } from '../friends/friends.component';
import { RouterModule } from '@angular/router';

import { AddfriendComponent } from './addfriend/addfriend.component';

import { SharedModule } from 'src/app/shared/shared.module';
import { FormsModule } from '@angular/forms';



@NgModule({
  declarations: [FriendsComponent,AddfriendComponent],
  imports: [
    CommonModule,
    SharedModule,
    FormsModule,
    RouterModule.forChild([
      { path: 'friends/:id', component: FriendsComponent },
      { path: '', redirectTo: 'friends/:id', pathMatch: 'full' },
      { path: 'addfriend/:id', component: AddfriendComponent},

    ])
  ],
  exports:[RouterModule]
})
export class FriendsModule { }
