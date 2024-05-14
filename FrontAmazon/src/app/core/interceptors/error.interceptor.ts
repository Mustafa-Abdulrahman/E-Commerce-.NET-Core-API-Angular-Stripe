import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
} from '@angular/common/http';

import { Observable, throwError } from 'rxjs';
import { catchError, delay } from 'rxjs/operators';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {
  constructor(private router: Router, private toast: ToastrService) {}
  intercept(
    request: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    return next.handle(request).pipe(
      catchError((er) => {
        if (er) {
          if (er.status === 400) {
            this.toast.error(er.error.messaage, er.error.statusCode);
          }
          if (er.status === 401) {
            this.toast.error(er.error.messaage, er.error.statusCode);
          }
          if (er.status === 404) {
            this.router.navigateByUrl('not-found');
          }
          if (er.status === 500) {
            this.router.navigateByUrl('server-error');
          }
        }
        return throwError(() => {
          er.messaage || 'Server Not Found';
        });
      })
    );
  }
}
