import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

const httpOptions={
  headers: new HttpHeaders({
    Authorization: 'Bearer ' + JSON.parse(localStorage.getItem('user'))?.token
  })
}

@Injectable({
  providedIn: 'root'
})
export class CommunityService {
  baseUrl = 'https://localhost:5001/api/';

  constructor(private http: HttpClient) { }

  getUsers(){
    return this.http.get(this.baseUrl + 'users', httpOptions);
  }

  getUser(username: string){
    return this.http.get(this.baseUrl + 'users/' + username, httpOptions);
  }
}
