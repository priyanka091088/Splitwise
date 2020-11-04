import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FriendsComponent } from '../friends/friends.component';
import { RouterModule } from '@angular/router';
import { ViewfriendlistComponent } from './viewfriendlist/viewfriendlist.component';
import { AddfriendComponent } from './addfriend/addfriend.component';
import { UpdatefriendComponent } from './updatefriend/updatefriend.component';
import { SharedModule } from 'src/app/shared/shared.module';



@NgModule({
  declarations: [FriendsComponent],
  imports: [
    CommonModule,
    SharedModule,
    RouterModule.forChild([
      { path: 'friends', component: FriendsComponent },
      { path: '', redirectTo: 'friends', pathMatch: 'full' },
      { path: 'addfriend/:id', component: AddfriendComponent},
      { path: 'editfriend/:id', component: UpdatefriendComponent},

    ])
  ]
})
export class FriendsModule { }
