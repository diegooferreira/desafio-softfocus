import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError, BehaviorSubject, of } from "rxjs";
import { catchError, finalize, filter, take, switchMap } from "rxjs/operators";
import { SpinnerVisibilityService } from 'ng-http-loader';

@Injectable()
export class LoaderInterceptor implements HttpInterceptor {
    constructor(private spinner: SpinnerVisibilityService) { }

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        this.spinner.show();
        return <any>next.handle(request).pipe(
            catchError((error) => {
                this.spinner.hide();
                return throwError(error);
            }),
            finalize(() => this.spinner.hide())
        );
    }
}