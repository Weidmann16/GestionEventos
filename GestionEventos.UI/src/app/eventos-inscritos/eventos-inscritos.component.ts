import { Component, OnInit } from '@angular/core';
import { AsistenteEventoService } from '@/Services/asistenteEvento/asistente-evento.service';
import { AuthVistaService } from '@/Services/authVista/auth-vista.service';
import { CookieService } from 'ngx-cookie-service';

@Component({
  selector: 'app-eventos-inscritos',
  templateUrl: './eventos-inscritos.component.html',
  styleUrl: './eventos-inscritos.component.css'
})
export class EventosInscritosComponent implements OnInit {
  eventosInscritos: any[] = [];
  idUsuario: string = '';

  constructor(
    private asistenteEventoService: AsistenteEventoService,
    private authVistaService: AuthVistaService,
    private cookieService: CookieService
) { }

  ngOnInit() {
    this.idUsuario = this.cookieService.get('idUsuario');
    this.authVistaService.checkLoginStatus();

    this.cargarEventosInscritos();
  }

  cargarEventosInscritos() {
    this.asistenteEventoService.getEventosInscritosPorUsuario(this.idUsuario).subscribe(
      (response: any[]) => {        
        this.eventosInscritos = response;
        //imprimir la data en consola
        console.log(this.eventosInscritos);
      },
      (error: any) => {
        console.error('Error al cargar eventos inscritos:', error);
      }
    );
  }
}
