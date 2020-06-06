import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-AddDiscipline',
  templateUrl: './AddDiscipline.component.html',
  styleUrls: ['./AddDiscipline.component.css']
})

export class AddDisciplineComponent implements OnInit {
  name: string;
  exerciseArray: Array<Exercise> = [];
  newAttribute: any = {};

  constructor() { }

  ngOnInit() {
  }

  addFieldValue() { 
    this.exerciseArray.push(new Exercise(this.newAttribute.name , this.newAttribute.value));
    this.newAttribute = {};
  }

  deleteFieldValue(index) {
    this.exerciseArray.splice(index, 1);
  }

  saveData() {
    
  }

}

class Exercise {
  private name: string;
  private value: string;

  constructor(name: string, value: string) {
    this.name = name;
    this.value = value;
  }
}
