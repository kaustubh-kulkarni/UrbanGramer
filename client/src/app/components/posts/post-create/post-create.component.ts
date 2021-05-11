import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { PostService } from 'src/app/_services/post.service';

@Component({
  selector: 'app-post-create',
  templateUrl: './post-create.component.html',
  styleUrls: ['./post-create.component.css']
})
export class PostCreateComponent implements OnInit {
  data: any = {};
  postCreateForm: FormGroup;
 

  constructor(private postService: PostService, private router: Router, private toastrService: ToastrService, private fb: FormBuilder) { }

  ngOnInit(): void {
    this.initializeForm();
  }

  // Initialize the form
  initializeForm(){
    this.postCreateForm = this.fb.group({
      title : ["", Validators.required],
      content : ["", Validators.required]
    });
  }
  

  createPost(){
    this.postService.addPost(this.postCreateForm.value).subscribe(res => {
      this.router.navigateByUrl('/posts');
    }, error => {
      this.toastrService.error(error.error);
    });
  }

}
