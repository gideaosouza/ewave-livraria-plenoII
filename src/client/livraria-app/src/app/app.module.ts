import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { NavbarComponent } from './layout/navbar/navbar.component';
import { FooterComponent } from './layout/footer/footer.component';
import { LivroComponent } from './livro/livro.component';
import { UsuarioComponent } from './usuario/usuario.component';
import { InstituicaoEnsinoComponent } from './instituicao-ensino/instituicao-ensino.component';
import { EmprestimoLivroComponent } from './emprestimo-livro/emprestimo-livro.component';
import { ReservaLivroComponent } from './reserva-livro/reserva-livro.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgxMaskModule, IConfig } from 'ngx-mask'

// export const options: Partial<IConfig> | (() => Partial<IConfig>);

const maskConfig: Partial<IConfig> = {
  validation: false,
};

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    FooterComponent,
    LivroComponent,
    UsuarioComponent,
    InstituicaoEnsinoComponent,
    EmprestimoLivroComponent,
    ReservaLivroComponent
  ],
  imports: [
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserModule,
    AppRoutingModule,
    NgxMaskModule.forRoot(maskConfig),
    NgbModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
