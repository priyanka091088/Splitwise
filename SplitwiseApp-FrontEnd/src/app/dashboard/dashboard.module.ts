import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './dashboard.component';



@NgModule({
  declarations: [
    DashboardComponent],
  imports: [
    CommonModule,
    RouterModule.forChild([
      { path: 'dashboard', component:DashboardComponent},
      { path: '', redirectTo: 'dashboard', pathMatch: 'full' },

  ])
]
})
export class DashboardModule { }
