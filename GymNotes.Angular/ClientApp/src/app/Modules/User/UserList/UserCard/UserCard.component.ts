import { UtilityService } from './../../../../Core/Services/Utility/Utility.service';
import { Component, OnInit, Input } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

import { UserListStorageService } from './../../../../Core/Services/Storage/UserList-Storage.service';
import { PaginatedList } from 'src/app/Shared/Models/PaginatedList';
import { User } from 'src/app/Shared/Models/User';

@Component({
  selector: 'app-UserCard',
  templateUrl: './UserCard.component.html',
  styleUrls: ['./UserCard.component.scss']
})
export class UserCardComponent implements OnInit {

  @Input() user: User = {
    id: '',
    facebook: '',
    instagram: '',
    twitter: '',
    youTube: '',
    isCoach: false,
    height: 0,
    birthday:'',
    gender: '',
    firstName: '',
    lastName: '',
    alias: '',
    fullName: '',
    description: '',
    discipline: '',
    yearsOfExperience: 0,
    trainingSince: null,
  };

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    public userListStorage: UserListStorageService,
    public utility: UtilityService
  ) { }

  ngOnInit() {
  }

  sendMessage(val: string) {
		this.router.navigate([ 'main/chat/', val ]);
  }

  onUserSelected(id){
    this.router.navigate(['userprofile/', id], {relativeTo: this.route});
  }
}
