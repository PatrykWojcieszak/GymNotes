import { FormBuilder, FormGroup, Validators, FormArray, FormControl } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from 'src/app/Auth/Authentication.service';
import { TrainingPlanService } from 'src/app/Core/Services/Http/TrainingPlan/TrainingPlan.service';
import { ActivatedRoute, Params } from '@angular/router';
import { TrainingPlan } from 'src/app/Shared/Models/Training/TrainingPlan';
import { param } from 'jquery';
import { SpinnerOverlayService } from 'src/app/Core/Services/Utility/SpinnerOverlay.service';

@Component({
  selector: 'app-AddTrainingPlan',
  templateUrl: './AddTrainingPlan.component.html',
  styleUrls: ['./AddTrainingPlan.component.scss']
})
export class AddTrainingPlanComponent implements OnInit {

  trainingPlanForm: FormGroup;

  validForNextStep = false;
  submittedNextStep = false;

  trainingPlanId: number;

  trainingPlan: TrainingPlan = {
    name: '',
    description: '',
    id: 0,
    modifiedTime: null,
    isMain: false,
    isFavorite: false,
    creator: null,
    owner: null,
    trainingWeeks: [{
      name: '',
      trainingDays: [{
        name: '',
        trainingExercises: [{
          exerciseName: '',
        }]
      }]
    }],
  };

  constructor(
    private authentication: AuthenticationService,
    private fb: FormBuilder,
    private trainingPlanService: TrainingPlanService,
    private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.params.subscribe((params: Params) => {
      this.trainingPlanId = params.id;

      if(params.id)
      {
        this.trainingPlanForm = this.fb.group({
          id: [''],
          name: ['', Validators.required],
          description: ['', Validators.required],
          creatorId: this.authentication.UserId,
          ownerId: this.authentication.UserId,
          trainingWeeks: new FormArray([ ]),
        });

        const parameters = [params.id];

        this.trainingPlanService.GetTrainingPlan(parameters).subscribe( (res: TrainingPlan) => {
          this.trainingPlan = res;
          console.warn(res);
          this.loadForm(res);
        })
      }
      else{
        this.createForm();
      }
    });
  }

  createForm(){
    this.trainingPlanForm = this.fb.group({
      id: [''],
      name: ['', Validators.required],
      description: ['', Validators.required],
      creatorId: this.authentication.UserId,
      ownerId: this.authentication.UserId,
      trainingWeeks: new FormArray([ this.initWeek()]),
    });
  }

  loadForm(object: TrainingPlan) {


    for (let week = 0; week < Object.keys(object.trainingWeeks).length; week++) {
			this.addWeek();

			for (let day = 0; day < Object.keys(object.trainingWeeks[week].trainingDays).length - 1; day++) {
				this.addDay(day);

				for (let exercise = 0; exercise < Object.keys(object.trainingWeeks[week].trainingDays[day].trainingExercises).length - 1; exercise++) {
					this.addExercise(week, day);
				}
			}
		}

    this.trainingPlanForm.patchValue(this.trainingPlan);
    this.onNextStep();
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
      rpe: new FormControl(''),
      weight: new FormControl(''),
      description: new FormControl(''),
    });
  }

  addWeek() {
    const control = this.trainingPlanForm.get('trainingWeeks') as FormArray;
    console.warn('forma tydzień: ' + control);
		control.push(this.initWeek());
	}

	addDay(j) {
    const control = this.trainingPlanForm.get([ 'trainingWeeks', j, 'trainingDays' ]) as FormArray;
    console.warn('forma dzień: ' + control);
		control.push(this.initDay());
	}

	addExercise(i, j) {
    const control = this.trainingPlanForm.get([ 'trainingWeeks', i, 'trainingDays', j, 'trainingExercises' ]) as FormArray;
    console.warn('forma ćwiczenie: ' + control);
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
