import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ModalModule } from 'ngx-bootstrap/modal';
import { SweetAlert2Module } from '@sweetalert2/ngx-sweetalert2';
import { ToastrModule } from 'ngx-toastr';
import { NgxSpinnerModule } from 'ngx-spinner';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { TimeagoModule } from 'ngx-timeago';
import { PaginationModule } from "ngx-bootstrap/pagination";
import { TabsModule } from "ngx-bootstrap/tabs";

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    BsDropdownModule.forRoot(),
    ModalModule.forRoot(),
    SweetAlert2Module.forRoot(),
    ToastrModule.forRoot({
      positionClass: 'toast-bottom-right'
    }),
    NgxSpinnerModule,
    TimeagoModule.forRoot(),
    PaginationModule.forRoot(),
    TabsModule.forRoot()
  ],
  exports: [
    ModalModule,
    SweetAlert2Module,
    ToastrModule,
    NgxSpinnerModule,
    BsDropdownModule,
    TimeagoModule,
    PaginationModule,
    TabsModule
  ]
})
export class SharedModule { }
