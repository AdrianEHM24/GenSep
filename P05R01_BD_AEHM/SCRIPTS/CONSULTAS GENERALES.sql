USE GenSep
GO
/*05
 P05R01_BD_AEHM
 AUTOR: ADRIAN ELEUTERIO HERNANDEZ MARTINEZ
 FECHA: 03/09/2026
*/

--=============================
-- CONSULTAS GENERALES
--=============================
SELECT * FROM Productos
SELECT * FROM Clientes
SELECT * FROM Pedidos
SELECT * FROM DetallesPedido
SELECT * FROM AuditoriaProductos

--UPDATE 
--SELECT * FROM 
Productos
SET Nombre = 'Concha', Categoria = 'Panaderia', Precio = 20, Stock = 50
WHERE ProductoID = 5
GO

--UPDATE 
--SELECT * FROM 
Pedidos
SET Estado = 'Pagado'
WHERE PedidoID = 1
GO

--EJECUTAR VISTA
SELECT *
FROM VWVistaResumenVentas;

--BUSCAR UN CLIENTE ESPECÍFICO POR NOMBRE
SELECT *
FROM VWVistaResumenVentas
WHERE Cliente = 'Juan Pérez';

--    =======================
--    INNER JOIN
--    Obtener todos los pedidos del cliente
--    =======================
 SELECT
 c.Nombre AS Cliente,
 COUNT(p.pedidoID) AS TotalPedidos,
 ISNULL(SUM(p.Total),0) AS TotalGastado
 FROM Clientes c
 INNER JOIN Pedidos AS p
 ON c.ClienteID = p.ClienteID
 GROUP BY c.ClienteID, c.Nombre;

--    =======================
--    Left JOIN
--    Obtener todos los pedidos del cliente
--    =======================
 SELECT
 c.Nombre AS Cliente,
 COUNT(p.pedidoID) AS TotalPedidos,
 ISNULL(SUM(p.Total),0) AS TotalGastado
 FROM Clientes c
 LEFT JOIN Pedidos AS p
 ON c.ClienteID = p.ClienteID
 GROUP BY c.ClienteID, c.Nombre;

 --Ejecutar el spObtenerClientePorID:
 EXEC spObtenerClientePorID '1';

 --Ejecutar el spInsertarPedido:
DECLARE @NuevoID INT;

EXEC spInsertarPedido @NuevoPedidoID = @NuevoID OUTPUT;

SELECT @NuevoID AS PedidoGenerado;


--Ejecutar el spConsultarContenidoTablas:
 EXEC dbo.spConsultarContenidoTablas;
GO

 --Para sacar el diccionario de datos
 --HELP_TABLE Productos
USE GenSep;
GO
EXEC sp_help 'dbo.Productos';
EXEC sp_help 'dbo.Clientes';
EXEC sp_help 'dbo.Pedidos';
EXEC sp_help 'dbo.DetallesPedido';
EXEC sp_help 'dbo.AuditoriaProductos';
GO