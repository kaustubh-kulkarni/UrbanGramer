import { Injectable } from '@angular/core';
import { HttpClient } from'@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  baseUrl = 'https://localhost:5001/api';

  constructor(private http: HttpClient) { }
  // Register method to send data to url
  register(data: any): Observable<any>{
    return this.http.post<any>(this.baseUrl + '/register', data);
  }
  // Login method to get users
  login(data: any){
    return this.http.get(this.baseUrl + '')
  }
}
