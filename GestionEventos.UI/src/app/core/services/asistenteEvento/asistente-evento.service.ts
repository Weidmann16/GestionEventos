import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AsistenteEvento } from '../../Types/asistente-evento.model';

@Injectable({
  providedIn: 'root'
})
export class AsistenteEventoService {

  private apiUrl = 'https://localhost:7068/api/asistenteevento';
  constructor(private http: HttpClient) { }

  asignarEventoService(idEvento: number, idUsuario: string): Observable<any> {
    const asistenteEvento: AsistenteEvento = {
      IdAsistenteEvento: 0,
      IdEventoAsistenteEvento: idEvento,
      IdUsuarioAsistenteEvento: parseInt(idUsuario, 10),
      EstadoAsistenteEvento: true
    };
    return this.http.post<any>(`${this.apiUrl}/AddAsistenteEvento`, asistenteEvento);
  }

  getEventosInscritosPorUsuario(idUsuario: string): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/GetAsistentesEventoByIdUsuario/${idUsuario}`);
  }
}
