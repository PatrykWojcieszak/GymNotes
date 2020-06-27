import { AuthenticationService } from './../../../Services/Authentication/Authentication.service';
import { ChatService } from './../../../Services/Chat/Chat.service';
import { Router } from '@angular/router';
import { Component, OnInit, SimpleChanges, OnChanges } from '@angular/core';
import { UserService } from './../../../Services/User/User.service';
import { User } from '../../../Models/User';
import { PaginatedList } from '../../../Models/PaginatedList';
import { HttpParams } from '@angular/common/http';
import { IQueryAPI } from '../../../../Common';

@Component({
  selector: 'app-UserList',
  templateUrl: './UserList.component.html',
  styleUrls: ['./UserList.component.scss']
})

export class UserListComponent implements OnInit {

  public userList: PaginatedList<User> = {
    hasNextPage: false,
    hasPreviousPage: false,
    items: [],
    pageIndex: 1,
    totalPages: 0,
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
    search: '',
  };

  constructor(
    private userService: UserService,
    private router: Router,
    private chatService: ChatService,
    private authentication: AuthenticationService
  ) { }

  ngOnInit() {
    this.comboBoxScript();
    this.getUserList(this.queryAPI);
  }

  // ngOnChanges(changes: SimpleChanges) {
  //   // reset page if items array has changed
  //   if (changes.queryAPI.previousValue !== changes.queryAPI.currentValue) {
  //     this.search();
  //   }
  // }

  public search = () => {
    this.getUserList(this.queryAPI);
  }

  public updateSearch = () => {
    const validatedText = this.searchText.trim();
    this.queryAPI = { ...this.queryAPI, search: validatedText };
  }

  public clearSearch() {
    this.searchText = '';
    this.queryAPI = { ...this.queryAPI, search: '' };
  }

  public nextPage(): void {
    if (this.userList.totalPages <= this.userList.pageIndex) {
      return;
    }
    this.queryAPI = { ...this.queryAPI, page: (this.userList.pageIndex + 1).toString()};
    this.search();
  }

  public prevPage(): void {
    if (this.userList.pageIndex <= 1) {
      return;
    }
    this.queryAPI = { ...this.queryAPI, page: (this.userList.pageIndex - 1).toString()};
    this.search();
  }

  public get showList(): boolean {
    return this.isLoaded && this.isFoundAny;
  }

  public get showNoResults(): boolean {
    return this.isLoaded && !this.isFoundAny;
  }

  private getUserList(query?: IQueryAPI) {
    this.setLoading();
    this.userService.GetUsers(new HttpParams({ fromObject: query })).subscribe((users: PaginatedList<User>) => {
      this.userList = users;
      console.warn(users);
      this.setSuccess();
      console.dir(this.userList); // TODO delete it
    }, (error: Error) => {
      this.setError(error);
      console.error(error.message);
    });
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

  public getAge(dateString: string): number {
    if (!dateString) {
      return null;
    }
    const today = new Date();
    const birthDate = new Date(dateString);
    let age = today.getFullYear() - birthDate.getFullYear();
    const m = today.getMonth() - birthDate.getMonth();
    if (m < 0 || (m === 0 && today.getDate() < birthDate.getDate())) {
      age--;
    }
    return age;
  }

  public printProp(val: any): string {
    if (!val) {
      return '-';
    }
    return '' + val;
  }

  sendMessage(val: string){
    this.router.navigate([ 'main/chat/', val ]);
  }

  comboBoxScript() {
    // $('.pagination-inner a').on('click', function() {
    // $(this).siblings().removeClass('pagination-active');
    // $(this).addClass('pagination-active');
    // });
  }
}
