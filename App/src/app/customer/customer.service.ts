import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Http,RequestOptions,Headers,Response } from '@angular/http'
import 'rxjs/Rx';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {

  constructor(private http: Http) { }

  SaveCustomer(customer): Observable<boolean>{
    customer.customerType = 1;
    // let options = new RequestOptions();
    // let headers = new Headers();
    // headers.append('Content-Type', 'application/json');
    // headers.append('Cache-Control', 'no-cache');
    // headers.append('Pragma', 'no-cache');
    // headers.append('Expires', '0');
    // headers.append('Access-Control-Allow-Origin', '*');
    // options = new RequestOptions({ headers: headers });

    return this.http
     .post("http://localhost:64991/api/customer",customer)
     .map((res: Response)=> {
             return true ;
     });  
  }
}
