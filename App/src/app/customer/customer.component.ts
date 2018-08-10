import { Component, OnInit } from '@angular/core';
import { CustomerService } from './customer.service'

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.css']
})
export class CustomerComponent implements OnInit {

  constructor(private customerService: CustomerService) { }

  ngOnInit() {
  }

public customer = {
   firstName: "",
   lastName: "",
   customerType: 1,
   userName: "",
   passWord: ""
};

OnSave()
{
  this.customerService.SaveCustomer(this.customer).
  subscribe(
    status=>alert(status)
  );
  alert(this.customer.firstName)
}

}
