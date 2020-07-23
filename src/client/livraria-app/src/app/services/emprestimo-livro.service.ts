import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { EmprestimoLivro } from '../model/emprestimo-livro';

@Injectable({
    providedIn: 'root'
})
export class EmprestimoLivroService {

    private apiServer = "https://localhost:44322/api";

    constructor(private httpClient: HttpClient) { }
    httpOptions = {
        headers: new HttpHeaders({
            'Content-Type': 'application/json'
        })
    }
    
    desabilitar(id): Observable<void> {
        return this.httpClient.get<void>(this.apiServer + '/emprestimo-livro/Desabilitar/' + id)
        .pipe(
            catchError(this.errorHandler)
        )
    }

        
    habilitar(id): Observable<void> {
        return this.httpClient.get<void>(this.apiServer + '/emprestimo-livro/Habilitar/' + id, this.httpOptions)
            .pipe(
                catchError(this.errorHandler)
            )
    }

    create(emprestimo): Observable<EmprestimoLivro> {
        return this.httpClient.post<EmprestimoLivro>(this.apiServer + '/emprestimo-livro/', JSON.stringify(emprestimo), this.httpOptions)
            .pipe(
                catchError(this.errorHandler)
            )
    }
    getById(id): Observable<EmprestimoLivro> {
        return this.httpClient.get<EmprestimoLivro>(this.apiServer + '/emprestimo-livro/' + id)
            .pipe(
                catchError(this.errorHandler)
            )
    }

    getAll(): Observable<EmprestimoLivro[]> {
        return this.httpClient.get<EmprestimoLivro[]>(this.apiServer + '/emprestimo-livro/')
            .pipe(
                catchError(this.errorHandler)
            )
    }
    getLivrosComPrazoExtrapolado(): Observable<EmprestimoLivro[]> {
        return this.httpClient.get<EmprestimoLivro[]>(this.apiServer + '/emprestimo-livro/livros-com-prazo-extrapolado')
            .pipe(
                catchError(this.errorHandler)
            )
    }    

    update(id, emprestimo): Observable<EmprestimoLivro> {
        console.log(emprestimo)
        return this.httpClient.put<EmprestimoLivro>(this.apiServer + '/emprestimo-livro/' + id, JSON.stringify(emprestimo), this.httpOptions)
            .pipe(
                catchError(this.errorHandler)
            )
    }
    errorHandler(error) {
        let errorMessage = '';
        if (error.error instanceof ErrorEvent) {
            errorMessage = error.error.message;
        }
        return throwError(error.error);
    }
}