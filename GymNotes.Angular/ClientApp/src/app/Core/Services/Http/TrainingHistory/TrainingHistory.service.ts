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
  private ADD_FINISHED_WORKOUT = 'add';
  private GET_WORKOUT_HISTORY = 'history';
  private DELETE = 'delete';

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

  public GetWorkoutHistory(parameters) {
		return this.API.Get(this.API.BuildAddress(this.CONTROLLER, this.GET_WORKOUT_HISTORY, parameters));
  }

  public AddFinishedWorkout(model) {
		return this.API.Post(model, this.API.BuildAddress(this.CONTROLLER, this.ADD_FINISHED_WORKOUT, null));
  }

  public DeleteWorkout(parameters) {
		return this.API.Delete(this.API.BuildAddress(this.CONTROLLER, this.DELETE, parameters));
  }
}
