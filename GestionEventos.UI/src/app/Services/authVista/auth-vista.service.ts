import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { CookieService } from 'ngx-cookie-service';

@Injectable({
  providedIn: 'root'
})
export class AuthVistaService {
  private isLoggedInSubject = new BehaviorSubject<boolean>(false);
  isLoggedIn$ = this.isLoggedInSubject.asObservable();

  constructor(private cookieService: CookieService) {
    // Inicializar el estado de sesión
    this.checkLoginStatus();
  }

  checkLoginStatus(): void {
    // Comprueba si la cookie 'nombreUsuario' existe
    const nombreUsuario = this.cookieService.get('nombreUsuario');
    const isLoggedIn = !!nombreUsuario && nombreUsuario.trim() !== '';
    this.isLoggedInSubject.next(isLoggedIn);
  }

  logout(): void {
    // Eliminar las cookies y actualizar el estado de sesión
    this.cookieService.delete('nombreUsuario');
    this.cookieService.delete('idUsuario');
    this.isLoggedInSubject.next(false);
  }

  login(): void {
    // Llamar a este método cuando el usuario inicie sesión exitosamente
    this.isLoggedInSubject.next(true);
  }
}
