import { TrainingPlanStorageService } from './../../../Core/Services/Storage/TrainingPlan-storage.service';
import { Router, ActivatedRoute } from '@angular/router';
import { Component, OnInit, Input } from '@angular/core';

import { ConfirmationDialogService } from './../../../Core/Services/Utility/ConfirmationDialog.service';
import { TrainingPlanService } from './../../../Core/Services/Http/TrainingPlan/TrainingPlan.service';
import { AuthenticationService } from './../../../Auth/Authentication.service';
import { TrainingPlan } from 'src/app/Shared/Models/Training/TrainingPlan';

@Component({
	selector: 'app-TrainingPlanCard',
	templateUrl: './TrainingPlanCard.component.html',
	styleUrls: [ './TrainingPlanCard.component.scss' ]
})
export class TrainingPlanCardComponent implements OnInit {
	@Input()
	TrainingPlan: TrainingPlan = {
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

	constructor(
		private authentication: AuthenticationService,
		private trainingPlanService: TrainingPlanService,
		private confirmationDialogService: ConfirmationDialogService,
		private router: Router,
		private route: ActivatedRoute,
		private trainingStorage: TrainingPlanStorageService
	) {}

	ngOnInit() {
		console.warn(this.TrainingPlan);
	}

	onDelete() {
		this.confirmationDialogService
			.confirm('Please confirm..', 'Do you really want to delete ' + this.TrainingPlan.name + '?')
			.then((confirmed) => {
				const parameters = [ this.authentication.UserId, this.TrainingPlan.id ];

				this.trainingPlanService.Delete(parameters).subscribe((x) => console.warn(x));

				const index = this.trainingStorage.trainingPlan.items.indexOf(this.TrainingPlan, 0);
				this.trainingStorage.trainingPlan.items.splice(index, 1);
			})
			.catch(() =>
				console.log(
					'User dismissed the dialog (e.g., by using ESC, clicking the cross icon, or clicking outside the dialog)'
				)
			);
	}

	onToggleFavorite() {
		const parameters = [ this.TrainingPlan.id, !this.TrainingPlan.isFavorite ];
		this.TrainingPlan.isFavorite = !this.TrainingPlan.isFavorite;

		this.trainingPlanService.ToggleFavorite(parameters).subscribe((x) => console.warn(x));
	}

	onToggleMain() {
		const parameters = [ this.authentication.UserId, this.TrainingPlan.id, !this.TrainingPlan.isMain ];
		this.TrainingPlan.isMain = !this.TrainingPlan.isMain;

		this.trainingPlanService.ToggleMain(parameters).subscribe((x) => console.warn(x));
	}

	onTrainingPlanSelected() {
		this.router.navigate([ 'add-training-plan/', this.TrainingPlan.id ], { relativeTo: this.route });
	}
}
