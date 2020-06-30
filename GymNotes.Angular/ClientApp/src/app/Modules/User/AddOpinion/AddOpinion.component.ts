import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

import { AddUserOpinion } from '../../../Shared/Models/AddUserOpinion';
import { AuthenticationService } from 'src/app/Auth/Authentication.service';
import { UserOpinionService } from 'src/app/Core/Services/Http/User/UserOpinion.service';

@Component({
  selector: 'app-AddOpinion',
  templateUrl: './AddOpinion.component.html',
  styleUrls: ['./AddOpinion.component.scss']
})
export class AddOpinionComponent implements OnInit {

  constructor(
    private dialogRef: MatDialogRef<AddOpinionComponent>,
    @Inject(MAT_DIALOG_DATA) public Data: any,
    private authentication: AuthenticationService,
    private opinionService: UserOpinionService) { }

  currentRate = 0;
  ratingMessage: string = 'Rating required';
  hovered = 0;
  CommentorName = '';
  UserOpinion: AddUserOpinion = {
    commenterId: '',
    opinionMessage: '',
    rating: 0,
    profileUserId: '',
  };

  ngOnInit() {
    this.CommentorName = this.authentication.UserFullName;
  }

  close(){
    this.dialogRef.close();
  }

  ratingChanged(event){
    if(event == 1)
      this.ratingMessage = 'Terrible';
    else if(event == 2)
      this.ratingMessage = 'I dont like it';
    else if(event == 3)
      this.ratingMessage = "it's ok";
    else if(event == 4)
      this.ratingMessage = "I like it";
    else if(event == 5)
      this.ratingMessage = "I love it";
  }

  ratingSelected(){
    if(this.currentRate == 1)
      this.ratingMessage = 'Terrible';
    else if(this.currentRate == 2)
      this.ratingMessage = 'I dont like it';
    else if(this.currentRate == 3)
      this.ratingMessage = "it's ok";
    else if(this.currentRate == 4)
      this.ratingMessage = "I like it";
    else if(this.currentRate == 5)
      this.ratingMessage = "I love it";
  }

  onSubmit(){
    if(this.currentRate == 0)
      return;

    this.UserOpinion.commenterId = this.authentication.UserId;
    this.UserOpinion.profileUserId = this.authentication.UserId;
    this.UserOpinion.rating = this.currentRate;

    this.opinionService.UpdateUserInfo(this.UserOpinion).subscribe(
			(res: any) => {
        this.dialogRef.close();
			},
			(err) => {

			});
  }
}
