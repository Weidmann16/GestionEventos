import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Evento } from '../../Types/evento.model';

@Injectable({
  providedIn: 'root'
})
export class EventoService {

  private apiUrl = 'https://localhost:7068/api/evento';

  constructor(private http: HttpClient) { }

  getEventosDeOtrosUsuarios(idUsuario: string): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/GetEventosExceptByIdUsuario/${idUsuario}`);
  }

  getEventosByUsuarios(idUsuario: string): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/GetEventosByIdUsuario/${idUsuario}`);
  }

  createEvento(evento: any): Observable<any> {
    return this.http.post(this.apiUrl, evento);
  }

  updateEvento(evento: any): Observable<any> {

    const eventoUp : Evento = {
      IdEvento: evento.idEvento,
      NombreEvento: evento.nombreEvento,
      DescripcionEvento: evento.descripcionEvento,
      FechaEvento: evento.fechaEvento,
      UbicacionEvento: evento.ubicacionEvento,
      CapacidadEvento: evento.capacidadEvento,
      EstadoEvento: evento.estadoEvento,
      IdUsuarioEvento: evento.idUsuarioEvento,
      AsistentesEvento: evento.asistentesEvento,
      InscritoEvento: evento.inscritoEvento
    };

    return this.http.put(`${this.apiUrl}`, eventoUp);
  }

  deleteEvento(id: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }
}
