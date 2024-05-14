import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { BreadcrumbService } from 'xng-breadcrumb';
import { IOrder } from '../../shared/Models/order';
import { OrdersService } from '../orders.service';

@Component({
  selector: 'app-order-details',
  templateUrl: './order-details.component.html',
  styleUrl: './order-details.component.scss',
})
export class OrderDetailsComponent implements OnInit {
  order: IOrder;
  constructor(
    private orderService: OrdersService,
    private breadCurmbSerevice: BreadcrumbService,
    private router: ActivatedRoute
  ) {
    this.breadCurmbSerevice.set('@OrderDetails', '');
  }

  ngOnInit(): void {
    const id = +this.router.snapshot.paramMap.get('id');
    this.orderService.getOrdersDetails(id).subscribe({
      next: (order: IOrder) => {
        this.order = order;
        this.breadCurmbSerevice.set(
          '@OrderDetails',
          `Order ${order.id} - ${order.orderStatus}`
        );
      },
      error: (err) => {
        console.error(err.message);
      },
    });
  }
}
