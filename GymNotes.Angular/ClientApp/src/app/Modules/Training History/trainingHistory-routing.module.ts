import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { Calendar } from './Calendar/Calendar.component';

import { AuthGuard } from 'src/app/Auth/auth.guard';

const routes: Routes = [
  {
     path: '',
     component: Calendar,
     canActivate: [AuthGuard]
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class TrainingHistoryRoutingModule { }
