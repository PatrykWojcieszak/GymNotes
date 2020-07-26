import { Injectable } from '@angular/core';
import { APIService } from '../API/API.service';

@Injectable({
  providedIn: 'root'
})
export class TrainingPlanService {

  private CONTROLLER = 'TrainingPlan/';
  private CREATE_TRAINING_PLAN = 'create';

  constructor(private API: APIService) { }

  public Create(model) {
		return this.API.Post(model, this.API.BuildAddress(this.CONTROLLER, this.CREATE_TRAINING_PLAN, null));
	}
}
