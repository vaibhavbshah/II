import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { Routes,RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { CustomerComponent } from './customer/customer.component';
import { LoginComponent } from './authentication/login/login.component';
import { CustomerDashboardComponent } from './dashboard/customer-dashboard/customer-dashboard.component';


const routes: Routes = [
  { path: '', component: LoginComponent },
  { path: 'customer', pathMatch: 'full', component: CustomerComponent },
  { path: 'customerdashboard', pathMatch: 'full', component: CustomerDashboardComponent },
  
];

@NgModule({
  declarations: [
    AppComponent,
    CustomerComponent,
    LoginComponent,
    CustomerDashboardComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    RouterModule.forRoot(
      routes
    )
  ],
  providers: [],
  //bootstrap: [LoginComponent]
  bootstrap: [AppComponent]
 //bootstrap: [CustomerComponent]
})
export class AppModule { }