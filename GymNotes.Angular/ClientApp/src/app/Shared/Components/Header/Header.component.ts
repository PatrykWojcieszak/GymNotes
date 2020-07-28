import { UserListStorageService } from './../../../Core/Services/Storage/UserList-Storage.service';
import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { IQueryAPI } from 'src/Common';

@Component({
	selector: 'app-Header',
	templateUrl: './Header.component.html',
	styleUrls: [ './Header.component.scss' ]
})
export class HeaderComponent implements OnInit {
	public searchText = '';

	@Input() isSearchBox: boolean;
	@Input() showSecondFilter = true;
	@Output() searchBox: EventEmitter<string> = new EventEmitter<string>();

	constructor(private userListStorage: UserListStorageService) {}

	ngOnInit() {}

	public updateSearch = () => {
		const validatedText = this.searchText.trim();
		this.searchBox.emit(validatedText);
	};
}
