import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ShopComponent } from './shop.component';
import { ProductDetailsComponent } from './product-details/product-details.component';
import { RouterModule } from '@angular/router';
import { ShopRoutingModule } from './shop-routing.module';
import { BreadcrumbComponent } from 'xng-breadcrumb';

@NgModule({
  declarations: [ShopComponent, ProductDetailsComponent],
  imports: [CommonModule, ShopRoutingModule, BreadcrumbComponent],
  exports: [ShopComponent],
})
export class ShopModule {}
