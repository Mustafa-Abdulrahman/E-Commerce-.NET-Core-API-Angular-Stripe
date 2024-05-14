import { Component, Input, OnInit } from '@angular/core';
import { IProductNoData } from '../../shared/Models/ProductNoData';

@Component({
  selector: 'app-shop-item',
  templateUrl: './shop-item.component.html',
  styleUrl: './shop-item.component.scss',
})
export class ShopItemComponent implements OnInit {
  @Input() product: IProductNoData;
  /**
   *
   */
  constructor() {}
  ngOnInit(): void {
    throw new Error('Method not implemented.');
  }
}
