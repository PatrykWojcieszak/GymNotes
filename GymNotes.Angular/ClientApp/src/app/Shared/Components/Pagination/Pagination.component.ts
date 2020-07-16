import { Component, OnInit, Output, EventEmitter } from '@angular/core';

import { UserListStorageService } from 'src/app/Core/Services/Storage/UserList-Storage.service';
import { PaginatedList } from '../../Models/PaginatedList';

@Component({
  selector: 'app-Pagination',
  templateUrl: './Pagination.component.html',
  styleUrls: ['./Pagination.component.scss']
})
export class PaginationComponent implements OnInit {

  public dataList: PaginatedList<any> = {
		hasNextPage: false,
		hasPreviousPage: false,
		items: [],
		pageIndex: 1,
		totalPages: 0
  };

  @Output() nextPageEvent: EventEmitter<boolean> = new EventEmitter<boolean>();
  @Output() prevPageEvent: EventEmitter<boolean> = new EventEmitter<boolean>();

  constructor() { }

  ngOnInit() {
  }

  public nextPage(): void {
		if (this.dataList.totalPages <= this.dataList.pageIndex) {
			return;
    }

    this.nextPageEvent.emit(true);

		// this.queryAPI = { ...this.queryAPI, page: (this.userListStorage.userList.pageIndex + 1).toString() };
		// this.search();
	}

	public prevPage(): void {
		if (this.dataList.pageIndex <= 1) {
			return;
    }

    this.prevPageEvent.emit(true);

		// this.queryAPI = { ...this.queryAPI, page: (this.userListStorage.userList.pageIndex - 1).toString() };
		// this.search();
	}
}
