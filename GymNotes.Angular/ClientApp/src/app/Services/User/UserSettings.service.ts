import { Injectable } from '@angular/core';
import { APIService } from '../API/API.service';

@Injectable({
  providedIn: 'root'
})
export class UserSettingsService {

  private CONTROLLER: string = 'UserSettings/';
  private CHANGE_NAME: string = 'changeName';
  private CHANGE_PASSWORD: string = 'changePassword';
  private CHANGE_EMAIL: string = 'changeEmail';
  private GET_USER_FULL_NAME: string = 'getUserFullName';
  private GET_USER_EMAIL: string = 'getUserEmail';
  
constructor(private API: APIService) { }

  public ChangeName(model) {
		return this.API.Post(model, this.API.BuildAddress(this.CONTROLLER, this.CHANGE_NAME, null));
  }

  public ChangePassword(model) {
		return this.API.Post(model, this.API.BuildAddress(this.CONTROLLER, this.CHANGE_PASSWORD, null));
  }

  public ChangeEmail(model) {
		return this.API.Post(model, this.API.BuildAddress(this.CONTROLLER, this.CHANGE_EMAIL, null));
  }

  public GetUserFullName(parameters) {
		return this.API.Get(this.API.BuildAddress(this.CONTROLLER, this.GET_USER_FULL_NAME, parameters));
  }

  public GetUserEmail(parameters) {
		return this.API.Get(this.API.BuildAddress(this.CONTROLLER, this.GET_USER_EMAIL, parameters));
  }
}
