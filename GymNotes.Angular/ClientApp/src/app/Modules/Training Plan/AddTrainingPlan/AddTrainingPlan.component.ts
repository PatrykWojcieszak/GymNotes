import { FormBuilder, FormGroup, Validators, FormArray, FormControl } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from 'src/app/Auth/Authentication.service';
import { TrainingPlanService } from 'src/app/Core/Services/Http/TrainingPlan/TrainingPlan.service';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { TrainingPlan } from 'src/app/Shared/Models/Training/TrainingPlan';
import { param } from 'jquery';
import { SpinnerOverlayService } from 'src/app/Core/Services/Utility/SpinnerOverlay.service';
import { startLoadingIndicator, stopLoadingIndicator } from '@btapai/ng-loading-indicator';
import { Subscription } from 'rxjs';

@Component({
	selector: 'app-AddTrainingPlan',
	templateUrl: './AddTrainingPlan.component.html',
	styleUrls: [ './AddTrainingPlan.component.scss' ]
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
		modifiedAt: null,
		isMain: false,
		isFavorite: false,
		creator: null,
		owner: null,
		trainingWeeks: [
			{
				name: '',
				trainingDays: [
					{
						name: '',
						trainingExercises: [
							{
								exerciseName: ''
							}
						]
					}
				]
			}
		]
	};

	editMode = false;
	isLoading = true;

	constructor(
		private authentication: AuthenticationService,
		private fb: FormBuilder,
		private trainingPlanService: TrainingPlanService,
		private route: ActivatedRoute,
		public spinner: SpinnerOverlayService,
		private router: Router
	) {}

	ngOnInit() {
		this.route.params.subscribe((params: Params) => {
			this.trainingPlanId = params.id;
			this.editMode = params.editMode;
			if (params.id) {
				this.trainingPlanForm = this.fb.group({
					id: [ '' ],
					name: [ '', Validators.required ],
					description: [ '', Validators.required ],
					creatorId: this.authentication.UserId,
					ownerId: this.authentication.UserId,
					trainingWeeks: new FormArray([])
				});

				const parameters = [ params.id ];

				this.trainingPlanService.GetTrainingPlan(parameters).subscribe((res: TrainingPlan) => {
					this.trainingPlan = res;
					this.loadForm(res);
					console.warn(res);
					this.isLoading = false;
				});
			} else {
				this.createForm();
				this.isLoading = false;
			}
		});
	}

	createForm() {
		this.trainingPlanForm = this.fb.group({
			id: [ '0' ],
			name: [ '', Validators.required ],
			description: [ '', Validators.required ],
			creatorId: this.authentication.UserId,
			ownerId: this.authentication.UserId,
			trainingWeeks: new FormArray([ this.initWeek() ])
		});
	}

	loadForm(object: TrainingPlan) {
		for (let week = 0; week < Object.keys(object.trainingWeeks).length; week++) {
			this.addWeek();

			for (let day = 0; day < Object.keys(object.trainingWeeks[week].trainingDays).length - 1; day++) {
				this.addDay(day);

				for (
					let exercise = 0;
					exercise < Object.keys(object.trainingWeeks[week].trainingDays[day].trainingExercises).length - 1;
					exercise++
				) {
					this.addExercise(week, day);
				}
			}
		}

		this.trainingPlanForm.patchValue(this.trainingPlan);
		this.onNextStep();
	}

	onSubmit() {
		console.warn(this.trainingPlanForm.value);

		this.trainingPlanForm.markAllAsTouched();
		console.warn(this.trainingPlanForm.invalid);
		if (this.trainingPlanForm.invalid) return;

		console.warn(this.editMode);
		if (this.editMode) {
			console.warn('edit');
			const parameters = [ this.authentication.UserId ];

			this.trainingPlanService
				.Update(this.trainingPlanForm.value, parameters)
				.subscribe((x) => this.router.navigateByUrl('/training-list'));
		} else {
			this.trainingPlanService
				.Create(this.trainingPlanForm.value)
				.subscribe((x) => this.router.navigateByUrl('/training-list'));
		}
	}

	get form() {
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

	initWeek() {
		return new FormGroup({
			id: new FormControl('0'),
			name: new FormControl('', Validators.required),
			trainingDays: new FormArray([ this.initDay() ])
		});
	}

	initDay() {
		return new FormGroup({
			id: new FormControl('0'),
			name: new FormControl('', Validators.required),
			trainingExercises: new FormArray([ this.initExercise() ])
		});
	}

	initExercise() {
		return new FormGroup({
			id: new FormControl('0'),
			exerciseName: new FormControl('', Validators.required),
			sets: new FormControl('', Validators.required),
			reps: new FormControl(''),
			tempo: new FormControl(''),
			rest: new FormControl(''),
			rpe: new FormControl(''),
			weight: new FormControl(''),
			description: new FormControl('')
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
		const control = this.trainingPlanForm.get([
			'trainingWeeks',
			i,
			'trainingDays',
			j,
			'trainingExercises'
		]) as FormArray;
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
		const control = this.trainingPlanForm.get([
			'trainingWeeks',
			i,
			'trainingDays',
			j,
			'trainingExercises'
		]) as FormArray;
		control.removeAt(k);
	}

	isMoreThanZeroExercise(index, i, j) {
		const control = this.trainingPlanForm.get([
			'trainingWeeks',
			i,
			'trainingDays',
			j,
			'trainingExercises'
		]) as FormArray;

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

	onNextStep() {
		this.submittedNextStep = true;

		if (!this.trainingPlanForm.controls.name.valid || !this.trainingPlanForm.controls.description.valid) {
			return;
		}

		this.validForNextStep = true;
	}
}
