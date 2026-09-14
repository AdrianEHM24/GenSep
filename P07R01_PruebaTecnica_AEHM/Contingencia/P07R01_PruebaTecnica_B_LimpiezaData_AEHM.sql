USE BIOMETRICO
GO

/*
P07R01_PruebaTecnica_AEHM
AUTOR: ADRIAN ELEUTERIO HERNANDEZ MARTINEZ
 FECHA: 07/09/2026
*/

--=============================
-- LIMPIEZA DE DATOS
--=============================
--COMMIT Y ROLLBACK
BEGIN TRANSACTION
	BEGIN TRY
		--VALIDACIONES
		IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tblturnoTrabajo'
			AND TABLE_SCHEMA = 'dbo')
			BEGIN
				--ELIMINAR: Datos de tblturnoTrabajo
				DELETE FROM dbo.tblturnoTrabajo;
				PRINT 'Datos de la tabla tblturnoTrabajo eliminados corretamente.';
			END
		ELSE
			BEGIN
				PRINT 'La tabla [dbo].[tblturnoTrabajo] no existe.'
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
		IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tblnivelEducativo'
			AND TABLE_SCHEMA = 'dbo')
			BEGIN
				--ELIMINAR: Datos de tblnivelEducativo
				DELETE FROM dbo.tblnivelEducativo;
				PRINT 'Datos de la tabla tblnivelEducativo eliminados corretamente.';
			END
		ELSE
			BEGIN
				PRINT 'La tabla [dbo].[tblnivelEducativo] no existe.'
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
		IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tblColaboradores'
			AND TABLE_SCHEMA = 'dbo')
			BEGIN
				--ELIMINAR: Datos de tblColaboradores
				DELETE FROM dbo.tblColaboradores;
				PRINT 'Datos de la tabla tblColaboradores eliminados corretamente.';
			END
		ELSE
			BEGIN
				PRINT 'La tabla [dbo].[tblColaboradores] no existe.'
			END
		COMMIT TRANSACTION; --CONFIRMAR CAMBIOS
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION
		THROW;
	END CATCH
GO
