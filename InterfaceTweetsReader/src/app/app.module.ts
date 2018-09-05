import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { TweetsListagemComponent } from './tweets-listagem/tweets-listagem.component';
import { TweetsService } from './tweets.service';
import { UsuariosListagemComponent } from './usuarios-listagem/usuarios-listagem.component';
import { UsuarioService } from './usuario.service';

@NgModule({
  declarations: [
    AppComponent,
    TweetsListagemComponent,
    UsuariosListagemComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule
  ],
  providers: [TweetsService, UsuarioService],
  bootstrap: [AppComponent]
})
export class AppModule { }
