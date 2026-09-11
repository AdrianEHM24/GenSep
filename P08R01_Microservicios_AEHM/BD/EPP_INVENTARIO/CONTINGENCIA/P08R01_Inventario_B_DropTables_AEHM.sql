/*
P08R01_MICROSERVICIOS_AEHM
AUTOR: ADRIAN ELEUTERIO HERNANDEZ MARTINEZ
 FECHA: 08/09/2026
*/

USE EPP_Inventario;
GO

--===================
	--DROP TABLES
--===================

--COMMIT ROLLBACK
BEGIN TRANSACTION
	BEGIN TRY
		--VALIDACIONES - ELIMINAR EN ORDEN INVERSO DE DEPENDENCIAS
		--TABLA: Categorias
		IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Categorias'
			AND TABLE_SCHEMA = 'dbo')
			BEGIN
				DROP TABLE Categorias;
				PRINT 'Tabla Categorias eliminada correctamente'
			END
		ELSE 
			BEGIN
				PRINT 'La tabla Categorias no existe'
			END
		--TABLA: Productos (tiene FK a Categorias)
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
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION
		THROW;
	END CATCH
GO