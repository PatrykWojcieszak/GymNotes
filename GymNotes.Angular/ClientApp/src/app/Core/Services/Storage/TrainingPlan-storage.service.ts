import { AuthenticationService } from './../../../Auth/Authentication.service';
import { TrainingDay } from './../../../Shared/Models/Training/TrainingDay';
import { TrainingWeek } from './../../../Shared/Models/Training/TrainingWeek';
import { Injectable } from '@angular/core';

import { TrainingPlan } from 'src/app/Shared/Models/Training/TrainingPlan';

@Injectable({
  providedIn: 'root'
})
export class TrainingPlanStorageService {

  TrainingWeek: string[] = [];

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

  constructor(private authentication: AuthenticationService) { }

  addWeek(item){
    this.authentication.getTokenExpirationDate();
    this.TrainingWeek.push(item);
  }
}
