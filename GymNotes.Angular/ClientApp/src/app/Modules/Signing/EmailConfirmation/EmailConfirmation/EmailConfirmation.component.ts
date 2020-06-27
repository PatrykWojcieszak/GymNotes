import { UserService } from './../../../../Services/User/User.service';
import { Router, ActivatedRoute } from '@angular/router';
import { Component, OnInit } from '@angular/core';

@Component({
	selector: 'app-EmailConfirmation',
	templateUrl: './EmailConfirmation.component.html',
	styleUrls: [ './EmailConfirmation.component.scss' ]
})
export class EmailConfirmationComponent implements OnInit {
	constructor(private routerLink: Router, private Activatedroute: ActivatedRoute, private userService: UserService) {}

	// tslint:disable-next-line: indent
	params: any;

	ngOnInit() {
		this.Activatedroute.queryParamMap.subscribe((params) => {
			this.params = params;
		});

		var registerModel = {
			Email: this.params.get('email'),
			Token: this.params.get('token'),
		};

		this.userService.ConfirmEmail(registerModel).subscribe((res: any) => {
			console.warn(res)},
			(err) => {
				console.warn(err)
			});
	}

	signIn() {
		this.routerLink.navigateByUrl('/user/login');
	}
}
