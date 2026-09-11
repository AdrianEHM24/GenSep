USE EPP_Movimientos
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
		IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Empleados'
			AND TABLE_SCHEMA = 'dbo')
			BEGIN
				--ELIMINAR: Datos de Empleados
				DELETE FROM dbo.Empleados;
				PRINT 'Datos de la tabla Empleados eliminados corretamente.';
			END
		ELSE
			BEGIN
				PRINT 'La tabla [dbo].[Empleados] no existe.'
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
		IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Movimientos'
			AND TABLE_SCHEMA = 'dbo')
			BEGIN
				--ELIMINAR: Datos de Movimientos
				DELETE FROM dbo.Movimientos;
				PRINT 'Datos de la tabla Movimientos eliminados corretamente.';
			END
		ELSE
			BEGIN
				PRINT 'La tabla [dbo].[Movimientos] no existe.'
			END
		COMMIT TRANSACTION; --CONFIRMAR CAMBIOS
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION
		THROW;
	END CATCH
GO