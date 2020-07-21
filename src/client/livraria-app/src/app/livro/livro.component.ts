import { Component, OnInit } from '@angular/core';
import { Livro } from '../model/livro';
import { LivroService } from '../services/livro.service';
import { FileService } from '../services/file.service';
import { FormGroup, FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-livro',
  templateUrl: './livro.component.html',
  styleUrls: ['./livro.component.css']
})
export class LivroComponent implements OnInit {
  livros: Livro[] = [];
  livroForm: FormGroup;
  constructor(public livroService: LivroService, public fileService: FileService, public fb: FormBuilder) { }

  ngOnInit(): void {
    this.livroForm = this.fb.group({
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
  }

  desabilitar(id: number) { }
  update(id: number) {

    console.log(id)
  }

  submitForm() {
    console.log('Livro Criado!','Click dado',this.livroForm.value);
    this.livroService.create(this.livroForm.value).subscribe(res => {
      console.log('Livro Criado!',res);
    })
  }


}
