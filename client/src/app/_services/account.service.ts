import { Injectable } from '@angular/core';
import { HttpClient } from'@angular/common/http';

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
    return this.http.post(this.baseUrl + 'account/login', data);
  }
}
