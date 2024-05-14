import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { IBasket, IBasketItem } from '../../Models/Basket';
import { BasketService } from '../../../basket/basket.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-basket-summery',
  templateUrl: './basket-summery.component.html',
  styleUrl: './basket-summery.component.scss',
})
export class BasketSummeryComponent implements OnInit {
  basket$: Observable<IBasket>;
  @Output() decrement: EventEmitter<IBasketItem> =
    new EventEmitter<IBasketItem>();
  @Output() increment: EventEmitter<IBasketItem> =
    new EventEmitter<IBasketItem>();
  @Output() remove: EventEmitter<IBasketItem> = new EventEmitter<IBasketItem>();
  @Input() isBasket: boolean = true;
  constructor(private basketService: BasketService) {}

  ngOnInit(): void {
    this.basket$ = this.basketService.basket$;
  }
  decrementBasketItemQuantity(item: IBasketItem) {
    this.decrement.emit(item);
  }
  incrementBasketItemQuantity(item: IBasketItem) {
    this.increment.emit(item);
  }
  removeBasketItem(item: IBasketItem) {
    this.remove.emit(item);
  }
}
