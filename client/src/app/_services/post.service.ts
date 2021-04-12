import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Post } from '../_models/post';

const httpOptions={
  headers: new HttpHeaders({
    Authorization: 'Bearer ' + JSON.parse(localStorage.getItem('user')).token
  })
}

@Injectable({
  providedIn: 'root'
})
export class PostService {
  baseUrl = 'https://localhost:5001/api/';

  constructor(private http: HttpClient) { }
  // All the posts
  getPosts() {
    return this.http.get<Post[]>(this.baseUrl + 'posts', httpOptions);
  }
  // Post by particular user
  getPost(username: string){
    return this.http.get<Post>(this.baseUrl + 'posts/' + username, httpOptions);
  }
}

