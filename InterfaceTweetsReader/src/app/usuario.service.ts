import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {

  usuariosUrl = "http://localhost:5000/api/usuarios";

  constructor(private http: HttpClient) { }

  listar() {

    return this.http.get<any[]>(`${this.usuariosUrl}`);

  }
}
