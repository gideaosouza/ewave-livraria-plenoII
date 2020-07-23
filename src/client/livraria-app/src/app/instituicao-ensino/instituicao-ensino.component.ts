import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { ErrosLivro } from '../model/erros/livro.response.erro';
import { Alert } from '../model/ui/alert';
import { InstituicaoEnsino } from '../model/instituicao-ensino';
import { InstituicaoEnsinoService } from '../services/instituicao-ensino.service';

@Component({
  selector: 'app-instituicao-ensino',
  templateUrl: './instituicao-ensino.component.html',
  styleUrls: ['./instituicao-ensino.component.css']
})

export class InstituicaoEnsinoComponent implements OnInit {
  instituicoesEnsino: InstituicaoEnsino[] = [];
  instituicaoEnsinoForm: FormGroup;
  alerts: Alert[];

  constructor(public instituicaoEnsinoService: InstituicaoEnsinoService, public fb: FormBuilder) { }

  ngOnInit(): void {
    this.instituicaoEnsinoForm = this.fb.group({
      nome: [''],
      endereco: [''],
      cpnj: [''],
      telefone: [''],
      id: 0
    })

    this.instituicaoEnsinoService.getAll().subscribe((data: InstituicaoEnsino[]) => {
      console.log(data);
      this.instituicoesEnsino = data;
    })

    this.alerts = [];
  }

  desabilitar(id: number) {
    this.instituicaoEnsinoService.desabilitar(id).subscribe(
      res => {
        this.alerts.push({
          type: 'success',
          message: 'Cadastro desabilitado com Sucesso!',
        })
        this.instituicaoEnsinoService.getAll().subscribe((data: InstituicaoEnsino[]) => {
          console.log(data);
          this.instituicoesEnsino = data;
        })
        this.instituicaoEnsinoForm = this.fb.group({
          nome: [''],
          endereco: [''],
          cpnj: [''],
          telefone: [''],
          id: 0
        })
      },
      (erro) => this.manipulaErros(erro))
  }
  update(id: number) {
    let obj = this.instituicoesEnsino.find(c => c.id == id)

    this.instituicaoEnsinoForm.setValue({
      nome: obj.nome,
      endereco: obj.endereco,
      cpnj: obj.cpnj,
      telefone: obj.telefone,
      id: id
    })
  }
  submitForm() {

        if (this.instituicaoEnsinoForm.controls.id.value == 0)
          this.adiciona()
        else
          this.atualiza();
  }

  manipulaErros(erro) {
    let errorValidation = erro as ErrosLivro

    errorValidation.errors?.Capa?.forEach(element => {
      this.alerts.push({
        type: 'danger',
        message: 'Capa: ' + element,
      })
    })
    errorValidation.errors?.Autor?.forEach(element => {
      this.alerts.push({
        type: 'danger',
        message: 'Autor: ' + element,
      })
    })
    errorValidation.errors?.Genero?.forEach(element => {
      this.alerts.push({
        type: 'danger',
        message: 'Genero: ' + element,
      })
    })

    errorValidation.errors?.Titulo?.forEach(element => {
      this.alerts.push({
        type: 'danger',
        message: 'Titulo: ' + element
      })
    })

  }

  adiciona() {
    this.instituicaoEnsinoService.create(this.instituicaoEnsinoForm.value).subscribe(
      res => {
        this.alerts.push({
          type: 'success',
          message: 'Cadastro efetuado com Sucesso!',
        })
        this.instituicaoEnsinoService.getAll().subscribe((data: InstituicaoEnsino[]) => {
          console.log(data);
          this.instituicoesEnsino = data;
        })
        this.instituicaoEnsinoForm = this.fb.group({
          nome: [''],
          endereco: [''],
          cpnj: [''],
          telefone: [''],
          id: 0
        })
      },
      (erro) => this.manipulaErros(erro))
  }

  atualiza() {
    this.instituicaoEnsinoService.update(this.instituicaoEnsinoForm.controls.id.value, this.instituicaoEnsinoForm.value).subscribe(
      res => {
        this.alerts.push({
          type: 'success',
          message: 'Cadastro atualizado com Sucesso!',
        })
        this.instituicaoEnsinoService.getAll().subscribe((data: InstituicaoEnsino[]) => {
          console.log(data);
          this.instituicoesEnsino = data;
        })
        this.instituicaoEnsinoForm = this.fb.group({
          nome: [''],
          endereco: [''],
          cpnj: [''],
          telefone: [''],
          id: 0
        })
      },
      (erro) => this.manipulaErros(erro))
  }
  close(alert: Alert) {
    this.alerts.splice(this.alerts.indexOf(alert), 1);
  }
}
