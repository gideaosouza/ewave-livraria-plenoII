import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LivroComponent } from './livro/livro.component';
import { UsuarioComponent } from './usuario/usuario.component';
import { InstituicaoEnsinoComponent } from './instituicao-ensino/instituicao-ensino.component';
import { EmprestimoLivroComponent } from './emprestimo-livro/emprestimo-livro.component';
import { ReservaLivroComponent } from './reserva-livro/reserva-livro.component';


const routes: Routes = [

  { path: 'livro', component: LivroComponent },
  { path: 'usuario', component: UsuarioComponent },
  { path: 'instituicao-ensino', component: InstituicaoEnsinoComponent },
  { path: 'emprestimo-livro', component: EmprestimoLivroComponent },
  { path: 'reserva-livro', component: ReservaLivroComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
