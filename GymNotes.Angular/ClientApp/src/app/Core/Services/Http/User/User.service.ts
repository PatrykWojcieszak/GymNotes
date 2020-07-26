import { APIService } from './../API/API.service';
import { Injectable } from '@angular/core';
import { HttpParams } from '@angular/common/http';

@Injectable({
	providedIn: 'root'
})
export class UserService {
	private CONTROLLER = 'user/';
	private GET_USER = 'getUser';
	private GET_USERS = 'search';
	private UPDATE_USER = 'updateUser';
	private LOGIN_USER = 'authenticate';
	private REGISTER_USER = 'register';
	private REFRESH_TOKEN = 'refresh-token';
	private CONFIRM_EMAIL_ADDRESS = 'confirmEmailAddress';
	private RESET_PASSWORD = 'resetPassword';
	private FORGOT_PASSWORD = 'forgotPassword';
	private UPDATE_USER_INFO = 'updateUserInfo';
	private GET_UPDATE_USER_INFO = 'getUserUpdateInfo';
	private ADD_OR_UPDATE_USER_ACHIEVEMENT = 'addOrUpdateUserAchievements';
	private GET_USER_ACHIEVEMENTS_LIST = 'getUserAchievementsList';
	private GET_USER_ACHIEVEMENTS = 'getUserAchievements';
	private DELETE_USER_ACHIEVEMENTS = 'deleteUserAchievement';
	private DELETE_USER_ACHIEVEMENTS_LIST = 'deleteUserAchievementsList';


	Parameters: string[];

	constructor(private API: APIService) {}

	public GetUser(parameters) {
		return this.API.Get(this.API.BuildAddress(this.CONTROLLER, this.GET_USER, parameters));
	}

	public GetUsers(model) {
		return this.API.Post(model, this.API.BuildAddress(this.CONTROLLER, this.GET_USERS, this.Parameters));
	}

	public Login(loginModel) {
		return this.API.Post(loginModel, this.API.BuildAddress(this.CONTROLLER, this.LOGIN_USER, null));
	}

	public Register(registerModel) {
		return this.API.Post(registerModel, this.API.BuildAddress(this.CONTROLLER, this.REGISTER_USER, null));
  }

	public RefreshToken() {
		return this.API.Post(null, this.API.BuildAddress(this.CONTROLLER, this.REFRESH_TOKEN, null));
	}

	public ConfirmEmail(confirmEmailModel) {
		return this.API.Post(confirmEmailModel, this.API.BuildAddress(this.CONTROLLER, this.CONFIRM_EMAIL_ADDRESS, null));
	}

	public ForgotPassword(forgotPasswordModel) {
		return this.API.Post(forgotPasswordModel, this.API.BuildAddress(this.CONTROLLER, this.FORGOT_PASSWORD, null));
	}

	public ResetPassword(resetPasswordModel) {
		return this.API.Post(resetPasswordModel, this.API.BuildAddress(this.CONTROLLER, this.RESET_PASSWORD, null));
	}

	public UpdateUserInfo(userInfoModel, parameters) {
		return this.API.Post(userInfoModel, this.API.BuildAddress(this.CONTROLLER, this.UPDATE_USER_INFO, parameters));
	}

	public GetUserUpdateInfo(parameters){
		return this.API.Get(this.API.BuildAddress(this.CONTROLLER, this.GET_UPDATE_USER_INFO, parameters));
	}

	public AddOrUpdateUserAchievements(achievementsModel, parameters){
		return this.API.Post(achievementsModel, this.API.BuildAddress(this.CONTROLLER, this.ADD_OR_UPDATE_USER_ACHIEVEMENT, parameters));
	}

	public GetUserAchievementsList(parameters){
		return this.API.Get(this.API.BuildAddress(this.CONTROLLER, this.GET_USER_ACHIEVEMENTS_LIST, parameters));
	}

	public GetUserAchievements(parameters){
		return this.API.Get(this.API.BuildAddress(this.CONTROLLER, this.GET_USER_ACHIEVEMENTS, parameters));
	}

	public DeleteUserAchievementsList(parameters){
		return this.API.Delete(this.API.BuildAddress(this.CONTROLLER, this.DELETE_USER_ACHIEVEMENTS_LIST, parameters));
	}

	public DeleteUserAchievements(parameters){
		return this.API.Delete(this.API.BuildAddress(this.CONTROLLER, this.DELETE_USER_ACHIEVEMENTS, parameters));
	}
}
