import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { map } from 'rxjs/operators';
import { catchError } from 'rxjs/operators';
import { FileResponse } from '../model/file.response';

@Injectable({
    providedIn: 'root'
})
export class FileService {

    ///O Diretório que será será gerado na raiz de execução do programa
    private directoryBase = "assets//upload//capa//";
    private urlUploadCapa = "https://localhost:44322/api/Livro/UploadCapa";
    
    constructor(private httpClient: HttpClient) { }

    getCapa(fileName){
       return  this.directoryBase + fileName;
    }

    postFile(fileToUpload: File): Observable<FileResponse> {
        
        const formData: FormData = new FormData();
        formData.append('arquivo', fileToUpload, fileToUpload.name);
        return this.httpClient
          .post<FileResponse>(this.urlUploadCapa, formData)
          .pipe(
            catchError(this.errorHandler),
           );
    }
    
    errorHandler(error) {
        let errorMessage = '';
        if (error.error instanceof ErrorEvent) {
            errorMessage = error.error.message;
        }
        return throwError(error.error);
    }
}