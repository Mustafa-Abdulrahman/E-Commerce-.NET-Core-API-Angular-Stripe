import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { BehaviorSubject, map } from 'rxjs';
import {
  Basket,
  IBasket,
  IBasketItem,
  IBasketTotals,
} from '../shared/Models/Basket';
import { IProductNoData } from '../shared/Models/ProductNoData';
import { IDeliveryMethod } from '../shared/Models/deliveryMethod';

@Injectable({
  providedIn: 'root',
})
export class BasketService {
  baseURL: string = environment.baseUrl;
  private basketSource = new BehaviorSubject<IBasket>(null);
  basket$ = this.basketSource.asObservable();
  shipping: number = 0;
  constructor(private http: HttpClient) {}
  //
  createPaymentIntent() {
    return this.http
      .post(this.baseURL + '/Payments/' + this.getCurrentBasketvalue().id, {})
      .pipe(
        map((basket: IBasket) => {
          this.basketSource.next(basket);
          console.log(this.getCurrentBasketvalue());
        })
      );
  }

  private bsaketTotalSource = new BehaviorSubject<IBasketTotals>(null);
  basketTotal$ = this.bsaketTotalSource.asObservable();

  setShippingPrice(deliveryMethod: IDeliveryMethod) {
    this.shipping = deliveryMethod.price;
    const basket = this.getCurrentBasketvalue();
    basket.deliveryMethodId = deliveryMethod.id;
    basket.shippingPrice = deliveryMethod.price;
    this.calculateTotal();
    this.setBasket(basket);
  }

  incrementBasketItemQuantity(item: IBasketItem) {
    const basket = this.getCurrentBasketvalue();
    const itemIndex = basket.basketItems.findIndex((x) => x.id === item.id);
    basket.basketItems[itemIndex].quantity++;
    this.setBasket(basket);
  }
  decrementBasketItemQuantity(item: IBasketItem) {
    const basket = this.getCurrentBasketvalue();
    const itemIndex = basket.basketItems.findIndex((x) => x.id === item.id);

    if (basket.basketItems[itemIndex].quantity > 1) {
      basket.basketItems[itemIndex].quantity--;
      this.setBasket(basket);
    } else {
      this.removeItemFromBasket(item);
    }
  }
  removeItemFromBasket(item: IBasketItem) {
    const basket = this.getCurrentBasketvalue();
    if (basket.basketItems.some((x) => x.id === item.id)) {
      basket.basketItems = basket.basketItems.filter((x) => x.id !== item.id);
      if (basket.basketItems.length > 0) {
        this.setBasket(basket);
      } else {
        this.deleteBasket(basket);
      }
    }
  }
  deleteLocalBasekt(id: string) {
    this.basketSource.next(null);
    this.bsaketTotalSource.next(null);
    localStorage.removeItem('basket_id');
  }
  deleteBasket(basket: IBasket) {
    return this.http
      .delete(this.baseURL + `/Basket/delete-basket/:id?id=${basket.id}`)
      .subscribe({
        next: () => {
          this.basketSource.next(null);
          this.bsaketTotalSource.next(null);
          localStorage.removeItem('basket_id');
        },
        error: (err) => {
          console.log(err);
        },
      });
  }
  private calculateTotal() {
    const basket = this.getCurrentBasketvalue();
    const shipping = this.shipping;
    const subtotal = basket.basketItems.reduce((a, c) => {
      return c.price * c.quantity + a;
    }, 0);
    const total = shipping + subtotal;
    this.bsaketTotalSource.next({ shipping, subtotal, total });
  }
  //
  getBasket(id: string) {
    return this.http.get(this.baseURL + `/Basket/get-basket/:id?id=${id}`).pipe(
      map((basket: IBasket) => {
        this.basketSource.next(basket);
        this.shipping = basket.shippingPrice;
        this.calculateTotal();

        console.info(this.getCurrentBasketvalue());
      })
    );
  }
  setBasket(basket: IBasket) {
    return this.http
      .post(this.baseURL + '/Basket/update-basket', basket)
      .subscribe({
        next: (res: IBasket) => {
          this.basketSource.next(res);

          this.calculateTotal();
        },
        error: (err) => {
          console.error(err);
        },
      });
  }

  getCurrentBasketvalue() {
    return this.basketSource.value;
  }

  addItemToBasket(item: IProductNoData, quantity: number = 1) {
    const itemToAdd: IBasketItem = this.mapProductItemToBasketItem(
      item,
      quantity
    );
    const basket = this.getCurrentBasketvalue() ?? this.createBasket();
    basket.basketItems = this.addOrUpdate(
      basket.basketItems,
      itemToAdd,
      quantity
    );
    return this.setBasket(basket);
  }

  private addOrUpdate(
    basketItems: IBasketItem[],
    itemToAdd: IBasketItem,
    quantity: number
  ): IBasketItem[] {
    const index = basketItems.findIndex((i) => i.id === itemToAdd.id);
    if (index === -1) {
      itemToAdd.quantity = quantity;
      basketItems.push(itemToAdd);
    } else {
      basketItems[index].quantity += quantity;
    }
    return basketItems;
  }
  private createBasket(): IBasket {
    const basket = new Basket();
    localStorage.setItem('basket_id', basket.id);
    return basket;
  }

  private mapProductItemToBasketItem(
    item: IProductNoData,
    quantity: number
  ): IBasketItem {
    return {
      id: item.id,
      productName: item.name,
      price: item.price,
      productPicture: item.image,
      quantity,
    };
  }
  //
}
