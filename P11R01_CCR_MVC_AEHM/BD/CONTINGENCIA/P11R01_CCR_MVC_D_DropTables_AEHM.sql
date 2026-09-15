/*
 P09R01_CCR_NCAPAS_AEHM
 AUTOR: ADRIAN ELEUTERIO HERNANDEZ MARTINEZ
 FECHA: 09/09/2026
*/

USE GenSepCCR;
GO

--=============================
-- ELIMINAR TABLAS
--=============================

--COMMIT ROLLBACK
BEGIN TRANSACTION
	BEGIN TRY
		--VALIDACIONES - ELIMINAR EN ORDEN INVERSO DE DEPENDENCIAS
		--TABLA: Rutas
		IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Rutas'
			AND TABLE_SCHEMA = 'dbo')
			BEGIN
				DROP TABLE Rutas;
				PRINT 'Tabla Rutas eliminada correctamente'
			END
		ELSE 
			BEGIN
				PRINT 'La tabla Rutas no existe'
			END
		--TABLA: Choferes
		IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Choferes'
			AND TABLE_SCHEMA = 'dbo')
			BEGIN
				DROP TABLE Choferes;
				PRINT 'Tabla Choferes eliminada correctamente'
			END
		ELSE 
			BEGIN
				PRINT 'La tabla Choferes no existe'
			END
		--TABLA: Camiones 
		IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Camiones'
			AND TABLE_SCHEMA = 'dbo')
			BEGIN
				DROP TABLE Camiones;
				PRINT 'Tabla Camiones eliminada correctamente'
			END
		ELSE
			BEGIN
				PRINT 'La tabla Camiones no existe'
			END
		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION
		THROW;
	END CATCH
GO