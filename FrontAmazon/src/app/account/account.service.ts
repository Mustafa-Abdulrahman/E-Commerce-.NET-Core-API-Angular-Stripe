import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { BehaviorSubject, ReplaySubject, map, of } from 'rxjs';
import { IUser } from '../shared/Models/User';
import { Router } from '@angular/router';
import { IAddress } from '../shared/Models/Address';

@Injectable({
  providedIn: 'root',
})
export class AccountService {
  baseUrl = environment.baseUrl;
  private currentUser = new ReplaySubject<IUser>(1);
  currentUser$ = this.currentUser.asObservable();
  constructor(private http: HttpClient, private router: Router) {}
  loadCurrentUser(token: string) {
    if (token === null) {
      this.currentUser.next(null);
      return of(null);
    }
    let headers = new HttpHeaders();
    headers = headers.set('Authorization', `Bearer ${token}`);
    return this.http
      .get(this.baseUrl + '/Account/get-current-user', { headers })
      .pipe(
        map((user: IUser) => {
          localStorage.setItem('token', user.token);
          this.currentUser.next(user);
        })
      );
  }

  // ------------------------

  // ------------------------
  login(value: any) {
    return this.http.post(this.baseUrl + '/Account/Login', value).pipe(
      map((user: IUser) => {
        if (user) localStorage.setItem('token', user.token);
        this.currentUser.next(user);
      })
    );
  }

  register(value: any) {
    return this.http.post(this.baseUrl + '/Account/Register', value).pipe(
      map((user: IUser) => {
        if (user) localStorage.setItem('token', user.token);
        this.currentUser.next(user);
      })
    );
  }

  logout() {
    localStorage.removeItem('token'), this.currentUser.next(null);
    this.router.navigateByUrl('/');
  }
  checkEmailExist(email: string) {
    return this.http.get(
      this.baseUrl + `/Account/check-email-exist?email=${email}`
    );
  }

  getUserAddress() {
    return this.http.get<IAddress>(this.baseUrl + '/Account/get-user-address');
  }
  updateUserAddress(address: IAddress) {
    return this.http.put<IAddress>(
      this.baseUrl + '/Account/update-user-address',
      address
    );
  }
}
