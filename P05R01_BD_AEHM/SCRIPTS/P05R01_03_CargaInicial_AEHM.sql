USE GenSep
GO

/*05
 P05R01_BD_AEHM
 AUTOR: ADRIAN ELEUTERIO HERNANDEZ MARTINEZ
 FECHA: 03/09/2026
*/

--=============================
-- CARGA INICIAL
--=============================
--INSERTAR DATOS DE EJEMPLO
INSERT INTO Productos(Nombre, Categoria, Precio, Stock)
VALUES
	--('Café Americano','Bebidas', 35.00, 100),
	--('Capuchino','Bebidas', 45.00, 100),
	--('Croissant','Panaderia', 25.00, 50)
	('Concha','Panaderia', 18.00, 50)
GO

--EJEMPLO DE INSERCIÓN
INSERT INTO Clientes(Nombre, Email, Telefono)
VALUES
	('Juan Pérez','jaun@email.com', '5551234567'),
	('Pamela','pamela@email.com', '9991234567')
GO

--EJEMPLO DE INSERCIÓN
INSERT INTO Pedidos(ClienteID, Fecha, Total, Estado)
VALUES
	(1 ,'2026-09-03', 25, ''),
	(2 ,'2026-09-03', 45, '')
GO

--EJEMPLO DE INSERCIÓN
INSERT INTO DetallesPedido(PedidoID, ProductoID, Cantidad, PrecioUnitario)
VALUES
	--(1 ,3, 1, 25),
	--(2 ,2, 2, 45)
	(2 ,2, 1, 45)
GO