/*
P08R01_MICROSERVICIOS_AEHM
AUTOR: ADRIAN ELEUTERIO HERNANDEZ MARTINEZ
 FECHA: 08/09/2026
*/

USE EPP_Movimientos;
GO

--===================
	--DROP TABLES
--===================

--COMMIT ROLLBACK
BEGIN TRANSACTION
	BEGIN TRY
		--VALIDACIONES - ELIMINAR EN ORDEN INVERSO DE DEPENDENCIAS
		--TABLA: Empleados
		IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Empleados'
			AND TABLE_SCHEMA = 'dbo')
			BEGIN
				DROP TABLE Empleados;
				PRINT 'Tabla Empleados eliminada correctamente'
			END
		ELSE 
			BEGIN
				PRINT 'La tabla Empleados no existe'
			END
		--TABLA: Movimientos (tiene FK a Empleados)
		IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Movimientos'
			AND TABLE_SCHEMA = 'dbo')
			BEGIN
				DROP TABLE Movimientos;
				PRINT 'Tabla Movimientos eliminada correctamente'
			END
		ELSE 
			BEGIN
				PRINT 'La tabla Movimientos no existe'
			END
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION
		THROW;
	END CATCH
GO