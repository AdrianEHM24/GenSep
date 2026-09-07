USE TURISMO
GO
/*
 P01R01_APIViajes_Saurio_AEHM
 AUTOR: ADRIAN ELEUTERIO HERNANDEZ MARTINEZ
 FECHA: 04/09/2026
*/

--=============================
-- CONTINGENCIA DE VISTAS
--=============================
--COMMIT Y ROLLBACK
BEGIN TRANSACTION
	BEGIN TRY
		--VALIDACIONES
		IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.VIEWS WHERE TABLE_NAME = 'vwDestinos'
			AND TABLE_SCHEMA = 'dbo')
			BEGIN
				--ELIMINAR: Vista vwDestinos
				DROP VIEW dbo.vwDestinos;
				PRINT 'Vista vwDestinos eliminada correctamente.';
			END
		ELSE
			BEGIN
				PRINT 'La vista [dbo][vwDestinos] no existe.'
			END
		COMMIT TRANSACTION --confirmar cambios
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;
		THROW
	END CATCH
GO