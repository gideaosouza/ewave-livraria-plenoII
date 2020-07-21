import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Livro } from '../model/livro';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable({
    providedIn: 'root'
})
export class LivroService {

    private apiServer = "https://localhost:44322/api";

    constructor(private httpClient: HttpClient) { }
    httpOptions = {
        headers: new HttpHeaders({
            'Content-Type': 'application/json'
        })
    }

    create(product): Observable<Livro> {
        return this.httpClient.post<Livro>(this.apiServer + '/Livro/', JSON.stringify(product), this.httpOptions)
            .pipe(
                catchError(this.errorHandler)
            )
    }
    getById(id): Observable<Livro> {
        return this.httpClient.get<Livro>(this.apiServer + '/Livro/' + id)
            .pipe(
                catchError(this.errorHandler)
            )
    }

    getAll(): Observable<Livro[]> {
        return this.httpClient.get<Livro[]>(this.apiServer + '/Livro/')
            .pipe(
                catchError(this.errorHandler)
            )
    }

    update(id, product): Observable<Livro> {
        return this.httpClient.put<Livro>(this.apiServer + '/Livro/' + id, JSON.stringify(product), this.httpOptions)
            .pipe(
                catchError(this.errorHandler)
            )
    }

    delete(id) {
        return this.httpClient.delete<Livro>(this.apiServer + '/Livro/' + id, this.httpOptions)
            .pipe(
                catchError(this.errorHandler)
            )
    }
    errorHandler(error) {
        let errorMessage = '';
        if (error.error instanceof ErrorEvent) {
            // Get client-side error
            errorMessage = error.error.message;
        } else {
            // Get server-side error
            errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
        }
        console.log(errorMessage);
        return throwError(errorMessage);
    }
}