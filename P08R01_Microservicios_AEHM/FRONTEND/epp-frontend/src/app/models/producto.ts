export class Producto {}

export interface Categoria{
    categoriaId: number;
    nombre: string;
}

export interface Producto{
    productoId: number;
    categoriaId: number;
    codigo: string;
    nombre: string;
    descripcion?: string;
    marca?: string;
    talla?: string;
    stockActual: number;
    stockMinimo: number;
    precio?: number;
    activo: boolean;
    categoria?: Categoria;
}