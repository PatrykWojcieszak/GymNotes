import { AuthenticationService } from 'src/app/Auth/Authentication.service';
import { Component, OnInit } from '@angular/core';

import { UserStorageService } from 'src/app/Core/Services/Storage/User-Storage.service';
import { TrainingPlanService } from './../../../Core/Services/Http/TrainingPlan/TrainingPlan.service';

@Component({
  selector: 'app-TrainingList',
  templateUrl: './TrainingList.component.html',
  styleUrls: ['./TrainingList.component.scss']
})
export class TrainingListComponent implements OnInit {

  constructor(private trainingPlanservice: TrainingPlanService, private authentication: AuthenticationService) { }

  trainingPlan: any;

  ngOnInit() {
    let parameters: string[] = [ this.authentication.UserId ];

    this.trainingPlanservice.GetAll(parameters).subscribe((x) => {
      this.trainingPlan = x;
      console.warn(x);
    });

  }

}
