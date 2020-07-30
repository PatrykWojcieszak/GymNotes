import { FormGroup, FormBuilder, Validators, FormArray, FormControl } from '@angular/forms';
import { AuthenticationService } from './../../../Auth/Authentication.service';
import { Injectable } from '@angular/core';

import { TrainingPlanService } from './../Http/TrainingPlan/TrainingPlan.service';
import { PaginatedList } from 'src/app/Shared/Models/PaginatedList';
import { TrainingPlan } from 'src/app/Shared/Models/Training/TrainingPlan';
import { IQueryAPI } from 'src/Common';

@Injectable({
  providedIn: 'root'
})
export class TrainingPlanStorageService {

  public trainingPlan: PaginatedList<TrainingPlan> = {
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

  public isLoading = false;
	public error: Error = null;
	private isLoaded = false;
  private isFoundAny = false;

	public queryAPI: IQueryAPI = {
		page: '1',
		filterby: [1, 1],
		pagesize: '8',
    search: '',
  };

  constructor(
    private authentication: AuthenticationService,
    private trainingPlanService: TrainingPlanService) { }

    public onStart(): void{
      this.getTrainingPlanList(this.queryAPI);
    }

    public getTrainingPlanList(query?: IQueryAPI){
      this.setLoading();

      const parameters: string[] = [ this.authentication.UserId ];

      this.trainingPlanService.GetAll(query, parameters).subscribe(
        (res: PaginatedList<TrainingPlan>) => {
          this.trainingPlan = res;
          console.warn(res);
          this.setSuccess();
        },
        (error: Error) => {
          this.setError(error);
          console.error(error.message);
        }
      )
    }

    public search = () => {
      this.getTrainingPlanList(this.queryAPI);
    };

    public get showNoResults(): boolean {
      return this.isLoaded && !this.isFoundAny;
    }

    public updateSearch(searchText: string) {
     this.queryAPI = { ...this.queryAPI, search: searchText };
     this.search();
    }

    public filterOptionDropdown(type: number){
      const tempVal = this.queryAPI.filterby[1];
      this.queryAPI = {...this.queryAPI, filterby: [type, tempVal]};
      this.search();
    }

    public nextPage(): void {
      this.queryAPI = { ...this.queryAPI, page: (this.trainingPlan.pageIndex + 1).toString() };
      this.search();
    }

    public prevPage(): void {
      this.queryAPI = { ...this.queryAPI, page: (this.trainingPlan.pageIndex - 1).toString() };
      this.search();
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
      this.isFoundAny = this.trainingPlan.items.length !== 0;
    }

    private setError(error: Error) {
      this.error = error;
      this.isLoading = false;
    }
}
