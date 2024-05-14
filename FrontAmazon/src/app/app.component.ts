import { Component, OnInit } from '@angular/core';
import { BasketService } from './basket/basket.service';
import { AccountService } from './account/account.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss',
})
export class AppComponent implements OnInit {
  constructor(
    private basketService: BasketService,
    private accountService: AccountService
  ) {}
  // testReduce() {
  //   const numbers = [1, 2, 3, 4];
  //   const sum = numbers.reduce((a, c) => {
  //     return a + c;
  //   }, 0);
  //   console.log(sum);
  // }
  ngOnInit(): void {
    // this.testReduce();
    this.loadCurrentUser();
    this.loadBasket();
  }

  loadBasket() {
    const basketId = localStorage.getItem('basket_id');
    if (basketId) {
      this.basketService.getBasket(basketId).subscribe({
        next: () => {
          console.log('intialBasket');
        },
        error: (err) => {
          console.error(err);
        },
      });
    }
  }
  loadCurrentUser() {
    const tokenValue = localStorage.getItem('token');

    this.accountService.loadCurrentUser(tokenValue).subscribe({
      next: () => {
        console.log('Loaded Successfuly');
      },
      error: (err) => {
        console.log(err);
      },
    });
  }
}
