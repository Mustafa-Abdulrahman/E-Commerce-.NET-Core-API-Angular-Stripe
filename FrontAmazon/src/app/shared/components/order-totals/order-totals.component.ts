import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { IBasketTotals } from '../../Models/Basket';
import { BasketService } from '../../../basket/basket.service';

@Component({
  selector: 'app-order-totals',
  templateUrl: './order-totals.component.html',
  styleUrl: './order-totals.component.scss',
})
export class OrderTotalsComponent implements OnInit {
  basketTotals$: Observable<IBasketTotals>;
  constructor(private basketService: BasketService) {}

  ngOnInit(): void {
    this.basketTotals$ = this.basketService.basketTotal$;
  }
}
