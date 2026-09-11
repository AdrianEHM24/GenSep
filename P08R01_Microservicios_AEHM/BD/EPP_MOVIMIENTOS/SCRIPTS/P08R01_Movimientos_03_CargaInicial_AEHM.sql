/*
P08R01_MICROSERVICIOS_AEHM
AUTOR: ADRIAN ELEUTERIO HERNANDEZ MARTINEZ
 FECHA: 08/09/2026
*/

USE EPP_Movimientos;
GO

--===================
	--CARGA INICIAL
--===================

INSERT INTO Empleados (NumEmpleado, Nombre, Apellidos, Departamento, Puesto) VALUES
	('EMP-001', 'Carlos',	'Hernandez Lopez', 'Produccion',	'Operador'),
	('EMP-002', 'Maria',	'Garcia Mendoza', 'Mantenimiento', 'Tecnico'),
	('EMP-003', 'Jose Luis', 'Ramirez Torres', 'Calidad',		'Inspector'),
	('EMP-004', 'Ana',		'Martinez Ruiz', 'Produccion',		'Supervisora');
GO

INSERT INTO Movimientos (TipoMovimiento, ProductoId, ProductoNombre, EmpleadoId, Cantidad, Motivo, RegistradoPor) VALUES
	('ENTRADA', 1, 'Casco Industrial Blanco',		NULL,	50, 'Compra Inicial Proveedor', 'Admin'),
	('SALIDA', 1, 'Casco Industrial Blanco',		1,		2, 'Asignacion Personal', 'Admin'),
	('SALIDA', 3, 'Guantes de Cuero Resistente',	2,		1, 'Dotacion Mensual', 'Admin'),
	('ENTRADA', 7, 'Lentes de Seguridad Claros',	NULL,	100, 'Reabastecimiento', 'Admin'),
	('SALIDA', 5, 'Overol Naranja Talla M',			3,		1, 'Ingreso a planta', 'Admin');
GO