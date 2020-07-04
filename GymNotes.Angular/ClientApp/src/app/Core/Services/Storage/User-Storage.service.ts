import { Injectable } from '@angular/core';

import { UserService } from 'src/app/Core/Services/Http/User/User.service';
import { AuthenticationService } from 'src/app/Auth/Authentication.service';

@Injectable({
	providedIn: 'root'
})
export class UserStorageService {
	constructor(private userService: UserService, private authentication: AuthenticationService) {}

	getUserData() {
		let parameters = [ this.authentication.UserId ];

		this.userService.GetUserUpdateInfo(parameters).subscribe((x) => console.warn(x));
	}
}
