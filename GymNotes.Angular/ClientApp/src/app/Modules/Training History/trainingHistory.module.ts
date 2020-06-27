import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { AddTrainingToCalendarComponent } from './AddTrainingToCalendar/AddTrainingToCalendar.component';
import { Calendar } from './Calendar/Calendar.component';

import { TrainingHistoryRoutingModule } from './trainingHistory-routing.module';


@NgModule({
  declarations: [
    Calendar,
  ],
  imports: [
    CommonModule,
    RouterModule,
    TrainingHistoryRoutingModule,
  ],
  entryComponents: [
    AddTrainingToCalendarComponent
  ]
})
export class TrainingHistoryModule { }
