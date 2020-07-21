import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class UtilityService {

constructor() { }

  public printProp(val: any): string {
    if (!val) {
      return '-';
    }
    return '' + val;
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

  public getKeyByValue(object, value) {
    return Object.keys(object).find(key => object[key] === value);
  }
}
