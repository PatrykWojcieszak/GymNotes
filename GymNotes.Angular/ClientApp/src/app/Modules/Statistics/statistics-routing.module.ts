import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { StatisticsListComponent } from './StatisticsList/StatisticsList.component';
import { AddDisciplineComponent } from './AddDiscipline/AddDiscipline.component';

import { AuthGuard } from 'src/app/Auth/auth.guard';

const routes: Routes = [
  {
    path: '',
    component: StatisticsListComponent,
    canActivate: [ AuthGuard ],
    children: [
      {
        path: 'add-discipline',
        component: AddDisciplineComponent
      },
    ]
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class StatisticsRoutingModule { }
