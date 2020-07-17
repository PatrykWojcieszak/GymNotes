import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';

import { PaginatedList } from '../../Models/PaginatedList';

@Component({
  selector: 'app-Pagination',
  templateUrl: './Pagination.component.html',
  styleUrls: ['./Pagination.component.scss']
})
export class PaginationComponent implements OnInit {

  @Input() paginatedList: PaginatedList<any> = {
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
		if (this.paginatedList.totalPages <= this.paginatedList.pageIndex) {
			return;
    }

    this.nextPageEvent.emit(true);
	}

	public prevPage(): void {
		if (this.paginatedList.pageIndex <= 1) {
			return;
    }

    this.prevPageEvent.emit(true);
	}
}
