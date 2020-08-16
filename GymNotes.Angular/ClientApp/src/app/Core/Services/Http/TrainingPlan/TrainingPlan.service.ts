import { Injectable } from '@angular/core';
import { APIService } from '../API/API.service';

@Injectable({
	providedIn: 'root'
})
export class TrainingPlanService {
	private CONTROLLER = 'TrainingPlan/';
	private CREATE_TRAINING_PLAN = 'create';
	private UPDATE_TRAINING_PLAN = 'update';
	private GET = 'get';
	private GET_ALL = 'search';
	private FAVORITE = 'favorite';
	private MAIN = 'main';
	private DELETE = 'delete';
	private GET_EXERCISE = 'getExercise';

	constructor(private API: APIService) {}

	public Create(model) {
		return this.API.Post(model, this.API.BuildAddress(this.CONTROLLER, this.CREATE_TRAINING_PLAN, null));
	}

	public Update(model, parameters) {
		return this.API.Post(model, this.API.BuildAddress(this.CONTROLLER, this.UPDATE_TRAINING_PLAN, parameters));
	}

	public GetTrainingPlan(parameters) {
		return this.API.Get(this.API.BuildAddress(this.CONTROLLER, this.GET, parameters));
	}

	public GetExercises(parameters) {
		return this.API.Get(this.API.BuildAddress(this.CONTROLLER, this.GET_EXERCISE, parameters));
	}

	public GetAll(model, parameters) {
		return this.API.Post(model, this.API.BuildAddress(this.CONTROLLER, this.GET_ALL, parameters));
	}

	public ToggleFavorite(parameters) {
		return this.API.Post(null, this.API.BuildAddress(this.CONTROLLER, this.FAVORITE, parameters));
	}

	public ToggleMain(parameters) {
		return this.API.Post(null, this.API.BuildAddress(this.CONTROLLER, this.MAIN, parameters));
	}

	public Delete(parameters) {
		return this.API.Post(null, this.API.BuildAddress(this.CONTROLLER, this.DELETE, parameters));
	}
}
