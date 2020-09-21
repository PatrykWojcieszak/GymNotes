import { BehaviorSubject, Observable } from "rxjs";
import { Injectable } from "@angular/core";
import { PaginatedList } from "src/app/Shared/Models/PaginatedList";
import { User } from "src/app/Shared/Models/User";
import { IQueryAPI } from "src/Common";
import { UserService } from "../Http/User/User.service";
import { HttpParams } from "@angular/common/http";

@Injectable({
  providedIn: "root",
})
export class UserListStorageService {
  private _userList: BehaviorSubject<PaginatedList<User>> = new BehaviorSubject<
    PaginatedList<User>
  >(new PaginatedList());

  public readonly userList = this._userList.asObservable;

  get UserList() {
    return this._userList.value;
  }

  set UserList(value) {
    this._userList.next(value);
  }

  public isLoading = false;
  public error: Error = null;
  private isLoaded = false;
  private isFoundAny = false;

  public searchText = "";
  public queryAPI: IQueryAPI = {
    page: "1",
    filterby: [1, 1],
    pagesize: "5",
    search: "",
  };

  constructor(private userService: UserService) {}

  public getUsers() {
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
    this.isFoundAny = this.UserList.items.length !== 0;
  }

  private setError(error: Error) {
    this.error = error;
    this.isLoading = false;
  }

  public getUserList(query?: IQueryAPI) {
    this.setLoading();
    this.userService.GetUsers(query).subscribe(
      (users: PaginatedList<User>) => {
        this.UserList = users;
        this.setSuccess();
      },
      (error: Error) => {
        this.setError(error);
        console.error(error.message);
      }
    );
  }

  public get showList(): boolean {
    return this.isLoaded && this.isFoundAny;
  }

  public get showNoResults(): boolean {
    return this.isLoaded && !this.isFoundAny;
  }
}
