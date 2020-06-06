import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent } from '@angular/common/http';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { tap } from "rxjs/operators";
import { AuthenticationService } from '../Services/Authentication/Authentication.service';


@Injectable()
export class AuthInterceptor implements HttpInterceptor{

    constructor(private router: Router, private authentication: AuthenticationService) {

    }

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        if (this.authentication.UserToken != null) {
            const clonedReq = req.clone({
                headers: req.headers.set('Authorization', 'Bearer ' + this.authentication.UserToken)
            });
            return next.handle(clonedReq).pipe(
                tap(
                    succ => { },
                    err => {
                        if (err.status == 401){
                            localStorage.removeItem('token');
                            this.router.navigateByUrl('/user/login');
                        }
                    }
                )
            )
        }
        else
            return next.handle(req.clone());
    }
}