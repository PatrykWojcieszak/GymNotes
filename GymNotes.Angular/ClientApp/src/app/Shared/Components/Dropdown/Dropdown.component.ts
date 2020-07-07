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

	@Output() selectedItem = new EventEmitter<string>();
	constructor() {}

	ngOnInit() {}

	itemSelected(name) {
		this.selectedItem.emit(name);
	}
}
