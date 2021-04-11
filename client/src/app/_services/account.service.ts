import { Injectable } from '@angular/core';
import { HttpClient } from'@angular/common/http';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  baseUrl = 'https://localhost:5001/api/';

  constructor(private http: HttpClient) { }
  // Register method to send data to url
  register(data: any){
    return this.http.post(this.baseUrl + 'account/register', data);
  }
  // Login method to get users
  login(data: any){
    return this.http.post(this.baseUrl + 'account/login', data).pipe(
      map((response: any) => {
        const user = response;
        if(user)
        {
          localStorage.setItem('user', JSON.stringify(user))
        }
      })
    )
  }

  logout()
  {
    localStorage.removeItem('user');
  }
}
