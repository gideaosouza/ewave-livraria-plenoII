import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { ReservaLivro } from '../model/reserva-livro';

@Injectable({
    providedIn: 'root'
})
export class ReservaLivroService {

    private apiServer = "https://localhost:44322/api";

    constructor(private httpClient: HttpClient) { }
    httpOptions = {
        headers: new HttpHeaders({
            'Content-Type': 'application/json'
        })
    }
    
    desabilitar(id): Observable<void> {
        return this.httpClient.get<void>(this.apiServer + '/reserva-livro/Desabilitar/' + id)
        .pipe(
            catchError(this.errorHandler)
        )
    }
        
    habilitar(id): Observable<void> {
        return this.httpClient.get<void>(this.apiServer + '/reserva-livro/Habilitar/' + id, this.httpOptions)
            .pipe(
                catchError(this.errorHandler)
            )
    }

    create(reserva): Observable<ReservaLivro> {
        return this.httpClient.post<ReservaLivro>(this.apiServer + '/reserva-livro/', JSON.stringify(reserva), this.httpOptions)
            .pipe(
                catchError(this.errorHandler)
            )
    }
    getById(id): Observable<ReservaLivro> {
        return this.httpClient.get<ReservaLivro>(this.apiServer + '/reserva-livro/' + id)
            .pipe(
                catchError(this.errorHandler)
            )
    }

    getAll(): Observable<ReservaLivro[]> {
        return this.httpClient.get<ReservaLivro[]>(this.apiServer + '/reserva-livro/')
            .pipe(
                catchError(this.errorHandler)
            )
    }     

    update(id, reserva): Observable<ReservaLivro> {
        return this.httpClient.put<ReservaLivro>(this.apiServer + '/reserva-livro/' + id, JSON.stringify(reserva), this.httpOptions)
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