import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { Alert } from '../model/ui/alert';
import { EmprestimoLivro } from '../model/emprestimo-livro';
import { EmprestimoLivroService } from '../services/emprestimo-livro.service';
import { Usuario } from '../model/usuario';
import { UsuarioService } from '../services/usuario.service';
import { LivroService } from '../services/livro.service';
import { Livro } from '../model/livro';
import { ErroEmprestimo } from '../model/erros/emprestimo-livro.response.erro';

@Component({
  selector: 'app-emprestimo-livro.',
  templateUrl: './emprestimo-livro.component.html',
  styleUrls: ['./emprestimo-livro.component.css']
})

export class EmprestimoLivroComponent implements OnInit {
  emprestimosLivros: EmprestimoLivro[] = [];
  livrosEmprestadosComPrazoExtrapolado: EmprestimoLivro[] = [];
  exibeLivroExtrapoladoAlert  = false;
  usuarios: Usuario[] = [];
  livros: Livro[] = [];
  emprestimoLivroForm: FormGroup;
  alerts: Alert[];
  

  constructor(public emprestimoLivroService: EmprestimoLivroService, public fb: FormBuilder,
    public usuarioService: UsuarioService, public livroService: LivroService) { }

  ngOnInit(): void {
    this.emprestimoLivroForm = this.fb.group({
      usuarioId: 0,
      livroId: 0,
      dataDevolucao: [''],
      devolvido: false,
      id: 0
    })

    this.emprestimoLivroService.getAll().subscribe((data: EmprestimoLivro[]) => {
      console.log(data);
      this.emprestimosLivros = data;
    })

    this.alerts = [];

    this.usuarioService.getAll().subscribe((data: Usuario[]) => {
      this.usuarios = data;
    })
    
    this.livroService.getAll().subscribe((data: Livro[]) => {
      this.livros = data;
    })

    this.emprestimoLivroService.getLivrosComPrazoExtrapolado().subscribe((data: EmprestimoLivro[]) => {
      this.livrosEmprestadosComPrazoExtrapolado = data;
    })   
    
  }

  desabilitar(id: number) {
    this.emprestimoLivroService.desabilitar(id).subscribe(
      res => {
        this.alerts.push({
          type: 'success',
          message: 'Cadastro desabilitado com Sucesso!',
        })
        this.emprestimoLivroService.getAll().subscribe((data: EmprestimoLivro[]) => {
          console.log(data);
          this.emprestimosLivros = data;
        })
        this.emprestimoLivroForm = this.fb.group({
          usuarioId: 0,
          livroId: 0,
          dataDevolucao: [''],
          devolvido: false,
          id: 0
        })
      },
      (erro) => this.manipulaErros(erro))
  }
  update(id: number) {
    let obj = this.emprestimosLivros.find(c => c.id == id)

    this.emprestimoLivroForm.setValue({
      usuarioId: obj.usuarioId,
      livroId: obj.livroId,
      dataDevolucao: new Date(obj.dataDevolucao).toISOString().slice(0, 10),
      devolvido: obj.devolvido,
      id: id
    })
  }
  submitForm() {

    if (this.emprestimoLivroForm.controls.id.value == 0)
      this.adiciona()
    else
      this.atualiza();
  }

  manipulaErros(erro) {
    try {
      let errorValidation = erro as ErroEmprestimo

      errorValidation.errors?.DataDevolucao?.forEach(element => {
        this.alerts.push({
          type: 'danger',
          message: 'Data de Devolulção: ' + element,
        })
      })
      errorValidation.errors?.LivroId?.forEach(element => {
        this.alerts.push({
          type: 'danger',
          message: 'Livro: ' + element,
        })
      })
      errorValidation.errors?.UsuarioId?.forEach(element => {
        this.alerts.push({
          type: 'danger',
          message: 'Usuário: ' + element,
        })
      })



    } catch{ }

    try {

      this.alerts.push({
        type: 'danger',
        message: 'Ops: ' + erro[0].errorMessage
      })
    } catch{ }

  }

  adiciona() {
    this.emprestimoLivroService.create(this.emprestimoLivroForm.value).subscribe(
      res => {
        this.alerts.push({
          type: 'success',
          message: 'Cadastro efetuado com Sucesso!',
        })
        this.emprestimoLivroService.getAll().subscribe((data: EmprestimoLivro[]) => {
          console.log(data);
          this.emprestimosLivros = data;
        })
        this.emprestimoLivroForm = this.fb.group({
          usuarioId: 0,
          livroId: 0,
          dataDevolucao: [''],
          devolvido: false,
          id: 0
        })
      },
      (erro) => this.manipulaErros(erro))
  }

  atualiza() {
    this.emprestimoLivroService.update(this.emprestimoLivroForm.controls.id.value, this.emprestimoLivroForm.value).subscribe(
      res => {
        this.alerts.push({
          type: 'success',
          message: 'Cadastro atualizado com Sucesso!',
        })
        this.emprestimoLivroService.getAll().subscribe((data: EmprestimoLivro[]) => {
          console.log(data);
          this.emprestimosLivros = data;
        })
        this.emprestimoLivroForm = this.fb.group({
          usuarioId: 0,
          livroId: 0,
          dataDevolucao: [''],
          devolvido: false,
          id: 0
        })
      },
      (erro) => this.manipulaErros(erro))
  }

  changeLivro(e) {
    this.emprestimoLivroForm.controls.livroId.setValue(Number(e.target.value.substr(e.target.value.length - 1)))
  }
  changeUsuario(e) {
    this.emprestimoLivroForm.controls.usuarioId.setValue(Number(e.target.value.substr(e.target.value.length - 1)))
  }

  close(alert: Alert) {
    this.alerts.splice(this.alerts.indexOf(alert), 1);
  }
 
}
