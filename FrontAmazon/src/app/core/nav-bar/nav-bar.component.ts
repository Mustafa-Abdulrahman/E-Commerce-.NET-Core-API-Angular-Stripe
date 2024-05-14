import { Component, OnInit } from '@angular/core';
import { BasketService } from '../../basket/basket.service';
import { Observable } from 'rxjs';
import { IBasket } from '../../shared/Models/Basket';
import { AccountService } from '../../account/account.service';
import { IUser } from '../../shared/Models/User';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrl: './nav-bar.component.scss',
})
export class NavBarComponent implements OnInit {
  constructor(
    private basketSetrvice: BasketService,
    private accountService: AccountService
  ) {}
  basket$: Observable<IBasket>;
  currentUser$: Observable<IUser>;
  ngOnInit(): void {
    this.basket$ = this.basketSetrvice.basket$;
    this.currentUser$ = this.accountService.currentUser$;
  }
  logout() {
    this.accountService.logout();
  }
}
