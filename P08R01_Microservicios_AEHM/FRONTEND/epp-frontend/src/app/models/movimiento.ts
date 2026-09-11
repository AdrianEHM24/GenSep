export class Movimiento {}

export interface Empleado{
    empleadoID?: number;
    numEmpleado: string;  //ENTRADA SALIDA
    nombre: string;
    apellidos: string;
    departamento?: string;
    puesto: string;
    activo?: boolean;
    fechaAlta?: string;
}

export interface Movimiento{
    movimientoId?: number;
    tipoMovimiento: string;  //ENTRADA SALIDA
    productoId: number;
    productoNombre: string;
    empleadoId?: number;
    cantidad: number;
    motivo?: string;
    fechaMovimiento?: string;
    registradoPor?: string;
    empleado?: Empleado;
}
