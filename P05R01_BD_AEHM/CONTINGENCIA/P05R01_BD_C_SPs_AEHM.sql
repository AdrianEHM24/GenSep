USE GenSep
GO

/*05
 P05R01_BD_AEHM
 AUTOR: ADRIAN ELEUTERIO HERNANDEZ MARTINEZ
 FECHA: 03/09/2026
*/

--=============================
-- CONTINGENCIA DE SP'S
--=============================
--COMMIT Y ROLLBACK
BEGIN TRANSACTION
	BEGIN TRY
		--VALIDACIONES
		IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_NAME = 'spObtenerClientePorID'
			AND ROUTINE_SCHEMA = 'dbo')
			BEGIN
				--Eliminar: procedimiento spObtenerClientePorID
				DROP PROCEDURE dbo.spObtenerClientePorID;
				PRINT 'Procedimiento spObtenerClientePorID eliminado correctamente.';
			END
		ELSE
			BEGIN
				PRINT 'El procedimiento [dbo][spObtenerClientePorID] no existe.'
			END
		COMMIT TRANSACTION; --Confirmar cambios
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;
		THROW;
	END CATCH
GO

--COMMIT Y ROLLBACK
BEGIN TRANSACTION
	BEGIN TRY
		--VALIDACIONES
		IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_NAME = 'spInsertarPedido'
			AND ROUTINE_SCHEMA = 'dbo')
			BEGIN
				--Eliminar: procedimiento spInsertarPedido
				DROP PROCEDURE dbo.spInsertarPedido;
				PRINT 'Procedimiento spInsertarPedido eliminado correctamente.';
			END
		ELSE
			BEGIN
				PRINT 'El procedimiento [dbo][spInsertarPedido] no existe.'
			END
		COMMIT TRANSACTION; --Confirmar cambios
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;
		THROW;
	END CATCH
GO

--COMMIT Y ROLLBACK
BEGIN TRANSACTION
	BEGIN TRY
		--VALIDACIONES
		IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_NAME = 'spConsultarContenidoTablas'
			AND ROUTINE_SCHEMA = 'dbo')
			BEGIN
				--Eliminar: procedimiento dbo.spConsultarContenidoTablas
				DROP PROCEDURE dbo.spConsultarContenidoTablas;
				PRINT 'Procedimiento dbo.spConsultarContenidoTablas eliminado correctamente.';
			END
		ELSE
			BEGIN
				PRINT 'El procedimiento [dbo][spConsultarContenidoTablas] no existe.'
			END
		COMMIT TRANSACTION; --Confirmar cambios
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;
		THROW;
	END CATCH
GO