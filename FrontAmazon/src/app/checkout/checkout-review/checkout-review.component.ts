import { CdkStepper } from '@angular/cdk/stepper';
import { Component, Input, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { BasketService } from '../../basket/basket.service';

@Component({
  selector: 'app-checkout-review',
  templateUrl: './checkout-review.component.html',
  styleUrl: './checkout-review.component.scss',
})
export class CheckoutReviewComponent implements OnInit {
  @Input() appStepper: CdkStepper;
  constructor(
    private basketServices: BasketService,
    private torast: ToastrService
  ) {}

  ngOnInit(): void {}
  createPaymentIntent() {
    return this.basketServices.createPaymentIntent().subscribe({
      next: () => {
        this.appStepper.next();
      },
      error: (err) => {
        console.error(err.message);
      },
    });
  }
}
