USE BIOMETRICO
GO

USE master
go
/*
P07R01_PruebaTecnica_AEHM
AUTOR: ADRIAN ELEUTERIO HERNANDEZ MARTINEZ
 FECHA: 07/09/2026
*/

--=============================
-- CONTINGENCIA DE SP'S
--=============================
--COMMIT Y ROLLBACK
BEGIN TRANSACTION
	BEGIN TRY
		--VALIDACIONES
		IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_NAME = 'spConsultar_FechaHora_Colaboradores'
			AND ROUTINE_SCHEMA = 'dbo')
			BEGIN
				--Eliminar: procedimiento spConsultar_FechaHora_Colaboradores
				DROP PROCEDURE dbo.spConsultar_FechaHora_Colaboradores;
				PRINT 'Procedimiento spConsultar_FechaHora_Colaboradores eliminado correctamente.';
			END
		ELSE
			BEGIN
				PRINT 'El procedimiento [dbo][spConsultar_FechaHora_Colaboradores] no existe.'
			END
		COMMIT TRANSACTION; --Confirmar cambios
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;
		THROW;
	END CATCH
GO

BEGIN TRANSACTION 
	BEGIN TRY
	--VALIDACIONES
		IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_NAME = 'spEliminarColaborador'
			AND ROUTINE_SCHEMA = 'dbo')
			BEGIN
				--Eliminar: procedimiento spEliminarColaborador
				DROP PROCEDURE dbo.spEliminarColaborador;
				PRINT 'Procedimiento spEliminarColaborador eliminado correctamente.';
			END
		ELSE
			BEGIN
				PRINT 'El procedimiento [dbo][spEliminarColaborador] no existe.'
			END
	COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT >0
			ROLLBACK TRANSACTION
		THROW;
	END CATCH
GO

BEGIN TRANSACTION 
	BEGIN TRY
	--VALIDACIONES
		IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_NAME = 'spConsultar_FechaTurno_Colaboradores'
			AND ROUTINE_SCHEMA = 'dbo')
			BEGIN
				--Eliminar: procedimiento spConsultar_FechaTurno_Colaboradores
				DROP PROCEDURE dbo.spConsultar_FechaTurno_Colaboradores;
				PRINT 'Procedimiento spConsultar_FechaTurno_Colaboradores eliminado correctamente.';
			END
		ELSE
			BEGIN
				PRINT 'El procedimiento [dbo][spConsultar_FechaTurno_Colaboradores] no existe.'
			END
	COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT >0
			ROLLBACK TRANSACTION
		THROW;
	END CATCH
GO

BEGIN TRANSACTION 
	BEGIN TRY
	--VALIDACIONES
		IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_NAME = 'spUpdate_Colaboradores'
			AND ROUTINE_SCHEMA = 'dbo')
			BEGIN
				--Eliminar: procedimiento spUpdate_Colaboradores
				DROP PROCEDURE dbo.spUpdate_Colaboradores;
				PRINT 'Procedimiento spUpdate_Colaboradores eliminado correctamente.';
			END
		ELSE
			BEGIN
				PRINT 'El procedimiento [dbo][spUpdate_Colaboradores] no existe.'
			END
	COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT >0
			ROLLBACK TRANSACTION
		THROW;
	END CATCH
GO

BEGIN TRANSACTION 
	BEGIN TRY
	--VALIDACIONES
		IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_NAME = 'spInsert_Colaboradores'
			AND ROUTINE_SCHEMA = 'dbo')
			BEGIN
				--Eliminar: procedimiento spInsert_Colaboradores
				DROP PROCEDURE dbo.spInsert_Colaboradores;
				PRINT 'Procedimiento spInsert_Colaboradores eliminado correctamente.';
			END
		ELSE
			BEGIN
				PRINT 'El procedimiento [dbo][spInsert_Colaboradores] no existe.'
			END
	COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT >0
			ROLLBACK TRANSACTION
		THROW;
	END CATCH
GO