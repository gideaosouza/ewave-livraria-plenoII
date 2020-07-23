import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { Alert } from '../model/ui/alert';
import { Usuario } from '../model/usuario';
import { UsuarioService } from '../services/usuario.service';
import { LivroService } from '../services/livro.service';
import { Livro } from '../model/livro';
import { ReservaLivro } from '../model/reserva-livro';
import { ReservaLivroService } from '../services/reserva-livro.service';
import { ErroReservaLivro } from '../model/erros/reserva-livro.response.erro';

@Component({
  selector: 'app-reserva-livro.',
  templateUrl: './reserva-livro.component.html',
  styleUrls: ['./reserva-livro.component.css']
})

export class ReservaLivroComponent implements OnInit {
  reservasLivros: ReservaLivro[] = [];
  usuarios: Usuario[] = [];
  livros: Livro[] = [];
  reservaLivroForm: FormGroup;
  alerts: Alert[];
  

  constructor(public reservaLivroService: ReservaLivroService, public fb: FormBuilder,
    public usuarioService: UsuarioService, public livroService: LivroService) { }

  ngOnInit(): void {
    this.reservaLivroForm = this.fb.group({
      usuarioId: 0,
      livroId: 0,
      dataResgate: [''],
      id: 0
    })

    this.reservaLivroService.getAll().subscribe((data: ReservaLivro[]) => {
      console.log(data);
      this.reservasLivros = data;
    })

    this.alerts = [];
    this.usuarioService.getAll().subscribe((data: Usuario[]) => {
      this.usuarios = data;
    })
    this.livroService.getAll().subscribe((data: Livro[]) => {
      this.livros = data;
    })
    
  }

  desabilitar(id: number) {
    this.reservaLivroService.desabilitar(id).subscribe(
      res => {
        this.alerts.push({
          type: 'success',
          message: 'Cadastro desabilitado com Sucesso!',
        })
        this.reservaLivroService.getAll().subscribe((data: ReservaLivro[]) => {
          console.log(data);
          this.reservasLivros = data;
        })
        this.reservaLivroForm = this.fb.group({
          usuarioId: 0,
          livroId: 0,
          dataResgate: [''],
          id: 0
        })
      },
      (erro) => this.manipulaErros(erro))
  }
  update(id: number) {
    let obj = this.reservasLivros.find(c => c.id == id)

    this.reservaLivroForm.setValue({
      usuarioId: obj.usuarioId,
      livroId: obj.livroId,
      dataResgate: new Date(obj.dataResgate).toISOString().slice(0, 10),
      id: id
    })
  }
  submitForm() {

    if (this.reservaLivroForm.controls.id.value == 0)
      this.adiciona()
    else
      this.atualiza();
  }

  manipulaErros(erro) {
    try {
      let errorValidation = erro as ErroReservaLivro

      errorValidation.errors?.DataResgate?.forEach(element => {
        this.alerts.push({
          type: 'danger',
          message: 'Data de Resgate: ' + element,
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
    this.reservaLivroService.create(this.reservaLivroForm.value).subscribe(
      res => {
        this.alerts.push({
          type: 'success',
          message: 'Cadastro efetuado com Sucesso!',
        })
        this.reservaLivroService.getAll().subscribe((data: ReservaLivro[]) => {
          console.log(data);
          this.reservasLivros = data;
        })
        this.reservaLivroForm = this.fb.group({
          usuarioId: 0,
          livroId: 0,
          dataResgate: [''],
          id: 0
        })
      },
      (erro) => this.manipulaErros(erro))
  }

  atualiza() {
    this.reservaLivroService.update(this.reservaLivroForm.controls.id.value, this.reservaLivroForm.value).subscribe(
      res => {
        this.alerts.push({
          type: 'success',
          message: 'Cadastro atualizado com Sucesso!',
        })
        this.reservaLivroService.getAll().subscribe((data: ReservaLivro[]) => {
          console.log(data);
          this.reservasLivros = data;
        })
        this.reservaLivroForm = this.fb.group({
          usuarioId: 0,
          livroId: 0,
          dataResgate: [''],
          id: 0
        })
      },
      (erro) => this.manipulaErros(erro))
  }

  changeLivro(e) {
    this.reservaLivroForm.controls.livroId.setValue(Number(e.target.value.substr(e.target.value.length - 1)))
  }
  changeUsuario(e) {
    this.reservaLivroForm.controls.usuarioId.setValue(Number(e.target.value.substr(e.target.value.length - 1)))
  }

  close(alert: Alert) {
    this.alerts.splice(this.alerts.indexOf(alert), 1);
  }
 
}
