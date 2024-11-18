import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { authGuard } from './auth.guard';
import { loginGuard } from './login.guard';
import { MisEventosComponent } from './mis-eventos/mis-eventos.component';
import { EventosInscritosComponent } from './eventos-inscritos/eventos-inscritos.component';

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
