import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-AddTrainingWeek',
  templateUrl: './AddTrainingWeek.component.html',
  styleUrls: ['./AddTrainingWeek.component.scss']
})
export class AddTrainingWeekComponent implements OnInit {

  @Input() Name: string;

  constructor() { }

  ngOnInit() {
  }

}
