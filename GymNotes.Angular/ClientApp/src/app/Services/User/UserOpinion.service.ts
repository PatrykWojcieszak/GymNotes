import { Injectable } from '@angular/core';
import { APIService } from '../API/API.service';

@Injectable({
  providedIn: 'root'
})
export class UserOpinionService {

  private CONTROLLER: string = 'UserOpinion/';
	private ADD_USER_OPINION: string = 'addUserOpinion';
  private ADD_LIKE_TO_OPINION: string = 'addLikeToOpinion';
  private REMOVE_LIKE_FROM_OPINION: string = 'removeLikeFromOpinion';
  private GET_USER_OPINION: string = 'getUserOpinions';
  
constructor(private API: APIService) { }

  public UpdateUserInfo(userOpinionModel) {
		return this.API.Post(userOpinionModel, this.API.BuildAddress(this.CONTROLLER, this.ADD_USER_OPINION, null));
  }
  
  public AddLikeToOpinion(userOpinionLikeModel){
    return this.API.Post(userOpinionLikeModel, this.API.BuildAddress(this.CONTROLLER, this.ADD_LIKE_TO_OPINION, null));
  }

  public RemoveLikeFromOpinion(parameters){
    return this.API.Delete(this.API.BuildAddress(this.CONTROLLER, this.REMOVE_LIKE_FROM_OPINION, parameters));
  }

  public GetUserOpinion(parameters){
    return this.API.Get(this.API.BuildAddress(this.CONTROLLER, this.GET_USER_OPINION, parameters));
  }
}
