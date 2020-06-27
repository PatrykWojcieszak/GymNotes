import { FormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { AddTrainingPlanComponent } from './AddTrainingPlan/AddTrainingPlan.component';
import { TrainingListComponent } from './TrainingList/TrainingList.component';

import { TrainingPlanRoutingModule } from './trainingPlan-routing.module';

@NgModule({
  declarations: [
    TrainingListComponent,
    AddTrainingPlanComponent
  ],
  imports: [
    CommonModule,
    RouterModule,
    FormsModule,
    TrainingPlanRoutingModule,
  ],
})
export class TrainingPlanModule { }
