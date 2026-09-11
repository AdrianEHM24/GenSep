// import { Component } from '@angular/core';

// @Component({
//   imports: [],
//   selector: 'app-movimientos',
//   styleUrl: './movimientos.css',
//   templateUrl: './movimientos.html',
// })
// export class Movimientos {}

import { Component, OnInit } from "@angular/core";
import { CommonModule } from "@angular/common";
import { Movimiento } from "../../models/movimiento";
import { Movimientos } from "../../services/movimientos";

@Component({
  selector: 'app-movimientos',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './movimientos.html'
})

export class MovimientosComponent implements OnInit{
  movimientos: Movimiento[] = [];
  loading = true;

  constructor(private movimientoSvc: Movimientos){}

  ngOnInit(): void {
    this.movimientoSvc.getMovimientos().subscribe({
      next: (data) => {this.movimientos = data; this.loading = false;},
      error: (err) => {console.error(err); this.loading = false;}
    });
  }
}