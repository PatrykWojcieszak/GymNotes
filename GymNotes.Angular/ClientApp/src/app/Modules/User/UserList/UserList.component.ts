import { Component, OnInit, SimpleChanges, OnChanges } from '@angular/core';

import { UserListStorageService } from './../../../Core/Services/Storage/UserList-Storage.service';
import { IQueryAPI } from '../../../../Common';

@Component({
	selector: 'app-UserList',
	templateUrl: './UserList.component.html',
	styleUrls: [ './UserList.component.scss' ]
})
export class UserListComponent implements OnInit {
	firstFilterDropdownList = [ 'Coaches', 'Everyone' ];

	secondFilterDropdownList = [ 'Featured', 'Newest', 'Highest rating' ];

	private isLoaded: boolean = false;
	private isFoundAny: boolean = false;

	public searchText: string = '';
	public queryAPI: IQueryAPI = {
		page: '1',
		orderby: 'lastname',
		pagesize: '8',
    search: '',
	};

	constructor(public userListStorage: UserListStorageService) {}

	ngOnInit() {
		this.userListStorage.getUserList(this.queryAPI);
	}

	public search = () => {
		this.userListStorage.getUserList(this.queryAPI);
	};

	public updateSearch(searchText: string) {
		this.queryAPI = { ...this.queryAPI, search: searchText };
		this.search();
	}

	public nextPage(): void {
		this.queryAPI = { ...this.queryAPI, page: (this.userListStorage.userList.pageIndex + 1).toString() };
		this.search();
	}

	public prevPage(): void {
		this.queryAPI = { ...this.queryAPI, page: (this.userListStorage.userList.pageIndex - 1).toString() };
		this.search();
  }

  public userTypeDropdown(type: string){
    console.warn(this.queryAPI);
    this.queryAPI = {...this.queryAPI, key: type};
    console.warn(this.queryAPI);
  }

  public filterByDropdown(type: string){
    console.warn(this.queryAPI);
    this.queryAPI = {...this.queryAPI, key: type};
    console.warn(this.queryAPI);
  }
}
