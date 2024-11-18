import { Component, OnInit } from '@angular/core';
import { EventoService } from '@/core/services/evento/evento.service';
import { AuthVistaService } from '@/core/services/authVista/auth-vista.service';
import { CookieService } from 'ngx-cookie-service';

@Component({
  selector: 'app-mis-eventos',
  templateUrl: './mis-eventos.component.html',
  styleUrl: './mis-eventos.component.css'
})
export class MisEventosComponent implements OnInit {

  idUsuario: string = '';

  eventosCreados: any[] = [];
  eventoEditando: any = null;

  nuevoEvento = {
    nombreEvento: '',
    descripcionEvento: '',
    fechaEvento: '',
    ubicacionEvento: '',
    capacidadEvento: 0,
    estadoEvento: true,
    idUsuarioEvento: 0
  };
  mostrarFormulario: boolean = false;

  constructor(
    private eventoService: EventoService,
    private authVistaService: AuthVistaService,
    private cookieService: CookieService) { }

  ngOnInit() {
    this.idUsuario = this.cookieService.get('idUsuario');
    this.authVistaService.checkLoginStatus();
    this.cargarMisEventos();
  }

  cargarMisEventos() {
    this.eventoService.getEventosByUsuarios(this.idUsuario).subscribe(
      (response: any[]) => {
        this.eventosCreados = response;
      },
      (error: any) => {
        console.error('Error al cargar eventos creados:', error);
      }
    );
  }
 
  crearEvento() {
    this.nuevoEvento.idUsuarioEvento = parseInt(this.idUsuario, 10);
    this.eventoService.createEvento(this.nuevoEvento).subscribe(
      (response: any) => {
        console.log('Evento creado:', response);
        this.cargarMisEventos();
        this.toggleFormulario();

        //resetear formulario
        this.nuevoEvento = {
          nombreEvento: '',
          descripcionEvento: '',
          fechaEvento: '',
          ubicacionEvento: '',
          capacidadEvento: 0,
          estadoEvento: true,
          idUsuarioEvento: 0
        }

        alert('Evento creado con éxito.');
      },
      (error: any) => {
        console.error('Error al crear evento:', error);
        alert('Hubo un error al crear el evento.');
      }
    );
  }
  toggleFormulario() {
    this.mostrarFormulario = !this.mostrarFormulario; // Alternar visibilidad
  }

  habilitarEdicion(evento: any) {
    this.eventoEditando = { ...evento }; // Clonar el evento para edición
  }

  // Método para guardar los cambios del evento
  guardarEdicion() {
    this.eventoService.updateEvento(this.eventoEditando).subscribe(
      (response: any) => {
        console.log('Evento editado:', response);
        this.eventoEditando = null; // Desactivar modo de edición
        this.cargarMisEventos(); // Actualizar la lista de eventos
        alert('Evento editado con éxito.');
      },
      (error: any) => {
        console.error('Error al editar evento:', error);
        alert('Hubo un error al editar el evento.');
      }
    );
  }

  cancelarEdicion() {
    this.eventoEditando = null; // Desactivar modo de edición
  }

  eliminarEvento(idEvento: number, asistentes: number) {
    if (asistentes > 0) {
      alert('No se puede eliminar este evento porque tiene asistentes inscritos.');
      return;
    }

    this.eventoService.deleteEvento(idEvento).subscribe(
      (response: any) => {
        console.log('Evento eliminado:', response);
        this.cargarMisEventos(); // Actualizar la lista de eventos
        alert('Evento eliminado con éxito.');
      },
      (error: any) => {
        console.error('Error al eliminar evento:', error);
        alert('Hubo un error al eliminar el evento.');
      }
    );
  }

}
