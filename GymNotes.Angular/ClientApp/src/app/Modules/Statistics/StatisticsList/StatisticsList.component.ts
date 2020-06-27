import { Component, OnInit } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { AddDisciplineComponent } from '../AddDiscipline/AddDiscipline.component';

@Component({
  selector: 'app-StatisticsList',
  templateUrl: './StatisticsList.component.html',
  styleUrls: ['./StatisticsList.component.scss']
})

export class StatisticsListComponent implements OnInit {
  disiciplineArray: Array<Disicipline> = [];

  constructor(
    private matDialog: MatDialog
  ) {

    this.loadData();
  }

  ngOnInit() {}

  loadData() {
    var tmpDisicipline;

    tmpDisicipline = new Disicipline('Trójbój siłowy');
    tmpDisicipline.addExercise(new Exercise('Przysiad ze sztangą', '70kg'));
    tmpDisicipline.addExercise(new Exercise('Wyciskanie leżąc', '100kg'));
    tmpDisicipline.addExercise(new Exercise('Martwy ciąg', '50kg'));
    this.disiciplineArray.push(tmpDisicipline);

    tmpDisicipline = new Disicipline('Pływalnia');
    tmpDisicipline.addExercise(new Exercise('Kraul', '2km'));
    tmpDisicipline.addExercise(new Exercise('Żapka', '5km'));
    this.disiciplineArray.push(tmpDisicipline);
  }

  popupDialog() {
    const dialogConfig = new MatDialogConfig();
				this.matDialog.open(AddDisciplineComponent, dialogConfig);
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

class Disicipline {
  name: string;
  private exerciseArray: Array<Exercise> = [];
  newAttribute: any = {};

  constructor(name: string ) {
    this.name = name;
  }

  addExercise(exercise: Exercise) {
    this.exerciseArray.push(exercise);
  }

  deleteFieldValue(index) {
    this.exerciseArray.splice(index, 1);
  }

  addFieldValue() {
    this.exerciseArray.push(new Exercise(this.newAttribute.name , this.newAttribute.value));
    this.newAttribute = {};
  }
}
