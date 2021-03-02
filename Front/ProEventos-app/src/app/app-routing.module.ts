import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ContatosComponent } from './componets/contatos/contatos.component';
import { DashboardComponent } from './componets/dashboard/dashboard.component';
import { EventosComponent } from './componets/eventos/eventos.component';
import { PalestrantesComponent } from './componets/palestrantes/palestrantes.component';

const routes: Routes =
[{path: 'eventos', component: EventosComponent},
{path: 'dashboard', component: DashboardComponent},
{path: 'contatos', component: ContatosComponent},
{path: 'palestrantes', component: PalestrantesComponent},
{path: '', redirectTo: 'dashboard', pathMatch: 'full'},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
