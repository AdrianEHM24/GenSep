USE BIOMETRICO
GO

/*
P07R01_PruebaTecnica_AEHM
AUTOR: ADRIAN ELEUTERIO HERNANDEZ MARTINEZ
 FECHA: 07/09/2026
*/

--=============================
-- ELIMINAR TABLAS
--=============================
--COMMIT ROLLBACK
BEGIN TRANSACTION
	BEGIN TRY
		--VALIDACIONES - ELIMINAR EN ORDEN INVERSO DE DEPENDENCIAS
		--TABLA: tblturnoTrabajo
		IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tblturnoTrabajo'
			AND TABLE_SCHEMA = 'dbo')
			BEGIN
				DROP TABLE tblturnoTrabajo;
				PRINT 'Tabla tblturnoTrabajo eliminada correctamente'
			END
		ELSE 
			BEGIN
				PRINT 'La tabla tblturnoTrabajo no existe'
			END
		--TABLA: tblnivelEducativo
		IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tblnivelEducativo'
			AND TABLE_SCHEMA = 'dbo')
			BEGIN
				DROP TABLE tblnivelEducativo;
				PRINT 'Tabla tblnivelEducativo eliminada correctamente'
			END
		ELSE 
			BEGIN
				PRINT 'La tabla tblnivelEducativo no existe'
			END
		--TABLA: tblColaboradores 
		IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tblColaboradores'
			AND TABLE_SCHEMA = 'dbo')
			BEGIN
				DROP TABLE tblColaboradores;
				PRINT 'Tabla tblColaboradores eliminada correctamente'
			END
		ELSE
			BEGIN
				PRINT 'La tabla tblColaboradores no existe'
			END
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION
		THROW;
	END CATCH
GO