import { UtilityService } from './../../../Core/Services/Utility/Utility.service';
import { Component, OnInit, SimpleChanges, OnChanges } from '@angular/core';

import { UserListStorageService } from './../../../Core/Services/Storage/UserList-Storage.service';
import { IQueryAPI } from '../../../../Common';

@Component({
	selector: 'app-UserList',
	templateUrl: './UserList.component.html',
	styleUrls: [ './UserList.component.scss' ]
})
export class UserListComponent implements OnInit {
  firstFilterDropdownList = {
    1: 'Coaches',
    2: 'Everyone'
  };

	secondFilterDropdownList = {
    1: 'Featured',
    2: 'Newest',
    3: 'Highest Rating',
  };

	public queryAPI: IQueryAPI = {
		page: '1',
		filterby: [1, 1],
		pagesize: '8',
    search: '',
	};

	constructor(public userListStorage: UserListStorageService, public utilityService: UtilityService) {}

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
		this.queryAPI = { ...this.queryAPI, page: (this.userListStorage.UserList.pageIndex + 1).toString() };
		this.search();
	}

	public prevPage(): void {
		this.queryAPI = { ...this.queryAPI, page: (this.userListStorage.UserList.pageIndex - 1).toString() };
		this.search();
  }

  public userTypeDropdown(type: number){
    const tempVal = this.queryAPI.filterby[1];
    this.queryAPI = {...this.queryAPI, filterby: [type, tempVal]};
    this.search();
  }

  public filterByDropdown(type: number){
    const tempVal = this.queryAPI.filterby[0];
    this.queryAPI = {...this.queryAPI, filterby: [tempVal, type]};
    this.search();
  }
}
