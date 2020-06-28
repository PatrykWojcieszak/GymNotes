import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { CalendarModule, DateAdapter  } from 'angular-calendar';
import { adapterFactory } from 'angular-calendar/date-adapters/date-fns';

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
    CalendarModule.forRoot({
      provide: DateAdapter,
      useFactory: adapterFactory,
    }),
  ],
  entryComponents: [
    AddTrainingToCalendarComponent
  ]
})
export class TrainingHistoryModule { }
