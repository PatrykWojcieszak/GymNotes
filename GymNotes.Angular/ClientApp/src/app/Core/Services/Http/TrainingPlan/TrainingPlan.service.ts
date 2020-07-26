import { Injectable } from '@angular/core';
import { APIService } from '../API/API.service';

@Injectable({
  providedIn: 'root'
})
export class TrainingPlanService {

  private CONTROLLER = 'TrainingPlan/';
  private CREATE_TRAINING_PLAN = 'create';
  private GET = 'get';
  private GET_ALL = 'getAll';

  constructor(private API: APIService) { }

  public Create(model) {
		return this.API.Post(model, this.API.BuildAddress(this.CONTROLLER, this.CREATE_TRAINING_PLAN, null));
  }

  public GetTrainingPlan(parameters) {
		return this.API.Get(this.API.BuildAddress(this.CONTROLLER, this.GET, parameters));
  }

  public GetAll(parameters) {
		return this.API.Get(this.API.BuildAddress(this.CONTROLLER, this.GET_ALL, parameters));
	}
}
