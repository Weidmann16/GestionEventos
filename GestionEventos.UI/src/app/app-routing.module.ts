import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';
import { LoginComponent } from './pages/login/login.component';
import { authGuard } from './core/guards/auth-guard/auth.guard';
import { loginGuard } from './core/guards/login-guard/login.guard';
import { MisEventosComponent } from './pages/mis-eventos/mis-eventos.component';
import { EventosInscritosComponent } from './pages/eventos-inscritos/eventos-inscritos.component';

const routes: Routes = [
  { path: 'home', component: HomeComponent, canActivate: [authGuard] },
  { path: 'login', component: LoginComponent, canActivate: [loginGuard] },
  { path: 'mis-eventos', component: MisEventosComponent, canActivate: [authGuard] },
  { path: 'eventos-inscritos', component: EventosInscritosComponent, canActivate: [authGuard] },
  { path: '', redirectTo: '/home', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
