import { Observable } from 'rxjs';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable, DebugElement } from '@angular/core';
import { AriaDescriber } from '@angular/cdk/a11y';

@Injectable({
	providedIn: 'root'
})
export class APIService {
	constructor(private http: HttpClient) {}

	public Post(data, address) {
		return this.http.post(address, data);
	}

	public Update(data, address) {
		return this.http.post(address, data);
	}

	public Delete(address) {
		return this.http.delete(address);
	}

	public Get(address, query?: HttpParams) {
		return this.http.get(address, { params: query || null });
	}

	public BuildAddress(Controller: string, Method: string, Parameters: string[]) {
		// let address: string = 'https://localhost:44346/api/';
		let address: string = 'https://localhost:5001/api/';
		address += Controller + Method;

		if (Parameters != null) {
			for (let item of Parameters) {
				address += '/' + item;
			}
		}

		address += '/';

		return address;
	}
}
