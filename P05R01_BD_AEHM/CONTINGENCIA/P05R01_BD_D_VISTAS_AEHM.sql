USE GenSep
GO

/*05
 P05R01_BD_AEHM
 AUTOR: ADRIAN ELEUTERIO HERNANDEZ MARTINEZ
 FECHA: 03/09/2026
*/

--=============================
-- CONTINGENCIA DE VISTAS
--=============================
--COMMIT Y ROLLBACK
BEGIN TRANSACTION
	BEGIN TRY
		--VALIDACIONES
		IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.VIEWS WHERE TABLE_NAME = 'VWVistaResumenVentas'
			AND TABLE_SCHEMA = 'dbo')
			BEGIN
				--ELIMINAR: Vista VWVistaResumenVentas
				DROP VIEW dbo.VWVistaResumenVentas;
				PRINT 'Vista VWVistaResumenVentas eliminada correctamente.';
			END
		ELSE
			BEGIN
				PRINT 'La vista [dbo][VWVistaResumenVentas] no existe.'
			END
		COMMIT TRANSACTION --confirmar cambios
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;
		THROW
	END CATCH
GO