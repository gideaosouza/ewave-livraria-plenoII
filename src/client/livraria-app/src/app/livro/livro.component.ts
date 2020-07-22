import { Component, OnInit } from '@angular/core';
import { Livro } from '../model/livro';
import { LivroService } from '../services/livro.service';
import { FileService } from '../services/file.service';
import { FormGroup, FormBuilder } from '@angular/forms';
import { ErrosLivro } from '../model/erro.response';

interface Alert {
  type: string;
  message: string;
}
const Erros: Alert[] = [];

@Component({
  selector: 'app-livro',
  templateUrl: './livro.component.html',
  styleUrls: ['./livro.component.css']
})

export class LivroComponent implements OnInit {
  livros: Livro[] = [];
  livroForm: FormGroup;
  alerts: Alert[];
  fileToUpload: File = null;

  constructor(public livroService: LivroService, public fileService: FileService, public fb: FormBuilder) { }

  ngOnInit(): void {
    this.livroForm = this.fb.group({
      id: 0,
      titulo: [''],
      genero: [''],
      autor: [''],
      sinopse: [''],
      capa: [''],
    })

    this.livroService.getAll().subscribe((data: Livro[]) => {
      console.log(data);
      this.livros = data;
    })

    this.alerts = Array.from(Erros);
  }

  desabilitar(id: number) {
    this.livroService.desabilitar(id).subscribe(
      res => {
        this.alerts.push({
          type: 'success',
          message: 'Cadastro desabilitado com Sucesso!',
        })
        this.livroService.getAll().subscribe((data: Livro[]) => {
          console.log(data);
          this.livros = data;
        })
        this.livroForm = this.fb.group({
          id: 0,
          titulo: [''],
          genero: [''],
          autor: [''],
          sinopse: [''],
          capa: [''],
        })
      },
      (erro) => this.manipulaErros(erro))
   }
  update(id: number) {
    let obj = this.livros.find(c => c.id == id)

    this.livroForm.setValue({
      id: obj.id,
      titulo: obj.titulo,
      genero: obj.genero,
      autor: obj.autor,
      sinopse: obj.sinopse,
      capa: obj.capa,
    })
  }
  handleFileInput(files: FileList) {
    this.fileToUpload = files.item(0);
  }

  submitForm() {
    if ((this.fileToUpload == null || this.fileToUpload == undefined) && this.livroForm.controls.capa.value == '') {
      this.alerts.push({
        type: 'danger',
        message: 'Uma capa é obrigatória!',
      })
      return;
    }else  if (this.fileToUpload != null) {

      this.fileService.postFile(this.fileToUpload).subscribe(data => {
        this.livroForm.controls.capa.setValue(data.path);
        if (this.livroForm.controls.id.value == 0)
          this.adiciona()
        else
          this.atualiza();

      }, error => {
        console.log(error);
      });
    } else {

      console.log('asdasd')
      if (this.livroForm.controls.id.value == 0)
        this.adiciona()
      else
        this.atualiza();
    }
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
    this.livroService.create(this.livroForm.value).subscribe(
      res => {
        this.alerts.push({
          type: 'success',
          message: 'Cadastro efetuado com Sucesso!',
        })
        this.livroService.getAll().subscribe((data: Livro[]) => {
          console.log(data);
          this.livros = data;
        })
        this.livroForm = this.fb.group({
          id: 0,
          titulo: [''],
          genero: [''],
          autor: [''],
          sinopse: [''],
          capa: [''],
        })
      },
      (erro) => this.manipulaErros(erro))
  }

  atualiza() {
    this.livroService.update(this.livroForm.controls.id.value, this.livroForm.value).subscribe(
      res => {
        this.alerts.push({
          type: 'success',
          message: 'Cadastro atualizado com Sucesso!',
        })
        this.livroService.getAll().subscribe((data: Livro[]) => {
          console.log(data);
          this.livros = data;
        })
        this.livroForm = this.fb.group({
          id: 0,
          titulo: [''],
          genero: [''],
          autor: [''],
          sinopse: [''],
          capa: [''],
        })
      },
      (erro) => this.manipulaErros(erro))
  }
  close(alert: Alert) {
    this.alerts.splice(this.alerts.indexOf(alert), 1);
  }
}
