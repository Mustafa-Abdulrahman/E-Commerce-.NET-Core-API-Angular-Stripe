import { Component, OnInit } from '@angular/core';
import { ShopService } from '../shop.service';
import { ActivatedRoute } from '@angular/router';
import { IProductNoData } from '../../shared/Models/ProductNoData';
import { Breadcrumb } from 'xng-breadcrumb/lib/types';
import { BreadcrumbService } from 'xng-breadcrumb';
import { BasketService } from '../../basket/basket.service';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrl: './product-details.component.scss',
})
export class ProductDetailsComponent implements OnInit {
  singleProduct: IProductNoData;
  quantity: number = 1;
  /**
   *
   */
  constructor(
    private shopServices: ShopService,
    private activeRout: ActivatedRoute,
    private bcService: BreadcrumbService,
    private basketService: BasketService
  ) {
    this.bcService.set('@productDetails', ' ');
  }
  ngOnInit(): void {
    this.getProductById();
  }

  getProductById() {
    this.shopServices
      .getProductById(parseInt(this.activeRout.snapshot.paramMap.get('id')))
      .subscribe((result) => {
        this.singleProduct = result;
        this.bcService.set('@ProductDetails', result.name);
        console.log(result);
      });
  }
  addItemToBasket() {
    this.basketService.addItemToBasket(this.singleProduct, this.quantity);
  }
  incrementQuantity() {
    this.quantity++;
  }
  decrementQuantity() {
    if (this.quantity > 1) {
      this.quantity--;
    }
  }
}
