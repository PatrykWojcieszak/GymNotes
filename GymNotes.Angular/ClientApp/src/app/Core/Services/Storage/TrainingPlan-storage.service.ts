import { TrainingPlanService } from './../Http/TrainingPlan/TrainingPlan.service';
import { FormGroup, FormBuilder, Validators, FormArray, FormControl } from '@angular/forms';
import { AuthenticationService } from './../../../Auth/Authentication.service';
import { TrainingDay } from './../../../Shared/Models/Training/TrainingDay';
import { TrainingWeek } from './../../../Shared/Models/Training/TrainingWeek';
import { Injectable } from '@angular/core';

import { TrainingPlan } from 'src/app/Shared/Models/Training/TrainingPlan';

@Injectable({
  providedIn: 'root'
})
export class TrainingPlanStorageService {

  trainingPlanForm: FormGroup;

  validForNextStep = false;
  submittedNextStep = false;

  constructor(private authentication: AuthenticationService, private fb: FormBuilder, private trainingPlanService: TrainingPlanService) { }

  createForm(){
    this.trainingPlanForm = this.fb.group({
      name: ['', Validators.required],
      description: ['', Validators.required],
      creatorId: this.authentication.UserId,
      ownerId: this.authentication.UserId,
      trainingWeeks: new FormArray([ this.initWeek()]),
    });
  }

  onSubmit(){
    console.warn(this.trainingPlanForm.value);

    if(this.trainingPlanForm.invalid)
      return

    this.trainingPlanService.Create(this.trainingPlanForm.value).subscribe(x => console.warn(x));
  }

  get form(){
    return this.trainingPlanForm.controls;
  }

  getWeek(form) {
		return form.controls.trainingWeeks.controls;
  }

	getDay(form) {
		return form.controls.trainingDays.controls;
  }

	getExercise(form) {
		return form.controls.trainingExercises.controls;
  }

  initWeek(){
    return new FormGroup({
      name: new FormControl(''),
      trainingDays: new FormArray([this.initDay() ])
    });
  }

  initDay(){
    return new FormGroup({
      name: new FormControl(''),
      trainingExercises: new FormArray([this.initExercise()])
    });
  }

  initExercise(){
    return new FormGroup({
      exerciseName: new FormControl(''),
      sets: new FormControl(''),
      reps: new FormControl(''),
      tempo: new FormControl(''),
      rest: new FormControl(''),
      rPE: new FormControl(''),
      weight: new FormControl(''),
      description: new FormControl(''),
    });
  }

  addWeek() {
		const control = this.trainingPlanForm.get('trainingWeeks') as FormArray;
		control.push(this.initWeek());
	}

	addDay(j) {
		const control = this.trainingPlanForm.get([ 'trainingWeeks', j, 'trainingDays' ]) as FormArray;
		control.push(this.initDay());
	}

	addExercise(i, j) {
		const control = this.trainingPlanForm.get([ 'trainingWeeks', i, 'trainingDays', j, 'trainingExercises' ]) as FormArray;
		control.push(this.initExercise());
	}

  removeDay(j) {
		const control = this.trainingPlanForm.get([ 'trainingWeeks', j, 'trainingDays' ]) as FormArray;
		control.removeAt(j);
	}

	removeWeek(i) {
		const control = this.trainingPlanForm.get('trainingWeeks') as FormArray;
		control.removeAt(i);
	}

	removeExercise(i, j, k) {
		const control = this.trainingPlanForm.get([ 'trainingWeeks', i, 'trainingDays', j, 'trainingExercises' ]) as FormArray;
		control.removeAt(k);
  }

  isMoreThanZeroExercise(index, i, j) {
		const control = this.trainingPlanForm.get([ 'trainingWeeks', i, 'trainingDays', j, 'trainingExercises' ]) as FormArray;

		if (index + 1 === control.length) return true;
		else return false;
	}

	isMoreThanZeroDay(index, j) {
		const control = this.trainingPlanForm.get([ 'trainingWeeks', j, 'trainingDays' ]) as FormArray;

		if (index + 1 === control.length) return true;
		else return false;
	}

	isMoreThanZeroWeek(index) {
		const control = this.trainingPlanForm.get('trainingWeeks') as FormArray;

		if (index + 1 === control.length) return true;
		else return false;
  }

  onNextStep(){
    this.submittedNextStep = true;

    if(this.trainingPlanForm.invalid){
      return;
    }

    this.validForNextStep = true;
  }
}
