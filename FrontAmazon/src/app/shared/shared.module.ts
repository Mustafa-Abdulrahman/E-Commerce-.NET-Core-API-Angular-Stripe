import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CarouselModule } from 'ngx-bootstrap/carousel';
import { OrderTotalsComponent } from './components/order-totals/order-totals.component';
import { BasketSummeryComponent } from './components/basket-summery/basket-summery.component';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { CdkStepperModule } from '@angular/cdk/stepper';
import { StepperComponent } from './components/stepper/stepper.component';
import { CheckoutSuccessComponent } from './components/checkout-success/checkout-success.component';

@NgModule({
  declarations: [
    OrderTotalsComponent,
    BasketSummeryComponent,
    StepperComponent,
    CheckoutSuccessComponent,
  ],
  imports: [
    CommonModule,
    CarouselModule.forRoot(),
    RouterModule,
    ReactiveFormsModule,
    BsDropdownModule.forRoot(),
    CdkStepperModule,
  ],
  exports: [
    CarouselModule,
    OrderTotalsComponent,
    BasketSummeryComponent,
    ReactiveFormsModule,
    BsDropdownModule,
    StepperComponent,
    CdkStepperModule,
  ],
})
export class SharedModule {}
