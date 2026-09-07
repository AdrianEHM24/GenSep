USE TURISMO
GO

/*
 P01R01_APIViajes_Saurio_AEHM
 AUTOR: ADRIAN ELEUTERIO HERNANDEZ MARTINEZ
 FECHA: 04/09/2026
*/

--=============================
-- LIMPIEZA DE DATA
--=============================

--COMMIT Y ROLLBACK
BEGIN TRANSACTION
	BEGIN TRY
		--VALIDACIONES
		IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tblDestino'
			AND TABLE_SCHEMA = 'dbo')
			BEGIN
				--ELIMINAR: Datos de tblDestino
				DELETE FROM dbo.tblDestino;
				PRINT 'Datos de la tabla tblDestino eliminados corretamente.';
			END
		ELSE
			BEGIN
				PRINT 'La tabla [dbo].[tblDestino] no existe.'
			END
		COMMIT TRANSACTION; --CONFIRMAR CAMBIOS
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION
		THROW;
	END CATCH
GO
