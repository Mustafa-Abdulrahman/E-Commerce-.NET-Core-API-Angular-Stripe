import {
  CanActivateFn,
  CanActivate,
  Router,
  ActivatedRouteSnapshot,
  RouterStateSnapshot,
} from '@angular/router';
import { AccountService } from '../../account/account.service';
import { Observable, map } from 'rxjs';
import { Injectable } from '@angular/core';

// export const authGuard: CanActivateFn = (route, state) => {
//   return true;
// };
@Injectable({
  providedIn: 'root',
})
export class AuthGuard implements CanActivate {
  constructor(
    private accountServices: AccountService,
    private router: Router
  ) {}
  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): Observable<boolean> {
    return this.accountServices.currentUser$.pipe(
      map((auth) => {
        if (auth) {
          return true;
        }
        this.router.navigate(['account/login'], {
          queryParams: { returnUrl: state.url },
        });
      })
    );
  }
}
