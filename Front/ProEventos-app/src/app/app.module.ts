import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';

import { BrowserModule } from '@angular/platform-browser';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { EventosComponent } from './componets/eventos/eventos.component';
import { PalestrantesComponent } from './componets/palestrantes/palestrantes.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { NavComponent } from './shared/nav/nav.component';



import { CollapseModule } from 'ngx-bootstrap/collapse';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { TooltipModule } from 'ngx-bootstrap/tooltip';
import { ModalModule } from 'ngx-bootstrap/modal';

import { EventoService } from './services/evento.service';
import { DateTimeFormatPipe } from './helpers/DateTimeFormat.pipe';
import { NgxSpinnerModule } from 'ngx-spinner';
import { DashboardComponent } from './componets/dashboard/dashboard.component';
import { TituloComponent } from './shared/titulo/titulo.component';
import { ContatosComponent } from './componets/contatos/contatos.component';

@NgModule({
  declarations: [
    AppComponent,
      EventosComponent,
      PalestrantesComponent,
      DashboardComponent,
      ContatosComponent,
      TituloComponent,
      NavComponent,
      DateTimeFormatPipe
   ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    CollapseModule.forRoot(),
    NgbModule,
    FormsModule,
    BsDropdownModule.forRoot(),
    TooltipModule.forRoot(),
    ModalModule.forRoot(),
    NgxSpinnerModule

  ],
  providers: [
    EventoService,
  ],
  bootstrap: [AppComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class AppModule { }
