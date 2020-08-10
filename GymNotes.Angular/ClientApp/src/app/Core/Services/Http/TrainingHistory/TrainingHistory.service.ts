import { Injectable } from '@angular/core';
import { APIService } from '../API/API.service';

@Injectable({
  providedIn: 'root'
})
export class TrainingHistoryService {

  private CONTROLLER = 'TrainingHistory/';
  private GET_TRAINING_PLAN = 'getPlans';
  private GET_TRAINING_WEEK = 'getWeeks';
  private GET_TRAINING_DAY = 'getDays';

  constructor(private API: APIService) { }

  public GetTrainingPlan(parameters) {
		return this.API.Get(this.API.BuildAddress(this.CONTROLLER, this.GET_TRAINING_PLAN, parameters));
  }

  public GetTrainingWeek(parameters) {
		return this.API.Get(this.API.BuildAddress(this.CONTROLLER, this.GET_TRAINING_WEEK, parameters));
  }

  public GetTrainingDay(parameters) {
		return this.API.Get(this.API.BuildAddress(this.CONTROLLER, this.GET_TRAINING_DAY, parameters));
  }
}
