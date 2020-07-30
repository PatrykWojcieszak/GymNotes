import { Component, OnInit } from '@angular/core';

import { UtilityService } from './../../../Core/Services/Utility/Utility.service';
import { TrainingPlanStorageService } from './../../../Core/Services/Storage/TrainingPlan-storage.service';
import { UserStorageService } from 'src/app/Core/Services/Storage/User-Storage.service';

@Component({
  selector: 'app-TrainingList',
  templateUrl: './TrainingList.component.html',
  styleUrls: ['./TrainingList.component.scss']
})
export class TrainingListComponent implements OnInit {

  constructor(
    public trainingPlanStorage: TrainingPlanStorageService,
    public utilityService: UtilityService) { }

  ngOnInit() {
    this.trainingPlanStorage.onStart();
  }
}
