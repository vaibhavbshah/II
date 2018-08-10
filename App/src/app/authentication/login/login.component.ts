import { Component, OnInit } from '@angular/core';
import { LoginService } from './login.service'
import { User } from '../../Shared/Models/User'
import { CustomerDashboardComponent } from '../../dashboard/customer-dashboard/customer-dashboard.component'
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
 
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private loginService: LoginService, private router: Router) { }

  private user: User;

  ngOnInit() {
  }

  public login = {
    userName: "",
    passWord: ""
 };

 OnSubmit()
{
  this.loginService.Authenticate(this.login)
  .subscribe
  (
    result=>{
      this.user = result;
      this.router.navigate(['/customerdashboard'])
      console.log(this.user);
    }
  );
  // this.customerService.SaveCustomer(this.customer).
  // subscribe(
  //   status=>alert(status)
  // );
  //alert(this.customer.firstName)
}

}
