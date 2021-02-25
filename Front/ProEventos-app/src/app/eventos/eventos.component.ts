import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { isWhileStatement } from 'typescript';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {
  isExpanded:boolean =false;
  imageWidth:number = 80;
  imageMargin:number = 2;
  public eventos : any = [];
  public eventosFiltrados: any = [];
  private _filtro:string ='';

  public get filtro(){
    return this._filtro;
  }

public set filtro(value:string){
  this._filtro = value;
  this.eventosFiltrados =this.filtro ? this.filtrarEventos(this.filtro) : this.eventos
}

public filtrarEventos(filtrarPor: string): any {
  filtrarPor = filtrarPor.toLocaleLowerCase();
  return this.eventos.filter(
   (evento:any) => evento.tema.toLocaleLowerCase().indexOf(filtrarPor) !==- 1
    )

}

  constructor(private http:HttpClient) { }

  ngOnInit() {
    this.getEventos();
  };

  public getEventos():void {
    this.http.get("https://localhost:5001/api/eventos")
    .subscribe(response=> {this.eventos = response
                           this.eventosFiltrados = response}, error =>console.log(error));
  }
  public expandImage():void{
    if(!this.isExpanded){
      this.imageWidth = 200;
    }
    else{
      this.imageWidth = 80;
    }

    this.isExpanded=!this.isExpanded;

  }

}
