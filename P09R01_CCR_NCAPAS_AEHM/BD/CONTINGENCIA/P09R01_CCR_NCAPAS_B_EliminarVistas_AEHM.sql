/*
 P09R01_CCR_NCAPAS_AEHM
 AUTOR: ADRIAN ELEUTERIO HERNANDEZ MARTINEZ
 FECHA: 09/09/2026
*/

USE GenSepCCR;
GO
--=============================
-- ELIMINAR VISTAS
--=============================

--COMMIT Y ROLLBACK
BEGIN TRANSACTION
	BEGIN TRY
		--VALIDACIONES
		IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.VIEWS WHERE TABLE_NAME = 'VWCamiones'
			AND TABLE_SCHEMA = 'dbo')
			BEGIN
				--ELIMINAR: Vista VWCamiones
				DROP VIEW dbo.VWCamiones;
				PRINT 'Vista VWCamiones eliminada correctamente.';
			END
		ELSE
			BEGIN
				PRINT 'La vista [dbo][VWCamiones] no existe.'
			END
		COMMIT TRANSACTION --confirmar cambios
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;
		THROW
	END CATCH
GO

--COMMIT Y ROLLBACK
BEGIN TRANSACTION
	BEGIN TRY
		--VALIDACIONES
		IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.VIEWS WHERE TABLE_NAME = 'VWChoferes'
			AND TABLE_SCHEMA = 'dbo')
			BEGIN
				--ELIMINAR: Vista VWChoferes
				DROP VIEW dbo.VWChoferes;
				PRINT 'Vista VWChoferes eliminada correctamente.';
			END
		ELSE
			BEGIN
				PRINT 'La vista [dbo][VWChoferes] no existe.'
			END
		COMMIT TRANSACTION --confirmar cambios
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;
		THROW
	END CATCH
GO

--COMMIT Y ROLLBACK
BEGIN TRANSACTION
	BEGIN TRY
		--VALIDACIONES
		IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.VIEWS WHERE TABLE_NAME = 'VWRutas'
			AND TABLE_SCHEMA = 'dbo')
			BEGIN
				--ELIMINAR: Vista VWRutas
				DROP VIEW dbo.VWRutas;
				PRINT 'Vista VWRutas eliminada correctamente.';
			END
		ELSE
			BEGIN
				PRINT 'La vista [dbo][VWRutas] no existe.'
			END
		COMMIT TRANSACTION --confirmar cambios
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;
		THROW
	END CATCH
GO