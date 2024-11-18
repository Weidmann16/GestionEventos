import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { LoginUser } from '@/core/types/login-user.model';
import { Usuario } from '@/core/types/usuario.model';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private apiUrlLogin = 'https://localhost:7068/api/usuario'; // URL de API
  constructor(private http: HttpClient) { }

  login(username: string, password: string): Observable<any> {
    const loginUser: LoginUser = {
      NombreUsuarioLogin: username,
      ContrasenaUsuarioLogin: password
    };
    return this.http.post(`${this.apiUrlLogin}/login`, loginUser);
  }

  register(user: any): Observable<any> {
    return this.http.post(`${this.apiUrlLogin}/registro`, user);
  }
}
