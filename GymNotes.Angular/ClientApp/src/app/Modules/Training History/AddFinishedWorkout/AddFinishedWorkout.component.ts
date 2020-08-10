import { FormGroup, FormBuilder, Validators, FormArray, FormControl } from '@angular/forms';
import { AuthenticationService } from './../../../Auth/Authentication.service';
import { TrainingHistoryService } from './../../../Core/Services/Http/TrainingHistory/TrainingHistory.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-AddFinishedWorkout',
  templateUrl: './AddFinishedWorkout.component.html',
  styleUrls: ['./AddFinishedWorkout.component.scss']
})
export class AddFinishedWorkoutComponent implements OnInit {

  workoutForm: FormGroup;

  showElement = '';

  trainingPlanList: {
    elementName: string[],
    elementId: number[],
  };

  trainingWeekList: {
    elementName: string[],
    elementId: number[],
  };

  trainingDayList: {
    elementName: string[],
    elementId: number[],
  };

  submitted = false;

  constructor(
    private trainingHistory: TrainingHistoryService,
    private authentication: AuthenticationService,
    private fb: FormBuilder) { }

  ngOnInit() {

    this.workoutForm = this.fb.group({
      workoutName: ['', Validators.required],
      trainingExercise: new FormArray([this.initExercise()]),
    });

    this.trainingPlanList = { elementName: new Array<string>(), elementId: new Array<number>()};
    this.trainingWeekList = { elementName: new Array<string>(), elementId: new Array<number>()};
    this.trainingDayList = { elementName: new Array<string>(), elementId: new Array<number>()};


    const parameters = [this.authentication.UserId];

    this.trainingHistory.GetTrainingPlan(parameters).subscribe((x: any) => {
      this.trainingPlanList = x;
      console.warn(x);
    });
  }

  get form() {
		return this.workoutForm.controls;
  }

  initExercise(){
    return new FormGroup({
      exerciseName: new FormControl(''),
      sets: new FormControl(''),
      reps: new FormControl(''),
      tempo: new FormControl(''),
      rest: new FormControl(''),
      rpe: new FormControl(''),
      weight: new FormControl(''),
      description: new FormControl(''),
    });
  }

  getExercise(form) {
		return form.controls.trainingExercise.controls;
  }

  addExercise() {
    const control = this.workoutForm.get('trainingExercise') as FormArray;
		control.push(this.initExercise());
  }

  removeExercise(j) {
		const control = this.workoutForm.get(['trainingExercise']) as FormArray;
		control.removeAt(j);
  }

  toggle(componentName: string) {
    this.showElement = componentName;
  }

  isMoreThanZeroExercise(index) {
		const control = this.workoutForm.get('trainingExercise') as FormArray;

		if (index + 1 === control.length) return true;
		else return false;
  }

  onTrainingPlanSelected(data){
    const parameters = [this.trainingPlanList.elementId[data]];
    console.warn(data);
    this.trainingHistory.GetTrainingWeek(parameters).subscribe((x: any) => {
      this.trainingWeekList = x;
      console.warn(x);
    });
  }

  onTrainingWeekSelected(data){
    const parameters = [this.trainingWeekList.elementId[data]];

    this.trainingHistory.GetTrainingDay(parameters).subscribe((x: any) => {
      this.trainingDayList = x;
      console.warn(x);
    });
  }

  onTrainingDaySelected(data){

  }

  onSubmitExercise(){
    this.submitted = true;
  }
}
