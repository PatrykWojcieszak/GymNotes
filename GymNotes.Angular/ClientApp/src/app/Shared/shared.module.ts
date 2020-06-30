import { FormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { ConfirmationDialogComponent } from './Components/ConfirmationDialog/ConfirmationDialog.component';
import { DropdownDirective } from './Directives/dropdown.directive';

@NgModule({
  declarations: [
    ConfirmationDialogComponent,
    DropdownDirective,
  ],
  imports: [
    CommonModule,
    RouterModule,
    FormsModule,
  ],
  exports: [
    ConfirmationDialogComponent,
    DropdownDirective,
  ],
  entryComponents: [
    ConfirmationDialogComponent,
  ]
})
export class SharedModule { }
