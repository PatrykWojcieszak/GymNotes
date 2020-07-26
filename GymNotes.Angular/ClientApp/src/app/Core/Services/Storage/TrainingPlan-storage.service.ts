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

  TrainingPlan: TrainingPlan = {
    Name: '',
    Description: '',
    TrainingWeek: [{
      Name: '',
      TrainingDay: [{
        Name: '',
        TrainingExercise: [{
          ExerciseName: '',
        }]
      }]
    }],
  };

  constructor(private authentication: AuthenticationService, private fb: FormBuilder) { }

  createForm(){
    this.trainingPlanForm = this.fb.group({
      name: ['', Validators.required],
      description: ['', Validators.required],
      trainingWeek: new FormArray([ this.initWeek()]),
    });
  }

  onSubmit(){
    console.warn(this.trainingPlanForm.value);
  }

  get form(){
    return this.trainingPlanForm.controls;
  }

  getWeek(form) {
		return form.controls.trainingWeek.controls;
  }

	getDay(form) {
		return form.controls.trainingDay.controls;
  }

	getExercise(form) {
		return form.controls.trainingExercise.controls;
  }

  initWeek(){
    return new FormGroup({
      name: new FormControl(''),
      trainingDay: new FormArray([this.initDay() ])
    });
  }

  initDay(){
    return new FormGroup({
      name: new FormControl(''),
      trainingExercise: new FormArray([this.initExercise()])
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
		const control = this.trainingPlanForm.get('trainingWeek') as FormArray;
		control.push(this.initWeek());
	}

	addDay(j) {
		const control = this.trainingPlanForm.get([ 'trainingWeek', j, 'trainingDay' ]) as FormArray;
		control.push(this.initDay());
	}

	addExercise(i, j) {
		const control = this.trainingPlanForm.get([ 'trainingWeek', i, 'trainingDay', j, 'trainingExercise' ]) as FormArray;
		control.push(this.initExercise());
	}

  removeDay(j) {
		const control = this.trainingPlanForm.get([ 'trainingWeek', j, 'trainingDay' ]) as FormArray;
		control.removeAt(j);
	}

	removeWeek(i) {
		const control = this.trainingPlanForm.get('trainingWeek') as FormArray;
		control.removeAt(i);
	}

	removeExercise(i, j, k) {
		const control = this.trainingPlanForm.get([ 'trainingWeek', i, 'trainingDay', j, 'trainingExercise' ]) as FormArray;
		control.removeAt(k);
  }

  isMoreThanZeroExercise(index, i, j) {
		const control = this.trainingPlanForm.get([ 'trainingWeek', i, 'trainingDay', j, 'trainingExercise' ]) as FormArray;

		if (index + 1 === control.length) return true;
		else return false;
	}

	isMoreThanZeroDay(index, j) {
		const control = this.trainingPlanForm.get([ 'trainingWeek', j, 'trainingDay' ]) as FormArray;

		if (index + 1 === control.length) return true;
		else return false;
	}

	isMoreThanZeroWeek(index) {
		const control = this.trainingPlanForm.get('trainingWeek') as FormArray;

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
