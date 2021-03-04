import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-titulo',
  templateUrl: './titulo.component.html',
  styleUrls: ['./titulo.component.scss']
})
export class TituloComponent implements OnInit {

  constructor() { }

  // Comandos para serem alterados individualmente
  // nos respectivos componentes
  @Input() titulo: string | undefined;
  @Input() subtitulo = 'desde 2021';
  @Input() iconClass = 'fa fa-user';
  @Input() botaoListar = false;
  @Input() routingLink = '/eventos/lista';
  ngOnInit(): void {
  }

}
