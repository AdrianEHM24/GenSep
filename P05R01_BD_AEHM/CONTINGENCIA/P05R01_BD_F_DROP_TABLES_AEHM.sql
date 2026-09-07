USE GenSep
GO

/*05
 P05R01_BD_AEHM
 AUTOR: ADRIAN ELEUTERIO HERNANDEZ MARTINEZ
 FECHA: 03/09/2026
*/

--=============================
-- ELIMINAR TABLAS
--=============================
--COMMIT ROLLBACK
BEGIN TRANSACTION
	BEGIN TRY
		--VALIDACIONES - ELIMINAR EN ORDEN INVERSO DE DEPENDENCIAS
		--TABLA: AuditoriaProductos
		IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AuditoriaProductos'
			AND TABLE_SCHEMA = 'dbo')
			BEGIN
				DROP TABLE AuditoriaProductos;
				PRINT 'Tabla AuditoriaProductos eliminada correctamente'
			END
		ELSE 
			BEGIN
				PRINT 'La tabla AuditoriaProductos no existe'
			END
		--TABLA: DetallesPedido (tiene FK a Pedidos y Productos)
		IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'DetallesPedido'
			AND TABLE_SCHEMA = 'dbo')
			BEGIN
				DROP TABLE DetallesPedido;
				PRINT 'Tabla DetallesPedido eliminada correctamente'
			END
		ELSE 
			BEGIN
				PRINT 'La tabla DetallesPedido no existe'
			END
		--TABLA: Pedidos (tiene FK a Clientes)
		IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Pedidos'
			AND TABLE_SCHEMA = 'dbo')
			BEGIN
				DROP TABLE Pedidos;
				PRINT 'Tabla Pedidos eliminada correctamente'
			END
		ELSE
			BEGIN
				PRINT 'La tabla Pedidos no existe'
			END
		--TABLA: Clientes
		IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Clientes'
			AND TABLE_SCHEMA = 'dbo')
			BEGIN
				DROP TABLE Clientes;
				PRINT 'Tabla Clientes eliminada correctamente'
			END
		ELSE
			BEGIN
				PRINT 'La tabla Clientes no existe'
			END
		
		--TABLA: Productos
		IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Productos'
			AND TABLE_SCHEMA = 'dbo')
			BEGIN
				DROP TABLE Productos;
				PRINT 'Tabla Productos eliminada correctamente'
			END
		ELSE
			BEGIN
				PRINT 'La tabla Productos no existe'
			END
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION
		THROW;
	END CATCH
GO