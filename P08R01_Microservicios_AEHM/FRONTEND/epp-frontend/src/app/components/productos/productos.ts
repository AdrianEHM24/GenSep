// import { Component } from '@angular/core';

// @Component({
//   imports: [],
//   selector: 'app-productos',
//   styleUrl: './productos.css',
//   templateUrl: './productos.html',
// })
// export class Productos {}

import { Component, OnInit } from "@angular/core";
import { CommonModule } from "@angular/common";
import { Producto } from "../../models/producto";
import { Inventario } from "../../services/inventario";

@Component({
  selector: 'app-productos',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './productos.html'
})

export class ProductosComponent implements OnInit{
  productos: Producto[] = [];
  loading = true;

  constructor(private inventarioSvc: Inventario){}

  ngOnInit(): void {
    this.inventarioSvc.getProductos().subscribe({
      next: (data) => {this.productos = data; this.loading = false;},
      error: (err) => {console.error(err); this.loading = false;}
    });
  }
}