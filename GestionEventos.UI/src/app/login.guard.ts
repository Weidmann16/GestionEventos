import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { AuthVistaService } from '@/Services/authVista/auth-vista.service';
import { map, take } from 'rxjs/operators';

export const loginGuard: CanActivateFn = (route, state) => {
  const authService = inject(AuthVistaService);
  const router = inject(Router);

  return authService.isLoggedIn$.pipe(
    take(1),
    map(isLoggedIn => {
      if (isLoggedIn) {
        // Si el usuario está autenticado, redirige a /home
        router.navigate(['/home']);
        return false; // Bloquear acceso a la página de login
      } else {
        return true; // Permitir acceso si no está autenticado
      }
    })
  );
};
