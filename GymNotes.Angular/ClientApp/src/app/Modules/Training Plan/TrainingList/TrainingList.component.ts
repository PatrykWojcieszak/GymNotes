import { UtilityService } from './../../../Core/Services/Utility/Utility.service';
import { AuthenticationService } from 'src/app/Auth/Authentication.service';
import { Component, OnInit } from '@angular/core';

import { UserStorageService } from 'src/app/Core/Services/Storage/User-Storage.service';
import { TrainingPlanService } from './../../../Core/Services/Http/TrainingPlan/TrainingPlan.service';
import { PaginatedList } from 'src/app/Shared/Models/PaginatedList';

@Component({
  selector: 'app-TrainingList',
  templateUrl: './TrainingList.component.html',
  styleUrls: ['./TrainingList.component.scss']
})
export class TrainingListComponent implements OnInit {

  constructor(
    private trainingPlanService: TrainingPlanService,
    private authentication: AuthenticationService,
    public utilityService: UtilityService) { }

  public trainingPlan: PaginatedList<any> = {
		hasNextPage: false,
		hasPreviousPage: false,
		items: [],
		pageIndex: 1,
		totalPages: 0
  };
  filterOption = {
    All: 1,
    Favorites: 2,
    Newest: 3,
  };

  ngOnInit() {
    const parameters: string[] = [ this.authentication.UserId ];

    this.trainingPlanService.GetAll(parameters).subscribe((x) => {
      //this.trainingPlan = x;
      console.warn(x);
    });
  }

  public updateSearch(searchText: string) {
	//  this.queryAPI = { ...this.queryAPI, search: searchText };
	//  this.search();
  }

  public filterOptionDropdown(type: number){
    // const tempVal = this.queryAPI.orderby[1];
    // this.queryAPI = {...this.queryAPI, orderby: [type, tempVal]};
    // this.search();
  }

  public nextPage(): void {
		// this.queryAPI = { ...this.queryAPI, page: (this.userListStorage.userList.pageIndex + 1).toString() };
		// this.search();
	}

	public prevPage(): void {
		// this.queryAPI = { ...this.queryAPI, page: (this.userListStorage.userList.pageIndex - 1).toString() };
		// this.search();
  }
}
