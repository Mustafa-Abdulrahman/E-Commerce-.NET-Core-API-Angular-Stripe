import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { RouterModule } from '@angular/router';
import { NotFoundComponent } from './not-found/not-found.component';
import { ServerErrorComponent } from './server-error/server-error.component';
import { Toast, ToastrModule } from 'ngx-toastr';
import { SectionHeaderComponent } from './section-header/section-header.component';
import { BreadcrumbComponent } from 'xng-breadcrumb';
import { SharedModule } from '../shared/shared.module';
import { AuthGuard } from './Guards/auth.guard';
@NgModule({
  declarations: [
    NavBarComponent,
    NotFoundComponent,
    ServerErrorComponent,
    SectionHeaderComponent,
  ],
  imports: [
    CommonModule,
    RouterModule,
    ToastrModule.forRoot({
      positionClass: 'toast-bottom-right',
      countDuplicates: true,
      preventDuplicates: true,
    }),
    BreadcrumbComponent,
    SharedModule,
  ],

  exports: [NavBarComponent, SectionHeaderComponent],
})
export class CoreModule {}
