import { Component, Input, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { BasketService } from '../../basket/basket.service';
import { CheckoutService } from '../checkout.service';
import { IDeliveryMethod } from '../../shared/Models/deliveryMethod';

@Component({
  selector: 'app-checkout-delivery',
  templateUrl: './checkout-delivery.component.html',
  styleUrl: './checkout-delivery.component.scss',
})
export class CheckoutDeliveryComponent implements OnInit {
  @Input() checkoutForm: FormGroup;
  deliveryMethods: IDeliveryMethod[];
  constructor(
    private checkoutService: CheckoutService,
    private basketService: BasketService
  ) {}

  ngOnInit(): void {
    this.checkoutService.getDeliveryMehtods().subscribe({
      next: (res: IDeliveryMethod[]) => {
        this.deliveryMethods = res;
      },
      error: (err) => {
        console.error(err);
      },
    });
  }

  setShippingPrice(deliceryMethod: IDeliveryMethod) {
    this.basketService.setShippingPrice(deliceryMethod);
  }
}
