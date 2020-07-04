import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';

@Injectable({
	providedIn: 'root'
})
export class ServerErrorInterceptorService implements HttpInterceptor {
	intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
		return next.handle(request).pipe(
			retry(1),
			catchError((error: HttpErrorResponse) => {
				if (error.status === 401) {
					// refresh token
				} else {
					return throwError(error);
				}
			})
		);
	}
}
