USE EPP_Inventario
GO

/*
 P08R01_MICROSERVICIOS_AEHM
 AUTOR: ADRIAN ELEUTERIO HERNANDEZ MARTINEZ
 FECHA: 08/09/2026
*/

--=============================
-- LIMPIEZA DE DATA
--=============================
--TRUNCATE TABLE 
--GO

--COMMIT Y ROLLBACK
BEGIN TRANSACTION
	BEGIN TRY
		--VALIDACIONES
		IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Categorias'
			AND TABLE_SCHEMA = 'dbo')
			BEGIN
				--ELIMINAR: Datos de Categorias
				DELETE FROM dbo.Categorias;
				PRINT 'Datos de la tabla Categorias eliminados corretamente.';
			END
		ELSE
			BEGIN
				PRINT 'La tabla [dbo].[Categorias] no existe.'
			END
		COMMIT TRANSACTION; --CONFIRMAR CAMBIOS
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION
		THROW;
	END CATCH
GO

--COMMIT Y ROLLBACK
BEGIN TRANSACTION
	BEGIN TRY
		--VALIDACIONES
		IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Productos'
			AND TABLE_SCHEMA = 'dbo')
			BEGIN
				--ELIMINAR: Datos de Productos
				DELETE FROM dbo.Productos;
				PRINT 'Datos de la tabla Productos eliminados corretamente.';
			END
		ELSE
			BEGIN
				PRINT 'La tabla [dbo].[Productos] no existe.'
			END
		COMMIT TRANSACTION; --CONFIRMAR CAMBIOS
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION
		THROW;
	END CATCH
GO