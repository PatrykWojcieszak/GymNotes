import { FormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { StatisticsListComponent } from './StatisticsList/StatisticsList.component';
import { EditDisciplineComponent } from './EditDiscipline/EditDiscipline.component';
import { AddWeightComponent } from './AddWeight/AddWeight.component';
import { AddDisciplineComponent } from './AddDiscipline/AddDiscipline.component';

import { StatisticsRoutingModule } from './statistics-routing.module';

@NgModule({
  declarations: [
    AddDisciplineComponent,
    AddWeightComponent,
    EditDisciplineComponent,
    StatisticsListComponent,
  ],
  imports: [
    CommonModule,
    RouterModule,
    FormsModule,
    StatisticsRoutingModule
  ],
})
export class StatisticsModule { }
