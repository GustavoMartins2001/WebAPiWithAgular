import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Palestrante } from '../_models/Palestrante';

@Injectable({
  providedIn: 'root'
})
export class PalestranteService {

  httpOptions = {
    headers: new HttpHeaders({'Content-Type': 'application/json'})
  };
  BaseURL = 'https://localhost:5001/api/palestrantes';
constructor(private http: HttpClient) { }

getPalestrante(): Observable<Palestrante[]>{
  return this.http.get<Palestrante[]>(this.BaseURL);
}
getPalestranteByNome(nome: string): Observable<Palestrante[]>{
  return this.http.get<Palestrante[]>(this.BaseURL + '/nome/' + nome );
}
getPalestrantesById(id: number): Observable<Palestrante>{
  return this.http.get<Palestrante>(this.BaseURL + '/' + id);
}
postPalestrante(model: Palestrante): Observable<any>{
return this.http.post(this.BaseURL, model);
}
deletePalestrante(id: number): Observable<any>{
  return this.http.delete(this.BaseURL + '/' + id);
  }

}
