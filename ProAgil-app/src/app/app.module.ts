import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import {FormsModule} from '@angular/forms';
import {BsDropdownModule, TooltipModule, ModalModule} from 'ngx-bootstrap';
import { AppRoutingModule } from './app-routing.module';

import { EventosComponent } from './eventos/eventos.component';

import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';

import { DateTimeFormatPipePipe } from './_helpers/DateTimeFormatPipe.pipe';

@NgModule({
   declarations: [
      AppComponent,
      EventosComponent,
      NavComponent,
      DateTimeFormatPipePipe
   ],
   imports: [
      BrowserModule,
      BsDropdownModule.forRoot(),
      TooltipModule.forRoot(),
      ModalModule.forRoot(),
      AppRoutingModule,
      HttpClientModule,
      FormsModule,
   ],
   providers: [],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
