import { Component, OnInit } from '@angular/core';
import { CommunityService } from 'src/app/_services/community.service';

@Component({
  selector: 'app-community',
  templateUrl: './community.component.html',
  styleUrls: ['./community.component.css']
})
export class CommunityComponent implements OnInit {
  users: any

  constructor(private communityService: CommunityService) { }

  ngOnInit(): void {
    this.loadUsers();
  }

  loadUsers(){
    this.communityService.getUsers().subscribe(res => {
      this.users = res;
    })
  }


}
