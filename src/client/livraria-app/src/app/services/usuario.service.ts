import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Usuario } from '../model/usuario';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable({
    providedIn: 'root'
})
export class UsuarioService {

    private apiServer = "https://localhost:44322/api";

    constructor(private httpClient: HttpClient) { }
    httpOptions = {
        headers: new HttpHeaders({
            'Content-Type': 'application/json'
        })
    }
    
    desabilitar(id): Observable<void> {
        return this.httpClient.get<void>(this.apiServer + '/usuario/Desabilitar/' + id)
        .pipe(
            catchError(this.errorHandler)
        )
    }

        
    habilitar(id): Observable<void> {
        return this.httpClient.get<void>(this.apiServer + '/usuario/Habilitar/' + id, this.httpOptions)
            .pipe(
                catchError(this.errorHandler)
            )
    }

    create(usuario): Observable<Usuario> {
        return this.httpClient.post<Usuario>(this.apiServer + '/usuario/', JSON.stringify(usuario), this.httpOptions)
            .pipe(
                catchError(this.errorHandler)
            )
    }
    getById(id): Observable<Usuario> {
        return this.httpClient.get<Usuario>(this.apiServer + '/usuario/' + id)
            .pipe(
                catchError(this.errorHandler)
            )
    }

    getAll(): Observable<Usuario[]> {
        return this.httpClient.get<Usuario[]>(this.apiServer + '/usuario/')
            .pipe(
                catchError(this.errorHandler)
            )
    }

    update(id, usuario): Observable<Usuario> {
        return this.httpClient.put<Usuario>(this.apiServer + '/usuario/' + id, JSON.stringify(usuario), this.httpOptions)
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