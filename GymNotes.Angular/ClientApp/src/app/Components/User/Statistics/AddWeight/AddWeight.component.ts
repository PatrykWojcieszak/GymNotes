import { Component, OnInit, Inject, NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { MatDialogRef, MAT_DIALOG_DATA } from "@angular/material/dialog";

@Component({
  selector: "app-AddWeight",
  templateUrl: "./AddWeight.component.html",
  styleUrls: ["./AddWeight.component.css"],
})
export class AddWeightComponent implements OnInit {
  yourWeight: string;
  date: Date;

  constructor(
    private dialogRef: MatDialogRef<AddWeightComponent>,
    @Inject(MAT_DIALOG_DATA) public Data: any
  ) {}

  ngOnInit() {}

  onSubmit() {
    this.Data.Data = this.yourWeight;
    this.dialogRef.close(this.yourWeight);
  }

  close() {
    this.dialogRef.close();
  }
}
