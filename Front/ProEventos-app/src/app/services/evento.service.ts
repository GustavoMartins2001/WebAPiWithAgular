import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Evento } from '../_models/Evento';

@Injectable({
  providedIn: 'root'
})
export class EventoService {

  BaseURL = 'https://localhost:5001/api/eventos';
constructor(private http: HttpClient) { }

getEvento(): Observable<Evento[]>{
  return this.http.get<Evento[]>(this.BaseURL);
}
getEventoByTema(tema: string): Observable<Evento[]>{
  return this.http.get<Evento[]>(`${this.BaseURL}/${tema}/tema`);
}
getEventoById(id: number): Observable<Evento>{
  return this.http.get<Evento>(`this.BaseURL/${id}`);
}
}
