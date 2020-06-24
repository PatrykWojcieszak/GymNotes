import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';

import { ToolsMenuComponent } from './ToolsMenu/ToolsMenu.component';
import { BMIComponent } from './BMI/BMI.Component';
import { BodyFatComponent } from './BodyFat/BodyFat.component';
import { CalorieComponent } from './Calorie/Calorie.component';
import { WilksComponent } from './Wilks/Wilks.component';

import { AuthGuard } from 'src/app/Auth/auth.guard';

const routes: Routes = [
  {
    path: '',
    component: ToolsMenuComponent,
    canActivate: [AuthGuard],
    children: [
      {
        path: '', redirectTo: 'bmi', pathMatch: 'full'
      },
      {
        path: 'bmi',
        component: BMIComponent,
      },
      {
        path: 'body-fat',
        component: BodyFatComponent,
      },
      {
        path: 'calorie',
        component: CalorieComponent,
      },
      {
        path: 'wilks',
        component: WilksComponent,
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ToolsRoutingModule { }
