import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { Alert } from '../model/ui/alert';
import { Usuario } from '../model/usuario';
import { UsuarioService } from '../services/usuario.service';
import { ErroUsuario } from '../model/erros/usuario.response.erro';
import { InstituicaoEnsinoService } from '../services/instituicao-ensino.service';
import { InstituicaoEnsino } from '../model/instituicao-ensino';

@Component({
  selector: 'app-usuario',
  templateUrl: './usuario.component.html',
  styleUrls: ['./usuario.component.css']
})

export class UsuarioComponent implements OnInit {
  usuarios: Usuario[] = [];
  instituicoes: InstituicaoEnsino[] = [];
  usuarioForm: FormGroup;
  alerts: Alert[];

  constructor(public usuarioService: UsuarioService, public fb: FormBuilder, public instituicaoService: InstituicaoEnsinoService) { }

  ngOnInit(): void {
    this.usuarioForm = this.fb.group({
      nome: [''],
      endereco: [''],
      cpf: [''],
      telefone: [''],
      email: [''],
      instituicaoEnsinoId: 0,
      id: 0
    })

    this.usuarioService.getAll().subscribe((data: Usuario[]) => {
      console.log(data);
      this.usuarios = data;
    })

    this.alerts = [];
    this.instituicaoService.getAll().subscribe((data: InstituicaoEnsino[]) => {
      this.instituicoes = data;
    })
  }

  desabilitar(id: number) {
    this.usuarioService.desabilitar(id).subscribe(
      res => {
        this.alerts.push({
          type: 'success',
          message: 'Cadastro desabilitado com Sucesso!',
        })
        this.usuarioService.getAll().subscribe((data: Usuario[]) => {
          console.log(data);
          this.usuarios = data;
        })
        this.usuarioForm = this.fb.group({
          nome: [''],
          endereco: [''],
          cpf: [''],
          telefone: [''],
          email: [''],
          instituicaoEnsinoId: 0,
          id: 0
        })
      },
      (erro) => this.manipulaErros(erro))
  }
  update(id: number) {
    let obj = this.usuarios.find(c => c.id == id)

    this.usuarioForm.setValue({
      nome: obj.nome,
      endereco: obj.endereco,
      cpf: obj.cpf,
      telefone: obj.telefone,
      email: obj.email,
      instituicaoEnsinoId: obj.instituicaoEnsinoId,
      id: id
    })
  }
  submitForm() {

    if (this.usuarioForm.controls.id.value == 0)
      this.adiciona()
    else
      this.atualiza();
  }

  manipulaErros(erro) {
    let errorValidation = erro as ErroUsuario

    errorValidation.errors?.CPF?.forEach(element => {
      this.alerts.push({
        type: 'danger',
        message: 'CPF: ' + element,
      })
    })
    errorValidation.errors?.Email?.forEach(element => {
      this.alerts.push({
        type: 'danger',
        message: 'Email: ' + element,
      })
    })
    errorValidation.errors?.Nome?.forEach(element => {
      this.alerts.push({
        type: 'danger',
        message: 'Nome: ' + element,
      })
    })

    errorValidation.errors?.Telefone?.forEach(element => {
      this.alerts.push({
        type: 'danger',
        message: 'Telefone: ' + element
      })
    })
  }

  adiciona() {
    this.usuarioService.create(this.usuarioForm.value).subscribe(
      res => {
        this.alerts.push({
          type: 'success',
          message: 'Cadastro efetuado com Sucesso!',
        })
        this.usuarioService.getAll().subscribe((data: Usuario[]) => {
          console.log(data);
          this.usuarios = data;
        })
        this.usuarioForm = this.fb.group({
          nome: [''],
          endereco: [''],
          cpf: [''],
          telefone: [''],
          email: [''],
          instituicaoEnsinoId: 0,
          id: 0
        })
      },
      (erro) => this.manipulaErros(erro))
  }

  atualiza() {
    this.usuarioService.update(this.usuarioForm.controls.id.value, this.usuarioForm.value).subscribe(
      res => {
        this.alerts.push({
          type: 'success',
          message: 'Cadastro atualizado com Sucesso!',
        })
        this.usuarioService.getAll().subscribe((data: Usuario[]) => {
          console.log(data);
          this.usuarios = data;
        })
        this.usuarioForm = this.fb.group({
          nome: [''],
          endereco: [''],
          cpf: [''],
          telefone: [''],
          email: [''],
          instituicaoEnsinoId: 0,
          id: 0
        })
      },
      (erro) => this.manipulaErros(erro))
  }

  changeInstituicao(e) {
    this.usuarioForm.controls.instituicaoEnsinoId.setValue(e.target.value, {
      onlySelf: true
    })
  }

  close(alert: Alert) {
    this.alerts.splice(this.alerts.indexOf(alert), 1);
  }
}
