import { Component } from '@angular/core';
import { AuthService } from '@/Services/auth/auth.service';
import { Router } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';
import { AuthVistaService } from '@/Services/authVista/auth-vista.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  username: string = '';
  password: string = '';
  mostrarRegistro: boolean = false;

  // Variables de registro
  idUsuarioRegistro: string = '';
  nombreUsuarioRegistro: string = '';
  passwordRegistro: string = '';
  nombreRegistro: string = '';
  apellidoRegistro: string = '';

  constructor(
    private authService: AuthService,
    private router: Router,
    private cookieService: CookieService,
    private authVistaService: AuthVistaService,
  ) { }

  onSubmit() {
    this.authService.login(this.username, this.password).subscribe(
      (response: any) => {
        // Mensaje de éxito
        console.log('Login exitoso:', response);

        // Guardar datos de usuario en cookies
        this.cookieService.set('idUsuario', response.idUsuario);
        this.cookieService.set('nombreUsuario', response.nombreUsuario);
        this.cookieService.set('apellidoUsuario', response.apellidoUsuario);
        this.cookieService.set('nombreUsuarioLogin', response.nombreUsuarioLogin);

        this.authVistaService.login();

        // Redirigir a la página de inicio
        this.router.navigate(['/home']);
      },
      (error: any) => {
        // Maneja errores de autenticación
        console.error('Error en el login:', error);
        alert('Usuario o contraseña incorrectos');
      }
    );
  }

  toggleRegistro() {
    // Alterna la visibilidad del formulario de registro
    this.mostrarRegistro = !this.mostrarRegistro;
  }

  onRegister() {
    // Lógica para registrar al usuario
    const nuevoUsuario = {
      IdUsuario: this.idUsuarioRegistro,
      NombreUsuarioLogin: this.nombreUsuarioRegistro,
      ContrasenaUsuarioLogin: this.passwordRegistro,
      NombreUsuario: this.nombreRegistro,
      ApellidoUsuario: this.apellidoRegistro,
      EstadoUsuario: true
    };

    this.authService.register(nuevoUsuario).subscribe(
      (response: any) => {
        console.log('Registro exitoso:', response);
        alert('Usuario registrado con éxito');
        this.toggleRegistro(); // Oculta el formulario de registro
      },
      (error: any) => {
        console.error('Error en el registro:', error);
        alert('Hubo un error al registrar el usuario');
      }
    );
  }
}
