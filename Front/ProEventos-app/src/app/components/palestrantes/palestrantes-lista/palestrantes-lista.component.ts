import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit, TemplateRef } from '@angular/core';
import { Router } from '@angular/router';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { DataService } from 'src/app/services/Data.service';
import { PalestranteService } from 'src/app/services/palestrante.service';
import { Palestrante } from 'src/app/_models/Palestrante';

@Component({
  selector: 'app-palestrantes-lista',
  templateUrl: './palestrantes-lista.component.html',
  styleUrls: ['./palestrantes-lista.component.scss']
})
export class PalestrantesListaComponent implements OnInit {
  public id = 0;

  modalRef?: BsModalRef;
  public isExpanded = false;
  public imageWidth = 80;
  public imageMargin = 2;
  public Palestrantes: Palestrante[] = [];
  public PalestrantesFiltrados: Palestrante[] = [];
  private filtroListado = '';

  public get filtroLista(): string{
    return this.filtroListado;
  }


public set filtro(value: string){
  this.filtroListado = value;
  this.PalestrantesFiltrados = this.filtroListado ? this.filtrarPalestrantes(this.filtroLista) : this.Palestrantes;
}

public filtrarPalestrantes(filtrarPor: string): Palestrante[] {
  filtrarPor = filtrarPor.toLocaleLowerCase();
  return this.Palestrantes.filter(
   (pales: any) => pales.nome.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    );

}

  constructor(
    private palestranteService: PalestranteService,
    private modalService: BsModalService,
    private spinner: NgxSpinnerService,
    private router: Router,
    private dataService: DataService
    ) {
      this.dataService.callPalestranteFilter.subscribe(( data ) => {
        this.filtrarPalestrantes(this.filtroLista);
      });
     }


  ngOnInit(): void {
    this.getPalestrantes();
    // this.spinner.show();

  }


  public getPalestrantes(): void {
    this.palestranteService.getPalestrante()
    .subscribe ({
      next: (pales: Palestrante[]) =>
       {this.Palestrantes = pales;
        this.PalestrantesFiltrados = pales;
       },
        error: (error: any ) => {
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
  RefreshPage(): void{
    if (this.modalRef !== undefined){
    this.modalRef.hide();
    this.router.navigateByUrl('/', {skipLocationChange: true}).then(() =>
    this.router.navigate(['palestrantes/lista/']));
    }
  }

  detalhePalestrante(id: number): void{
    this.router.navigate([`palestrantes/detalhe/${id}`]);
  }

  getPalestranteId(id: number): void{
    this.id = id;
  }

  deletePalestrante(): void{
    console.log(this.id)
    this.palestranteService.deletePalestrante(this.id).subscribe(
      (data) => {
         console.log('Deleted successfully');
      },
      (error: HttpErrorResponse) => {
          console.log(error);
      }
    );
    this.id = 0;

  }


}
