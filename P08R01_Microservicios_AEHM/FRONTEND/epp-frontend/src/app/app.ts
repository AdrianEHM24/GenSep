import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { ProductosComponent } from "./components/productos/productos";
import { MovimientosComponent } from "./components/movimientos/movimientos";
import { Dashboard } from './components/dashboard/dashboard';

@Component({
  imports: [RouterOutlet, ProductosComponent, MovimientosComponent, Dashboard],
  selector: 'app-root',
  styleUrl: './app.css',
  templateUrl: './app.html',
})
export class App {
  protected readonly title = signal('epp-frontend');
}
