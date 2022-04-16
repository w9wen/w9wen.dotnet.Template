import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from "@angular/common/http";

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { SharedModule } from './_modules/shared.module';
import { ConfirmDialogComponent } from './_modals/confirm-dialog/confirm-dialog.component';
import { NavComponent } from './nav/nav.component';


@NgModule({
  declarations: [
    AppComponent,
    ConfirmDialogComponent,
    NavComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    NgbModule,
    BrowserAnimationsModule,
    SharedModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
