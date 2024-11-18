import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { AuthVistaService } from '@/Services/authVista/auth-vista.service';
import { map, take } from 'rxjs/operators';

export const authGuard: CanActivateFn = (route, state) => {
  const authService = inject(AuthVistaService);
  const router = inject(Router);

  return authService.isLoggedIn$.pipe(
    take(1), // Toma solo el primer valor y se completa
    map(isLoggedIn => {
      if (isLoggedIn) {
        return true;
      } else {
        router.navigate(['/login']);
        return true;
      }
    })
  );
};
