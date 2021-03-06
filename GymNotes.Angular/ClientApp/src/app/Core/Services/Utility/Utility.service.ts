import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class UtilityService {

constructor() { }

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

  public getValueByKey(object, value) {
    return object[value];
  }

  public putToLocalStorage(name: string, object: any){
    localStorage.setItem(name, JSON.stringify(object));
  }

  public putToSessionStorage(name: string, object: any){
    sessionStorage.setItem(name, JSON.stringify(object));
  }
}
