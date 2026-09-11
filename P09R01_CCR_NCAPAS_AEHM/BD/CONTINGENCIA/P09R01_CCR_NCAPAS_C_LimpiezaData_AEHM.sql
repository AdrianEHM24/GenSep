/*
 P09R01_CCR_NCAPAS_AEHM
 AUTOR: ADRIAN ELEUTERIO HERNANDEZ MARTINEZ
 FECHA: 09/09/2026
*/

USE GenSepCCR;
GO
--=============================
-- LIMPIEZA DATA
--=============================
--COMMIT Y ROLLBACK
BEGIN TRANSACTION
	BEGIN TRY
		--VALIDACIONES
		IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Rutas'
			AND TABLE_SCHEMA = 'dbo')
			BEGIN
				--ELIMINAR: Datos de Rutas
				DELETE FROM dbo.Rutas;
				PRINT 'Datos de la tabla Rutas eliminados corretamente.';
			END
		ELSE
			BEGIN
				PRINT 'La tabla [dbo].[Rutas] no existe.'
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
		IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Camiones'
			AND TABLE_SCHEMA = 'dbo')
			BEGIN
				--ELIMINAR: Datos de Camiones
				DELETE FROM dbo.Camiones;
				PRINT 'Datos de la tabla Camiones eliminados corretamente.';
			END
		ELSE
			BEGIN
				PRINT 'La tabla [dbo].[Camiones] no existe.'
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
		IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Choferes'
			AND TABLE_SCHEMA = 'dbo')
			BEGIN
				--ELIMINAR: Datos de Choferes
				DELETE FROM dbo.Choferes;
				PRINT 'Datos de la tabla Choferes eliminados corretamente.';
			END
		ELSE
			BEGIN
				PRINT 'La tabla [dbo].[Choferes] no existe.'
			END
		COMMIT TRANSACTION; --CONFIRMAR CAMBIOS
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION
		THROW;
	END CATCH
GO