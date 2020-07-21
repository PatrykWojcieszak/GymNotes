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
    Coaches: 1,
    Everyone: 2
  };
	// firstFilterDropdownList = [ 'Coaches', 'Everyone' ];
	// secondFilterDropdownList = [ 'Featured', 'Newest', 'Highest rating' ];
	secondFilterDropdownList = {
    Featured: 1,
    Newest: 2,
    HighestRating: 3,
  };

	public searchText: string = '';
	public queryAPI: IQueryAPI = {
		page: '1',
		orderby: [1, 1],
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
		this.queryAPI = { ...this.queryAPI, page: (this.userListStorage.userList.pageIndex + 1).toString() };
		this.search();
	}

	public prevPage(): void {
		this.queryAPI = { ...this.queryAPI, page: (this.userListStorage.userList.pageIndex - 1).toString() };
		this.search();
  }

  public userTypeDropdown(type: number){
    const tempVal = this.queryAPI.orderby[1];
    this.queryAPI = {...this.queryAPI, orderby: [type, tempVal]};
    this.search();
  }

  public filterByDropdown(type: number){
    const tempVal = this.queryAPI.orderby[0];
    this.queryAPI = {...this.queryAPI, orderby: [tempVal, type]};
    this.search();
  }
}
