// import { Service } from '@angular/core';

// @Service()
// export class Movimientos {}


import { Injectable } from "@angular/core";
import { HttpClient, HttpErrorResponse, HttpHeaders } from "@angular/common/http";
import { Observable } from "rxjs";
import { catchError, retry } from 'rxjs/operators';
import { Movimiento } from "../models/movimiento";
import { environment } from "../../environments/environment";
import { throwError } from 'rxjs'; 

@Injectable({providedIn: 'root'})
export class Movimientos{
    private url = environment.apiMovimientos;

    // Headers comunes para JSON
    private httpOptions = {
        headers: new HttpHeaders({
            'Content-Type': 'application/json'
        })
    };

    constructor(private http: HttpClient){}

    getMovimientos(): Observable<Movimiento[]>{
        return this.http.get<Movimiento[]>(`${this.url}/movimientos`).pipe(
                catchError((error: HttpErrorResponse) => {
                    console.error('Error:', error);
                    return throwError(() => new Error('Error al obtener movimientos'));
                    })
                );
    }

    registrarMovimiento(mov: Movimiento): Observable<Movimiento>{
        return this.http.post<Movimiento>(`${this.url}/movimientos`, mov);
    }
}