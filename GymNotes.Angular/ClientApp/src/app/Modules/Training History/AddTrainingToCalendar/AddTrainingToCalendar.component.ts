import { Component, OnInit } from "@angular/core";
import { MatDialogRef } from "@angular/material/dialog";

@Component({
  selector: "app-AddTrainingToCalendar",
  templateUrl: "./AddTrainingToCalendar.component.html",
  styleUrls: ["./AddTrainingToCalendar.component.scss"],
})
export class AddTrainingToCalendarComponent implements OnInit {
  constructor(
    private dialogRef: MatDialogRef<AddTrainingToCalendarComponent>
  ) {}

  ngOnInit() {}

  close() {
    this.dialogRef.close();
  }

}
