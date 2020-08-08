import { SpinnerOverlayService } from './../Core/Services/Utility/SpinnerOverlay.service';
import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent } from '@angular/common/http';
import { Router } from '@angular/router';
import { Observable, Subscription } from 'rxjs';
import { tap, finalize } from 'rxjs/operators';
import { AuthenticationService } from './Authentication.service';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {
	constructor(
    private router: Router,
    private authentication: AuthenticationService,
    private spinnerOverlay: SpinnerOverlayService
    ) {}

	intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    this.spinnerOverlay.show();
		if (this.authentication.UserToken != null) {
			const clonedReq = req.clone({
				headers: req.headers.set('Authorization', 'Bearer ' + this.authentication.UserToken)
      });


			return next.handle(clonedReq).pipe(
				tap(
					(succ) => {
            this.spinnerOverlay.hide();
          },
					(err) => {
						if (err.status === 401) {
              this.spinnerOverlay.hide();
							localStorage.removeItem('token');
							this.router.navigateByUrl('/user/login');
						}
					}
				)
			);
		} else return next.handle(req.clone()).pipe(
      finalize(() => {
        this.spinnerOverlay.hide();
      })
    );
	}
}
