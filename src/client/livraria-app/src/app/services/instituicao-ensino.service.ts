import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { InstituicaoEnsino } from '../model/instituicao-ensino';

@Injectable({
    providedIn: 'root'
})
export class InstituicaoEnsinoService {

    private apiServer = "https://localhost:44322/api";

    constructor(private httpClient: HttpClient) { }
    httpOptions = {
        headers: new HttpHeaders({
            'Content-Type': 'application/json'
        })
    }
    
    desabilitar(id): Observable<void> {
        return this.httpClient.get<void>(this.apiServer + '/instituicao-ensino/Desabilitar/' + id)
        .pipe(
            catchError(this.errorHandler)
        )
    }

        
    habilitar(id): Observable<void> {
        return this.httpClient.get<void>(this.apiServer + '/instituicao-ensino/Habilitar/' + id, this.httpOptions)
            .pipe(
                catchError(this.errorHandler)
            )
    }

    create(instituicao): Observable<InstituicaoEnsino> {
        return this.httpClient.post<InstituicaoEnsino>(this.apiServer + '/instituicao-ensino/', JSON.stringify(instituicao), this.httpOptions)
            .pipe(
                catchError(this.errorHandler)
            )
    }
    getById(id): Observable<InstituicaoEnsino> {
        return this.httpClient.get<InstituicaoEnsino>(this.apiServer + '/instituicao-ensino/' + id)
            .pipe(
                catchError(this.errorHandler)
            )
    }

    getAll(): Observable<InstituicaoEnsino[]> {
        return this.httpClient.get<InstituicaoEnsino[]>(this.apiServer + '/instituicao-ensino/')
            .pipe(
                catchError(this.errorHandler)
            )
    }

    update(id, instituicao): Observable<InstituicaoEnsino> {
        return this.httpClient.put<InstituicaoEnsino>(this.apiServer + '/instituicao-ensino/' + id, JSON.stringify(instituicao), this.httpOptions)
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