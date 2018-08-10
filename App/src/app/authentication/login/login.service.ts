import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http'
import { Observable } from 'rxjs';
import { User } from '../../Shared/Models/User';


@Injectable({
  providedIn: 'root'
})
export class LoginService {

  constructor(private http: Http) { }

  private user: User;

  Authenticate(login) : Observable<User>
  {
    return this.http
    .post("http://localhost:64991/api/Token/CreateToken",login)
    .map((res: Response)=> {
            this.user = res.json();
        return this.user;
    });  
 }

}
