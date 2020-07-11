import { Injectable } from '@angular/core';
import { PaginatedList } from 'src/app/Shared/Models/PaginatedList';
import { User } from 'src/app/Shared/Models/User';
import { IQueryAPI } from 'src/Common';
import { UserService } from '../Http/User/User.service';
import { HttpParams } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class UserListStorageService {

  public userList: PaginatedList<User> = {
		hasNextPage: false,
		hasPreviousPage: false,
		items: [],
		pageIndex: 1,
		totalPages: 0
  };

	public isLoading: boolean = false;
	public error: Error = null;
	private isLoaded: boolean = false;
	private isFoundAny: boolean = false;

	public searchText: string = '';
	public queryAPI: IQueryAPI = {
		page: '1',
		orderby: 'lastname',
		pagesize: '5',
		search: ''
  };

  constructor(private userService: UserService,) { }

  public getUsers(){
    this.getUserList(this.queryAPI);
  }

	private setLoading() {
		this.isLoading = true;
		this.isLoaded = false;
		this.error = null;
		this.isFoundAny = false;
	}

	private setSuccess() {
		this.isLoaded = true;
		this.isLoading = false;
		this.isFoundAny = this.userList.items.length !== 0;
	}

	private setError(error: Error) {
		this.error = error;
		this.isLoading = false;
  }

  private getUserList(query?: IQueryAPI) {
		this.setLoading();
		this.userService.GetUsers(new HttpParams({ fromObject: query })).subscribe(
			(users: PaginatedList<User>) => {
				this.userList = users;
				console.warn(users);
				this.setSuccess();
				console.dir(this.userList); // TODO delete it
			},
			(error: Error) => {
				this.setError(error);
				console.error(error.message);
			}
		);
  }

  public search = () => {
		this.getUserList(this.queryAPI);
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
		if (this.userList.totalPages <= this.userList.pageIndex) {
			return;
		}
		this.queryAPI = { ...this.queryAPI, page: (this.userList.pageIndex + 1).toString() };
		this.search();
	}

	public prevPage(): void {
		if (this.userList.pageIndex <= 1) {
			return;
		}
		this.queryAPI = { ...this.queryAPI, page: (this.userList.pageIndex - 1).toString() };
		this.search();
	}

	public get showList(): boolean {
		return this.isLoaded && this.isFoundAny;
	}

	public get showNoResults(): boolean {
		return this.isLoaded && !this.isFoundAny;
	}
}
