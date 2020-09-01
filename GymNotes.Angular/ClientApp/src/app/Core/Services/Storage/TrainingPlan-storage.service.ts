import { AuthenticationService } from "./../../../Auth/Authentication.service";
import { Injectable } from "@angular/core";
import { BehaviorSubject } from "rxjs";

import { TrainingPlanService } from "./../Http/TrainingPlan/TrainingPlan.service";
import { PaginatedList } from "src/app/Shared/Models/PaginatedList";
import { TrainingPlan } from "src/app/Shared/Models/Training/TrainingPlan";
import { IQueryAPI } from "src/Common";

@Injectable({
  providedIn: "root",
})
export class TrainingPlanStorageService {
  private _trainingPlan: BehaviorSubject<
    PaginatedList<TrainingPlan>
  > = new BehaviorSubject<PaginatedList<TrainingPlan>>(new PaginatedList());

  public readonly trainingPlan = this._trainingPlan.asObservable;

  get TrainingPlan() {
    return this._trainingPlan.value;
  }

  set TrainingPlan(value) {
    this._trainingPlan.next(value);
  }

  filterOption = {
    1: "All",
    2: "Favorites",
    3: "Newest",
  };

  public isLoading = false;
  public error: Error = null;
  private isLoaded = false;
  private isFoundAny = false;

  public queryAPI: IQueryAPI = {
    page: "1",
    filterby: [1, 1],
    pagesize: "8",
    search: "",
  };

  constructor(
    private authentication: AuthenticationService,
    private trainingPlanService: TrainingPlanService
  ) {}

  public onStart(): void {
    this.getTrainingPlanList(this.queryAPI);
  }

  public getTrainingPlanList(query?: IQueryAPI) {
    this.setLoading();

    const parameters: string[] = [this.authentication.UserId];

    this.trainingPlanService.GetAll(query, parameters).subscribe(
      (res: PaginatedList<TrainingPlan>) => {
        this.TrainingPlan = res;
        this.setSuccess();
      },
      (error: Error) => {
        this.setError(error);
        console.error(error.message);
      }
    );
  }

  public onRemoveTrainingPlan(parameters) {
    this.trainingPlanService.Delete(parameters).subscribe((res) => {
      console.warn(res);
      const tempTrainings = this.TrainingPlan.items.filter(
        (x) => x.id !== parameters[1]
      );

      this.TrainingPlan = { ...this.TrainingPlan, items: tempTrainings };
    });
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

  public filterOptionDropdown(type: number) {
    const tempVal = this.queryAPI.filterby[1];
    this.queryAPI = { ...this.queryAPI, filterby: [type, tempVal] };
    this.search();
  }

  public nextPage(): void {
    this.queryAPI = {
      ...this.queryAPI,
      page: (this.TrainingPlan.pageIndex + 1).toString(),
    };
    this.search();
  }

  public prevPage(): void {
    this.queryAPI = {
      ...this.queryAPI,
      page: (this.TrainingPlan.pageIndex - 1).toString(),
    };
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
    this.isFoundAny = this.TrainingPlan.items.length !== 0;
  }

  private setError(error: Error) {
    this.error = error;
    this.isLoading = false;
  }
}
