import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-PasswordReseted',
  templateUrl: './PasswordReseted.component.html',
  styleUrls: ['./PasswordReseted.component.scss']
})
export class PasswordResetedComponent implements OnInit {

  constructor(private dialogRef: MatDialogRef<PasswordResetedComponent>, @Inject(MAT_DIALOG_DATA) data){ }

  ngOnInit() {
  }

  close() {
    this.dialogRef.close();
  }
}
