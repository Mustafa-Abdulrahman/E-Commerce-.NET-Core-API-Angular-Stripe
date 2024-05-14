import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from '../home/home.component';
import { ProductDetailsComponent } from './product-details/product-details.component';
import { ShopComponent } from './shop.component';
import { NotFoundComponent } from '../core/not-found/not-found.component';
import { ServerErrorComponent } from '../core/server-error/server-error.component';

const routes: Routes = [
  { path: '', component: ShopComponent },

  {
    path: ':id',
    component: ProductDetailsComponent,
    data: { breadcrumb: { alias: 'ProductDetails' } },
  },
];

@NgModule({
  declarations: [],
  imports: [CommonModule, RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ShopRoutingModule {}
