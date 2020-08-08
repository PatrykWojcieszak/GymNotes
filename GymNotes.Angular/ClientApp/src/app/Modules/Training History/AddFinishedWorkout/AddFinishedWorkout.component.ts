import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-AddFinishedWorkout',
  templateUrl: './AddFinishedWorkout.component.html',
  styleUrls: ['./AddFinishedWorkout.component.scss']
})
export class AddFinishedWorkoutComponent implements OnInit {

  showElement = '';

  trainingPlanList: any [] = [];
  trainingWeekList: any[] = [];
  trainingDayList: any[] = [];

  constructor() { }

  ngOnInit() {
  }

  toggle(componentName: string) {
    this.showElement = componentName;
  }

  onTrainingPlanSelected(data){

  }

  onTrainingWeekSelected(data){

  }

  onTrainingDaySelected(data){

  }
}
