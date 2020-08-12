import { UtilityService } from './../../../Core/Services/Utility/Utility.service';
import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

@Component({
	selector: 'app-Dropdown',
	templateUrl: './Dropdown.component.html',
	styleUrls: [ './Dropdown.component.scss' ]
})
export class DropdownComponent implements OnInit {

	@Input() defaultValue: string;
	@Input() listElements: [];
	@Input() selectedElement: string;

	@Output() selectedItem = new EventEmitter<number>();
	constructor(private utilityService: UtilityService) {}

	ngOnInit() {
	}

	itemSelected(name) {
		this.selectedElement = name;
		this.selectedItem.emit(+this.utilityService.getKeyByValue(this.listElements, name));
  	}

	getValues(){
		return Object.values(this.listElements);
	}
}
