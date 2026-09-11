// import { Service } from '@angular/core';


// @Service()
// export class Inventario {}

// import { Injectable } from "@angular/core";
// import { HttpClient } from "@angular/common/http";
// import { Observable } from "rxjs";
// import { Producto } from "../models/producto";
// import { environment } from "../../environments/environment";

// @Injectable({providedIn: 'root'})
// export class Inventario{
//     private url = environment.apiInventario;

//     constructor(private http: HttpClient){}

//     getProductos(): Observable<Producto[]>{
//         return this.http.get<Producto[]>(`${this.url}/productos`);
//     }
//     getProducto(id: number): Observable<Producto>{
//         return this.http.get<Producto>(`${this.url}/productos/${id}`);
//     }
//     crearProducto(producto: Producto): Observable<Producto>{
//         return this.http.post<Producto>(`${this.url}/productos`, producto);
//     }
// }

//import { Service } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';
import { Producto } from '../models/producto';
import { environment } from '../../environments/environment.development';
import { Injectable } from '@angular/core'; 
import { throwError } from 'rxjs'; 

/*@Service()*/
@Injectable({providedIn: 'root'})
export class Inventario {
    private url = environment.apiInventario;


    // Headers comunes para JSON
    private httpOptions = {
        headers: new HttpHeaders({
            'Content-Type': 'application/json'
        })
    };

    constructor(private http: HttpClient){}

    getProductos(): Observable<Producto[]>{
        return this.http.get<Producto[]>(`${this.url}/productos`).pipe(
                catchError((error: HttpErrorResponse) => {
                    console.error('Error:', error);
                    return throwError(() => new Error('Error al obtener productos'));
                })
            );
    }

    getProducto(id: number): Observable<Producto> {
        return this.http.get<Producto>(`${this.url}/productos/${id}`);
    }

    crearProducto(producto: Producto): Observable<Producto>{
        return this.http.post<Producto>(`${this.url}/productos`, producto);
    }
}