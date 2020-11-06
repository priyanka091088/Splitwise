import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SignupComponent } from './User/signup/signup.component';
import { LoginComponent } from './User/login/login.component';
import { FormsModule } from '@angular/forms';

import { HttpClientModule } from '@angular/common/http';
import { SharedModule } from './shared/shared.module';
import { services } from './services/services.service';



@NgModule({
  declarations: [
    AppComponent,
    SignupComponent,
    LoginComponent,

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    SharedModule

  ],
  providers: [services.ExpensesClient],
  bootstrap: [AppComponent]
})
export class AppModule { }
