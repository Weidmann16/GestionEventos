import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthVistaService } from '@/core/services/authVista/auth-vista.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  isLoggedIn: boolean = false;

  constructor(private authService: AuthVistaService, private router: Router) { }

  ngOnInit(): void {
    // Suscribirse al estado de sesión
    this.authService.isLoggedIn$.subscribe((loggedIn) => {
      this.isLoggedIn = loggedIn;
    });
  }

  logout(): void {
    // Llamar al método de cierre de sesión del servicio
    this.authService.logout();
    this.router.navigate(['/login']);
  }
}
