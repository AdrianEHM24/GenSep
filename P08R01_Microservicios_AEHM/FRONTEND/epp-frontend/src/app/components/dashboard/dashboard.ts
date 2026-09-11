import { Component, OnInit } from '@angular/core';
import { CommonModule } from "@angular/common";
import { MovimientosComponent } from "../movimientos/movimientos";
import { ProductosComponent } from "../productos/productos";
@Component({
  standalone: true,
  imports: [CommonModule, MovimientosComponent, ProductosComponent],
  selector: 'app-dashboard',
  styleUrl: './dashboard.css',
  templateUrl: './dashboard.html',
  
})
export class Dashboard {}
