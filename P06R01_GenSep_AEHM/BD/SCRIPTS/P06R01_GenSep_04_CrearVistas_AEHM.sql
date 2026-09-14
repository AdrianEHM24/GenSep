USE GenSep
GO

/*
 P06R01_GenSep_AEHM
 AUTOR: ADRIAN ELEUTERIO HERNANDEZ MARTINEZ
 FECHA: 07/09/2026
*/

--=============================
-- CREACIÓN DE VISTAS
--=============================

CREATE OR ALTER VIEW  VWVistaResumenVentas AS
SELECT
	c.ClienteID,
	c.Nombre AS Cliente,
	c.Email,
	COUNT (p.PedidoID) AS TotalPedidos,
	ISNULL(SUM(p.Total), 0) AS MontoTotal,
	MAX (p.Fecha) AS UltimaCompra
FROM Clientes AS c
LEFT JOIN Pedidos AS p
ON c.ClienteID = p.ClienteID
GROUP BY c.ClienteID, c.Nombre, c.Email
GO