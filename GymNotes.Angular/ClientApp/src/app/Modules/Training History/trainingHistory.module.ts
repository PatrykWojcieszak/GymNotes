import { SharedModule } from './../../Shared/shared.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { CalendarModule, DateAdapter  } from 'angular-calendar';
import { adapterFactory } from 'angular-calendar/date-adapters/date-fns';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AddFinishedWorkoutComponent } from './AddFinishedWorkout/AddFinishedWorkout.component';
import { Calendar } from './Calendar/Calendar.component';

import { TrainingHistoryRoutingModule } from './trainingHistory-routing.module';

@NgModule({
  declarations: [
    Calendar,
    AddFinishedWorkoutComponent
  ],
  imports: [
    CommonModule,
    RouterModule,
    FormsModule,
    ReactiveFormsModule,
    SharedModule,
    TrainingHistoryRoutingModule,
    CalendarModule.forRoot({
      provide: DateAdapter,
      useFactory: adapterFactory,
    }),
  ],
  entryComponents: [
    AddFinishedWorkoutComponent
  ]
})
export class TrainingHistoryModule { }
