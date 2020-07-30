import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { TrainingListComponent } from '../Training Plan/TrainingList/TrainingList.component';
import { AddTrainingPlanComponent } from '../Training Plan/AddTrainingPlan/AddTrainingPlan.component';

import { AuthGuard } from 'src/app/Auth/auth.guard';

const routes: Routes = [
  {
    path: '',
    component: TrainingListComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'add-training-plan',
    component: AddTrainingPlanComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'add-training-plan/:id',
    component: AddTrainingPlanComponent,
    canActivate: [AuthGuard]
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class TrainingPlanRoutingModule { }
