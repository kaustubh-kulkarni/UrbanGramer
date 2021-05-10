import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-post-create',
  templateUrl: './post-create.component.html',
  styleUrls: ['./post-create.component.css']
})
export class PostCreateComponent implements OnInit {
  postCreateForm = new FormGroup({
    title : new FormControl(""),
    content : new FormControl("")
  });
 

  constructor() { }

  ngOnInit(): void {
  }

  onSubmit(){
    console.log(this.postCreateForm.value);
  }

}
