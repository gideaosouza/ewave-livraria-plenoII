import { Injectable } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';

@Injectable({
    providedIn: 'root'
})
export class FileService {

    ///O Diretório que será será gerado na raiz de execução do programa
    private directoryBase = "assets//upload//capa//";

    constructor(private sanitizer: DomSanitizer) { }
    getCapa(fileName){
       return  this.directoryBase + fileName;
    }
}