import { FormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { AngularMaterialModule } from './../angular-material.module';

import { HeaderComponent } from './Components/Header/Header.component';
import { SpinnerComponent } from './Components/Spinner/Spinner.component';
import { PaginationComponent } from './Components/Pagination/Pagination.component';
import { DropdownComponent } from './Components/Dropdown/Dropdown.component';
import { ConfirmationDialogComponent } from './Components/ConfirmationDialog/ConfirmationDialog.component';
import { DropdownDirective } from './Directives/dropdown.directive';
import { AchievementsListComponent } from './Components/AchievementsList/AchievementsList.component';

@NgModule({
	declarations: [
		ConfirmationDialogComponent,
		DropdownDirective,
		DropdownComponent,
		AchievementsListComponent,
		PaginationComponent,
    HeaderComponent,
    SpinnerComponent,
	],
	imports: [ CommonModule, RouterModule, FormsModule, AngularMaterialModule ],
	exports: [
		ConfirmationDialogComponent,
		DropdownDirective,
		DropdownComponent,
		AchievementsListComponent,
		PaginationComponent,
    HeaderComponent,
    SpinnerComponent
	],
	entryComponents: [ ConfirmationDialogComponent, SpinnerComponent ]
})
export class SharedModule {}
