import { Component, OnInit, Input } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';

import { AddOpinionComponent } from '../../AddOpinion/AddOpinion.component';
import { UserOpinion } from 'src/app/Shared/Models/UserOpinion';
import { UserOpinionService } from 'src/app/Core/Services/Http/User/UserOpinion.service';
import { AuthenticationService } from 'src/app/Auth/Authentication.service';

@Component({
  selector: 'app-CommentSection',
  templateUrl: './CommentSection.component.html',
  styleUrls: ['./CommentSection.component.scss']
})
export class CommentSectionComponent implements OnInit {

  @Input() selectedUserId: string;

  CommentsList: UserOpinion[];

  constructor(
    private matDialog: MatDialog,
    public authentication: AuthenticationService,
    private userOpinionService: UserOpinionService,) { }

  ngOnInit() {
    const parameters: string[] = [this.authentication.UserId];

    this.userOpinionService.GetUserOpinion(parameters).subscribe((res: UserOpinion[]) => {
      this.CommentsList = res;
      console.warn(res);
    });
  }

  AddOpinion(){
    const dialogRef = this.matDialog.open(AddOpinionComponent,{
      maxHeight: '100%',
    });
  }

  LikeClick(){
  }
}
