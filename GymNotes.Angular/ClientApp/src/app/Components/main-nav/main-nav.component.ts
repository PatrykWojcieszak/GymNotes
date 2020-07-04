import { Component, OnInit } from '@angular/core';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { Observable } from 'rxjs';
import { map, shareReplay } from 'rxjs/operators';

import { AuthenticationService } from 'src/app/Auth/Authentication.service';
import { UserStorageService } from 'src/app/Core/Services/Storage/User-Storage.service';
import { UserLoginInfo } from '../../Shared/Models/UserLoginInfo';

@Component({
	selector: 'app-main-nav',
	templateUrl: './main-nav.component.html',
	styleUrls: [ './main-nav.component.scss' ]
})
export class MainNavComponent implements OnInit {
	isHandset$: Observable<boolean> = this.breakpointObserver
		.observe(Breakpoints.Handset)
		.pipe(map((result) => result.matches), shareReplay());

	constructor(
		private breakpointObserver: BreakpointObserver,
		private Authentication: AuthenticationService,
		private userStorage: UserStorageService
	) {}

	ngOnInit() {
		this.userStorage.getUserData();
	}

	logout() {
		this.Authentication.logout();
	}
}
