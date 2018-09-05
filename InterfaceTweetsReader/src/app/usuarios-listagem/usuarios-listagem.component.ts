import { Component, OnInit } from '@angular/core';
import { UsuarioService } from '../usuario.service';

@Component({
  selector: 'app-usuarios-listagem',
  templateUrl: './usuarios-listagem.component.html',
  styleUrls: ['./usuarios-listagem.component.css']
})
export class UsuariosListagemComponent implements OnInit {

  usuarios: Array<any>;

  constructor(private usuariosService: UsuarioService) { }

  ngOnInit() {
    this.listar();
  }

  listar() {
    this.usuariosService.listar().subscribe(dados => this.usuarios = dados);
  }


}
