import { Component, OnInit } from '@angular/core';
import { take } from 'rxjs/operators';
import { Post } from 'src/app/_models/post';
import { User } from 'src/app/_models/user';
import { AccountService } from 'src/app/_services/account.service';
import { CommunityService } from 'src/app/_services/community.service';
import { PostService } from 'src/app/_services/post.service';

@Component({
  selector: 'app-post-edit',
  templateUrl: './post-edit.component.html',
  styleUrls: ['./post-edit.component.css']
})
export class PostEditComponent implements OnInit {
  user: User;
  posts: any;
  constructor(private accountService: AccountService ,private postService: PostService, private communityService: CommunityService) {
    this.accountService.currentUser$.pipe(take(1)).subscribe(user =>this.user = user);
   }

  ngOnInit(): void {
    this.loadUserPosts();
  }

  loadUserPosts(){
   this.communityService.getPostsByMember(this.user.username).subscribe(response => {
      this.posts = response.posts;
   });
  }

}
