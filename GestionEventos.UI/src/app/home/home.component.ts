import { Component, OnInit } from '@angular/core';
import { EventoService } from '@/Services/evento/evento.service';
import { AsistenteEventoService } from '@/Services/asistenteEvento/asistente-evento.service';
import { AuthVistaService } from '@/Services/authVista/auth-vista.service';
import { CookieService } from 'ngx-cookie-service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent implements OnInit {
  eventos: any[] = [];
  idUsuario: string = '';
  constructor(
    private eventoService: EventoService,
    private asignarEventoService: AsistenteEventoService,
    private authVistaService: AuthVistaService,
    private cookieService: CookieService) { }

  ngOnInit() {
    this.idUsuario = this.cookieService.get('idUsuario');
    this.authVistaService.checkLoginStatus();

    this.eventoService.getEventosDeOtrosUsuarios(this.idUsuario).subscribe(
      (response: any[]) => {
        this.eventos = response;
        console.log(this.eventos);
      },
      (error: any) => {
        console.error('Error al cargar eventos:', error);
      }
    );
  }

  asignarseEvento(idEvento: number): void {
    // Llamar al servicio para asignarse al evento
    this.asignarEventoService.asignarEventoService(idEvento, this.idUsuario).subscribe(
      (response: any) => {
        console.log('Asignado al evento:', response);
        alert('Te has asignado al evento con éxito.');
        // Actualizar la lista de eventos si es necesario
        this.ngOnInit();
      },
      (error: any) => {
        console.error('Error al asignarse al evento:', error);
        alert('Hubo un error al asignarse al evento.');
      }
    );
  }
}
