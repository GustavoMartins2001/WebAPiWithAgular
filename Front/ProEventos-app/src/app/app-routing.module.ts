import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ContatosComponent } from './components/contatos/contatos.component';
import { EventoDetalheComponent } from './components/eventos/evento-detalhe/evento-detalhe.component';
import { EventoListaComponent } from './components/eventos/evento-lista/evento-lista.component';
import { EventosComponent } from './components/eventos/eventos.component';
import { PalestrantesDetalheComponent } from './components/palestrantes/palestrantes-detalhe/palestrantes-detalhe.component';
import { PalestrantesListaComponent } from './components/palestrantes/palestrantes-lista/palestrantes-lista.component';
import { PalestrantesComponent } from './components/palestrantes/palestrantes.component';

const routes: Routes =
[ {path: 'eventos', redirectTo: 'eventos/lista'},
  {path: 'eventos', component: EventosComponent,
  children: [
    {path: 'detalhe/:id', component: EventoDetalheComponent },
    {path: 'detalhe', component: EventoDetalheComponent },
    {path: 'lista', component: EventoListaComponent },
  ]
},

{path: 'contatos', component: ContatosComponent},
{path: 'palestrantes', redirectTo: 'palestrantes/lista'},
{path: 'palestrantes', component: PalestrantesComponent,
 children:[
   {path: 'detalhe/:id', component: PalestrantesDetalheComponent},
   {path: 'detalhe', component: PalestrantesDetalheComponent},
   {path: 'lista', component: PalestrantesListaComponent}
 ]
},
{path: '', redirectTo: 'eventos/lista', pathMatch: 'full'},
];

@NgModule({
  imports: [RouterModule.forRoot(routes, {onSameUrlNavigation: 'reload'})],
  exports: [RouterModule]
})
export class AppRoutingModule { }
