import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { TrainingPlanCardComponent } from './TrainingPlanCard/TrainingPlanCard.component';
import { AddTrainingPlanComponent } from './AddTrainingPlan/AddTrainingPlan.component';
import { TrainingListComponent } from './TrainingList/TrainingList.component';

import { TrainingPlanRoutingModule } from './trainingPlan-routing.module';

@NgModule({
  declarations: [
    TrainingListComponent,
    AddTrainingPlanComponent,
    TrainingPlanCardComponent
  ],
  imports: [
    CommonModule,
    RouterModule,
    FormsModule,
    ReactiveFormsModule,
    TrainingPlanRoutingModule,
  ],
})
export class TrainingPlanModule { }
