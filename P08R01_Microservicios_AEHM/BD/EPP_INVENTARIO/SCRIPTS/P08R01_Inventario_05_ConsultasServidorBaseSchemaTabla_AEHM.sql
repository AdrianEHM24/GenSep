USE EPP_Inventario
GO

SELECT @@SERVERNAME

SELECT p.[Codigo], p.[Nombre], c.[Nombre] AS Categoria, P.[StockActual] AS Stock, p.[StockMinimo] AS Minimo, p.[Precio]
FROM [LAPTOP-O56R5GG9].[EPP_Inventario].[dbo].[Categorias] AS c
INNER JOIN [LAPTOP-O56R5GG9].[EPP_Inventario].[dbo].[Productos] AS p
ON c.CategoriaId = p.CategoriaId
GO

SELECT m.[TipoMovimiento], m.[ProductoNombre], e.[Nombre] AS Empleado, m.Cantidad, m.Motivo
FROM [LAPTOP-O56R5GG9].[EPP_Movimientos].[dbo].[Movimientos] AS m
INNER JOIN [LAPTOP-O56R5GG9].[EPP_Movimientos].[dbo].[Empleados] AS e
ON m.EmpleadoId = e.EmpleadoId
GO

