import { UserListStorageService } from './../../../Core/Services/Storage/UserList-Storage.service';
import { Router, ActivatedRoute } from '@angular/router';
import { Component, OnInit, SimpleChanges, OnChanges } from '@angular/core';

import { AuthenticationService } from '../../../Auth/Authentication.service';
import { UserService } from 'src/app/Core/Services/Http/User/User.service';
import { User } from '../../../Shared/Models/User';
import { PaginatedList } from '../../../Shared/Models/PaginatedList';
import { HttpParams } from '@angular/common/http';
import { IQueryAPI } from '../../../../Common';
import { ChatService } from 'src/app/Core/Services/Http/Chat/Chat.service';
import { relative } from 'path';

@Component({
	selector: 'app-UserList',
	templateUrl: './UserList.component.html',
	styleUrls: [ './UserList.component.scss' ]
})
export class UserListComponent implements OnInit {
	firstFilterDropdownList = [ 'Coaches', 'Everyone' ];

	secondFilterDropdownList = [ 'Featured', 'Newest', 'Highest rating' ];

	// public userList: PaginatedList<User> = {
	// 	hasNextPage: false,
	// 	hasPreviousPage: false,
	// 	items: [],
	// 	pageIndex: 1,
	// 	totalPages: 0
  // };

	// public isLoading: boolean = false;
	// public error: Error = null;
	private isLoaded: boolean = false;
	private isFoundAny: boolean = false;

	public searchText: string = '';
	public queryAPI: IQueryAPI = {
		page: '1',
		orderby: 'lastname',
		pagesize: '5',
		search: ''
	};

	constructor(
		private userService: UserService,
		private router: Router,
    private route: ActivatedRoute,
    public userListStorage: UserListStorageService
	) {}

	ngOnInit() {
    this.userListStorage.getUsers();

		//this.getUserList(this.queryAPI);
	}

	public search = () => {
		//this.getUserList(this.queryAPI);
	};

	public updateSearch = () => {
		const validatedText = this.searchText.trim();
		this.queryAPI = { ...this.queryAPI, search: validatedText };
	};

	public clearSearch() {
		this.searchText = '';
		this.queryAPI = { ...this.queryAPI, search: '' };
	}

	public nextPage(): void {
		if (this.userListStorage.userList.totalPages <= this.userListStorage.userList.pageIndex) {
			return;
		}
		this.queryAPI = { ...this.queryAPI, page: (this.userListStorage.userList.pageIndex + 1).toString() };
		this.search();
	}

	public prevPage(): void {
		if (this.userListStorage.userList.pageIndex <= 1) {
			return;
		}
		this.queryAPI = { ...this.queryAPI, page: (this.userListStorage.userList.pageIndex - 1).toString() };
		this.search();
	}

	// public get showList(): boolean {
	// 	return this.isLoaded && this.isFoundAny;
	// }

	// public get showNoResults(): boolean {
	// 	return this.isLoaded && !this.isFoundAny;
	// }

	// private getUserList(query?: IQueryAPI) {
	// 	this.setLoading();
	// 	this.userService.GetUsers(new HttpParams({ fromObject: query })).subscribe(
	// 		(users: PaginatedList<User>) => {
	// 			this.userList = users;
	// 			console.warn(users);
	// 			this.setSuccess();
	// 			console.dir(this.userList); // TODO delete it
	// 		},
	// 		(error: Error) => {
	// 			this.setError(error);
	// 			console.error(error.message);
	// 		}
	// 	);
	// }

	// private setLoading() {
	// 	this.isLoading = true;
	// 	this.isLoaded = false;
	// 	this.error = null;
	// 	this.isFoundAny = false;
	// }

	// private setSuccess() {
	// 	this.isLoaded = true;
	// 	this.isLoading = false;
	// 	this.isFoundAny = this.userList.items.length !== 0;
	// }

	// private setError(error: Error) {
	// 	this.error = error;
	// 	this.isLoading = false;
	// }

	// public getAge(dateString: string): number {
	// 	if (!dateString) {
	// 		return null;
	// 	}
	// 	const today = new Date();
	// 	const birthDate = new Date(dateString);
	// 	let age = today.getFullYear() - birthDate.getFullYear();
	// 	const m = today.getMonth() - birthDate.getMonth();
	// 	if (m < 0 || (m === 0 && today.getDate() < birthDate.getDate())) {
	// 		age--;
	// 	}
	// 	return age;
	// }

	// public printProp(val: any): string {
	// 	if (!val) {
	// 		return '-';
	// 	}
	// 	return '' + val;
	// }

	// sendMessage(val: string) {
	// 	this.router.navigate([ 'main/chat/', val ]);
	// }

  // onUserSelected(id){
  //   this.router.navigate(['userprofile/', id], {relativeTo: this.route});
  // }
}
