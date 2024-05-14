import { Component, OnInit } from '@angular/core';

import { ShopService } from './shop.service';
import { IProductNoData } from '../shared/Models/ProductNoData';
import { ICategory } from '../shared/Models/Category';
import { BasketService } from '../basket/basket.service';
import { Basket } from '../shared/Models/Basket';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrl: './shop.component.scss',
})
export class ShopComponent implements OnInit {
  ProductsNoData: IProductNoData[];
  Category: ICategory[];
  singleProduct: IProductNoData;
  /**
   *
   */
  constructor(
    private shopServices: ShopService,
    private basketServies: BasketService
  ) {}
  categoryId = 0;
  search = '';
  sort = '';

  ngOnInit(): void {
    this.getProductNoData(this.categoryId, this.search, this.sort);
    this.getAllCategory();
  }

  getProductNoData(categoryId, search, sort) {
    this.shopServices
      .getProductNoData(categoryId, search, sort)
      .subscribe((result) => {
        this.ProductsNoData = result;

        console.log(result);
      });
  }
  getAllCategory() {
    this.shopServices.getCategory().subscribe((result) => {
      this.Category = result;
      console.log(result);
    });
  }
  // getAllCategory() {
  //   this.shopServices.getCategory().subscribe({
  //     next: (result) => (this.Category = result),
  //     error: (err) => (this.validationError = err.errors),
  //   });
  // }
  // -------------------
  onCategorySelect(cateId: number) {
    this.categoryId = cateId;
    this.getProductNoData(this.categoryId, this.search, this.sort);
  }

  resetAllFilter() {
    this.categoryId = 0;
    this.search = '';
    this.sort = '';
    this.getProductNoData(this.categoryId, this.search, this.sort);
  }
  searchFunc(inputField: string) {
    this.search = inputField;

    this.getProductNoData(this.categoryId, this.search, this.sort);
  }
  SortBy(value) {
    if (value == 2) {
      this.sort = 'PriceAsync';
    } else if (value == 1) {
      this.sort = 'PriceDesc';
    } else {
      this.sort = '';
    }

    this.getProductNoData(this.categoryId, this.search, this.sort);
  }
  addItemToBasket(item) {
    this.basketServies.addItemToBasket(item);
  }
}
