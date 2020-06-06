import { APIService } from './../API/API.service';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class UserInfoService {

  private CONTROLLER: string = 'UserInfo/';
  private UPDATE_INSTAGRAM_URL: string = 'updateInstagramUrl';
  private UPDATE_FACEBOOK_URL: string = 'updateFacebookUrl';
  private UPDATE_TWITTER_URL: string = 'updateTwitterUrl';
  private UPDATE_YOUTUBE_URL: string = 'updateYoutubeUrl';
  private UPDATE_DESCRIPTION: string = 'updateDescription';
  private UPDATE_DISCIPLINE: string = 'updateDiscipline';
  private UPDATE_GENDER: string = 'updateGender';
  private UPDATE_YEARS_OF_EXPERIENCE: string = 'updateYearsOfExperience';
  private UPDATE_HEIGHT: string = 'updateHeight';
  private UPDATE_IS_COACH: string = 'updateIsCoach';
  private UPDATE_BIRTHDAY: string = 'updateBirthday';
  
constructor(private API: APIService) { }

  public UpdateInstagramUrl(model) {
		return this.API.Post(model, this.API.BuildAddress(this.CONTROLLER, this.UPDATE_INSTAGRAM_URL, null));
  }
  
  public UpdateFacebookUrl(model) {
		return this.API.Post(model, this.API.BuildAddress(this.CONTROLLER, this.UPDATE_FACEBOOK_URL, null));
  }

  public UpdateTwitterUrl(model) {
		return this.API.Post(model, this.API.BuildAddress(this.CONTROLLER, this.UPDATE_TWITTER_URL, null));
  }

  public UpdateYoutubeUrl(model) {
		return this.API.Post(model, this.API.BuildAddress(this.CONTROLLER, this.UPDATE_YOUTUBE_URL, null));
  }

  public UpdateDescription(model) {
		return this.API.Post(model, this.API.BuildAddress(this.CONTROLLER, this.UPDATE_DESCRIPTION, null));
  }

  public UpdateDiscipline(model) {
		return this.API.Post(model, this.API.BuildAddress(this.CONTROLLER, this.UPDATE_DISCIPLINE, null));
  }

  public UpdateGender(model) {
		return this.API.Post(model, this.API.BuildAddress(this.CONTROLLER, this.UPDATE_GENDER, null));
  }

  public UpdateYearsOfExperience(model) {
		return this.API.Post(model, this.API.BuildAddress(this.CONTROLLER, this.UPDATE_YEARS_OF_EXPERIENCE, null));
  }

  public UpdateHeight(model) {
		return this.API.Post(model, this.API.BuildAddress(this.CONTROLLER, this.UPDATE_HEIGHT, null));
  }

  public UpdateBirthday(model) {
		return this.API.Post(model, this.API.BuildAddress(this.CONTROLLER, this.UPDATE_BIRTHDAY, null));
  }

  public UpdateIsCoach(model) {
		return this.API.Post(model, this.API.BuildAddress(this.CONTROLLER, this.UPDATE_IS_COACH, null));
  }
}
