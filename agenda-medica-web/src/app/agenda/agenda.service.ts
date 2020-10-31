import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Agenda } from '../Models/agenda';

@Injectable({
  providedIn: 'root'
})
export class AgendaService {
  baseApiUrl = `${environment.ApiUrl}/agenda`;

constructor(private http: HttpClient) { }

listarTodos() : Observable<Agenda[]>{
  return this.http.get<Agenda[]>(`${this.baseApiUrl}`);
}

obterPorId(id:number){
  return this.http.get<Agenda>(`${this.baseApiUrl}/${id}`);
}

post(agenda:Agenda){
  return this.http.post(`${this.baseApiUrl}`, agenda);
}

put(agenda:Agenda){
  return this.http.put(`${this.baseApiUrl}`, agenda);
}

delete(agenda:Agenda){
  return this.http.delete(`${this.baseApiUrl}/${agenda.id}`);
}

}
