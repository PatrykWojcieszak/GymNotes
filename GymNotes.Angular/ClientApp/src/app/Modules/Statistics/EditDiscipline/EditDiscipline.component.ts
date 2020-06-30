import { Component, OnInit, Inject, ɵCompiler_compileModuleSync__POST_R3__ } from "@angular/core";
import { MatDialogRef, MAT_DIALOG_DATA } from "@angular/material/dialog";
import { StatisticsExercise } from 'src/app/Shared/Models/StatisticsExcercise';

@Component({
  selector: "app-EditDiscipline",
  templateUrl: "./EditDiscipline.component.html",
  styleUrls: ["./EditDiscipline.component.scss"],
})
export class EditDisciplineComponent implements OnInit {
  newAttribute: any = {};
  disciplineArray: any = {};
  discipline: any;

  constructor(
    private dialogRef: MatDialogRef<EditDisciplineComponent>,
    @Inject(MAT_DIALOG_DATA) public Data: any
  ) {
    this.discipline = Data.discipline;
    this.disciplineArray = Data.disciplineArray;
  }

  ngOnInit() {}

  close() {
    this.dialogRef.close();
  }

  addFieldValue() {
    this.discipline.exerciseArray.push(
      new StatisticsExercise(this.newAttribute.name, this.newAttribute.value)
    );
    this.newAttribute = {};
  }

  deleteFieldValue(index) {
    this.discipline.exerciseArray.splice(index, 1);
  }

  saveData() {
    this.close();
  }

  deleteDiscipline() {
    let index = this.disciplineArray.indexOf(this.discipline);
    this.disciplineArray.splice(index, 1);
    this.close();
  }
}
