import { HttpClient } from '@angular/common/http';
import { Component, OnInit, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { isWhileStatement } from 'typescript';
import { EventoService } from '../services/evento.service';
import { Evento } from '../_models/Evento';


@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})

export class EventosComponent implements OnInit {
  modalRef?: BsModalRef;
  public isExpanded = false;
  public imageWidth = 80;
  public imageMargin = 2;
  public eventos: Evento[] = [];
  public eventosFiltrados: Evento[] = [];
  private filtroListado = '';

  public get filtroLista(): string{
    return this.filtroListado;
  }


public set filtro(value: string){
  this.filtroListado = value;
  this.eventosFiltrados = this.filtro ? this.filtrarEventos(this.filtro) : this.eventos;
}

public filtrarEventos(filtrarPor: string): Evento[] {
  filtrarPor = filtrarPor.toLocaleLowerCase();
  return this.eventos.filter(
   (evento: any) => evento.tema.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    );

}

  constructor(
    private eventoService: EventoService,
    private modalService: BsModalService,
    private spinner: NgxSpinnerService
    ) { }


  ngOnInit(): void {
    this.getEventos();
    /** show spinner on load */
    this.spinner.show();

    // setTimeout(() => {
    //   /** spinner ends after 5 seconds */
    //
    // }, 5000);
  }


  public getEventos(): void {
    this.eventoService.getEvento()
    .subscribe({
      next: (eventos: Evento[]) =>
       {this.eventos = eventos;
        this.eventosFiltrados = eventos;
       },
        error: (error: any )=> {
          this.spinner.hide();
          console.log(error);
        },
        complete: () => this.spinner.hide()});
  }
  public expandImage(): void{
    if (!this.isExpanded){
      this.imageWidth = 200;
    }
    else{
      this.imageWidth = 80;
    }

    this.isExpanded = ! this.isExpanded;

  }

  openModal(template: TemplateRef<any>): void{
    this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
  }

  confirm(): void {
    if (this.modalRef !== undefined){
    this.modalRef.hide();
    }


  }
  decline(): void {
    if (this.modalRef !== undefined){
    this.modalRef.hide();

    }
  }
  modalHide(): void{
    if (this.modalRef !== undefined){
    this.modalRef.hide();
    }
  }

}
