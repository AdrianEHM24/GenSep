USE TURISMO
GO

/*
 P01R01_APIViajes_Saurio_AEHM
 AUTOR: ADRIAN ELEUTERIO HERNANDEZ MARTINEZ
 FECHA: 04/09/2026
*/

--=============================
-- CONTINGENCIA DE SP'S
--=============================
--COMMIT Y ROLLBACK
BEGIN TRANSACTION
	BEGIN TRY
		--VALIDACIONES
		IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_NAME = 'spDestino'
			AND ROUTINE_SCHEMA = 'dbo')
			BEGIN
				--Eliminar: procedimiento spAlumno
				DROP PROCEDURE dbo.spDestino;
				PRINT 'Procedimiento spDestino eliminado correctamente.';
			END
		ELSE
			BEGIN
				PRINT 'El procedimiento [dbo][spDestino] no existe.'
			END
		COMMIT TRANSACTION; --Confirmar cambios
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;
		THROW;
	END CATCH
GO