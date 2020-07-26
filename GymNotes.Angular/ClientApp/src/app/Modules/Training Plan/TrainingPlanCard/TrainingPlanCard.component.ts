import { TrainingWeek } from './../../../Shared/Models/Training/TrainingWeek';
import { Component, OnInit, Input } from '@angular/core';

import { TrainingPlan } from 'src/app/Shared/Models/Training/TrainingPlan';

@Component({
  selector: 'app-TrainingPlanCard',
  templateUrl: './TrainingPlanCard.component.html',
  styleUrls: ['./TrainingPlanCard.component.scss']
})
export class TrainingPlanCardComponent implements OnInit {

  @Input() TrainingPlan: TrainingPlan = {
    name: '',
    description: '',
    id: 0,
    modifiedTime: null,
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

  constructor() { }

  ngOnInit() {
    console.warn(this.TrainingPlan);
  }

}
