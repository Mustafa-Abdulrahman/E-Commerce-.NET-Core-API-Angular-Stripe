import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { HomeComponent } from './home/home.component';
import { NotFoundComponent } from './core/not-found/not-found.component';
import { ServerErrorComponent } from './core/server-error/server-error.component';
import { BreadcrumbComponent } from 'xng-breadcrumb';
import { skip } from 'rxjs';
import { AuthGuard } from './core/Guards/auth.guard';

const routes: Routes = [
  { path: '', component: HomeComponent, data: { breadcrumbs: 'Home' } },

  {
    path: 'not-found',
    component: NotFoundComponent,
    data: { breadcrumbs: 'Not Found' },
  },
  {
    path: 'server-error',
    component: ServerErrorComponent,
    data: { breadcrumbs: 'Server Error' },
  },
  {
    path: 'shop',
    loadChildren: () =>
      import('./shop/shop.module').then((mo) => mo.ShopModule),
    data: { breadcrumbs: 'Shop' },
  },
  {
    path: 'basket',
    loadChildren: () =>
      import('./basket/basket.module').then((mo) => mo.BasketModule),
    data: { breadcrumbs: 'Basket' },
  },
  {
    path: 'checkout',
    canActivate: [AuthGuard],
    loadChildren: () =>
      import('./checkout/checkout.module').then((mo) => mo.CheckoutModule),
    data: { breadcrumbs: 'Checkout' },
  },
  {
    path: 'account',
    loadChildren: () =>
      import('./account/account.module').then((mo) => mo.AccountModule),
    data: { breadcrumbs: { skip: true } },
  },
  {
    path: 'orders',
    loadChildren: () =>
      import('./orders/orders.module').then((mo) => mo.OrdersModule),
    data: { breadcrumbs: { breadcrumb: 'orders' } },
  },
  { path: '**', redirectTo: '/not-found', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
  providers: [AuthGuard],
})
export class AppRoutingModule {}
