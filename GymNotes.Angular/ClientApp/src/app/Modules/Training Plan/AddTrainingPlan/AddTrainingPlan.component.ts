import { TrainingPlanStorageService } from './../../../Core/Services/Storage/TrainingPlan-storage.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-AddTrainingPlan',
  templateUrl: './AddTrainingPlan.component.html',
  styleUrls: ['./AddTrainingPlan.component.scss']
})
export class AddTrainingPlanComponent implements OnInit {

  constructor(
    public trainingPlanStorage: TrainingPlanStorageService) { }

  ngOnInit() {
    this.trainingPlanStorage.createForm();
  }
}
