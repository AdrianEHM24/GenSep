/*
P08R01_MICROSERVICIOS_AEHM
AUTOR: ADRIAN ELEUTERIO HERNANDEZ MARTINEZ
 FECHA: 08/09/2026
*/

USE EPP_Inventario
GO

--===================
	--CARGA INICIAL
--===================

INSERT INTO Categorias (Nombre, Descripcion) VALUES
	('Cabeza', 'Equipos de proteccion para cabeza'),
	('Manos', 'Guantes y protectores de manos'),
	('Cuerpo', 'Overoles, chalecos y ropa de trabajo'),
	('Visual', 'Lentes y proteccion para ojos'),
	('Pies', 'Botas y calzado de seguridad');
GO

INSERT INTO Productos (CategoriaId, Codigo, Nombre, Marca, Talla, StockActual, StockMinimo, Precio) VALUES
	(1, 'CASC-001', 'Casco Industrial Blanco', 'MSA', 'Unica', 50, 10, 185.00),
	(1, 'CASC-002', 'Casco Industrial Amarillo', 'Truper', 'Unica', 40, 10, 145.00),
	(2, 'GUAN-001', 'Guantes de Cuero Resistente', 'Ansell', 'L', 30, 15, 95.00),
	(2, 'GUAN-002', 'Guantes de Nitrilo Negro', 'Showa', 'M', 60, 20, 45.00),
	(3, 'OVER-001', 'Overol Naranja Talla M', 'Dupont', 'M', 25, 5, 350.00),
	(3, 'OVER-002', 'Chaleco Reflectante',		'3M',	'L',	80, 15, 120.00),
	(4, 'LENT-001', 'Lentes de Seguridad Claros', '3M', 'Unica', 100, 25, 55.00),
	(4, 'LENT-002', 'Careta Facial Completa', 'Uvex', 'Unica', 15, 5, 280.00),
	(5, 'BOOT-001', 'Botas Dielectricas Talla 27', 'Bata', '27', 20, 8, 950.00),
	(5, 'BOOT-002', 'Botas Punta Acero Talla 28', 'Bata', '28', 18, 8, 1100.00);
GO