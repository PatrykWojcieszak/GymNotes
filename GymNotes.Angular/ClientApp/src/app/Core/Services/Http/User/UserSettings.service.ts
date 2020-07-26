import { Injectable } from '@angular/core';
import { APIService } from '../API/API.service';

@Injectable({
  providedIn: 'root'
})
export class UserSettingsService {

  private CONTROLLER = 'UserSettings/';
  private CHANGE_NAME = 'changeName';
  private CHANGE_PASSWORD = 'changePassword';
  private CHANGE_EMAIL = 'changeEmail';
  private GET_USER_FULL_NAME = 'getUserFullName';
  private GET_USER_EMAIL = 'getUserEmail';

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
