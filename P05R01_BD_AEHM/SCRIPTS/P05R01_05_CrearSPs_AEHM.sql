USE GenSep
GO

/*05
 P05R01_BD_AEHM
 AUTOR: ADRIAN ELEUTERIO HERNANDEZ MARTINEZ
 FECHA: 03/09/2026
*/

--=============================
-- CREACIÓN DE SP'S
--=============================

CREATE OR ALTER PROCEDURE spObtenerClientePorID
	@clienteID INT
AS
BEGIN
	SELECT
		ClienteID,
		Nombre,
		Email,
		Telefono
	FROM Clientes
	WHERE ClienteID = @clienteID
END;
GO

CREATE OR ALTER PROCEDURE spInsertarPedido
	@ClienteID INT = 1,
	@Total DECIMAL(10,2) = 500,
	@Estado NVARCHAR(20)  = 'Pendiente',
	@NuevoPedidoID INT OUTPUT
AS
BEGIN
	INSERT INTO Pedidos (ClienteID, Total, Fecha, Estado)
	VALUES (@ClienteID, @Total, GETDATE(), @Estado);

	--Obtener el ID del pedido recién creado
	SET @NuevoPedidoID = SCOPE_IDENTITY();
	SELECT @NuevoPedidoID AS PedidoCreado;
END;
GO

CREATE OR ALTER PROCEDURE dbo.spConsultarContenidoTablas
AS
BEGIN
	SET NOCOUNT ON
	--Cada SELECT trae el contenido completo de una tabla; se muestran como resultsets separados
	SELECT * FROM dbo.Productos;
	SELECT * FROM dbo.Clientes;
	SELECT * FROM dbo.Pedidos;
	SELECT * FROM dbo.DetallesPedido;
	SELECT * FROM dbo.AuditoriaProductos;
END;
GO