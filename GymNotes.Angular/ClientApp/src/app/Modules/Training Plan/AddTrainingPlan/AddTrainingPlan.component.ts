import { TrainingPlanStorageService } from './../../../Core/Services/Storage/TrainingPlan-storage.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-AddTrainingPlan',
  templateUrl: './AddTrainingPlan.component.html',
  styleUrls: ['./AddTrainingPlan.component.scss']
})
export class AddTrainingPlanComponent implements OnInit {

  TrainingPlanForm: FormGroup;
  ValidForNextStep = false;
  SubmittedNextStep = false;

  constructor(private fb: FormBuilder, public trainingPlanStorage: TrainingPlanStorageService) { }

  ngOnInit() {
    this.TrainingPlanForm = this.fb.group({
      Name: ['', Validators.required],
      Description: ['', Validators.required]
    });
  }

  get form(){
    return this.TrainingPlanForm.controls;
  }

  onNextStep(){
    this.SubmittedNextStep = true;

    if(this.TrainingPlanForm.invalid){
      return;
    }

    this.ValidForNextStep = true;
  }
}
