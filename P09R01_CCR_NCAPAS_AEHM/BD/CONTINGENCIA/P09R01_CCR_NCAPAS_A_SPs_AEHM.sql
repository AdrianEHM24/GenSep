/*
 P09R01_CCR_NCAPAS_AEHM
 AUTOR: ADRIAN ELEUTERIO HERNANDEZ MARTINEZ
 FECHA: 09/09/2026
*/

USE GenSepCCR;
GO
--=============================
-- ELIMINAR SPs
--=============================
--COMMIT Y ROLLBACK
------------ELIMINAR SPs DE CAMIONES------------------------------
BEGIN TRANSACTION
	BEGIN TRY
		--VALIDACIONES
		IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_NAME = 'Insert_Camion'
			AND ROUTINE_SCHEMA = 'dbo')
			BEGIN
				--Eliminar: procedimiento Insert_Camion
				DROP PROCEDURE dbo.Insert_Camion;
				PRINT 'Procedimiento Insert_Camion eliminado correctamente.';
			END
		ELSE
			BEGIN
				PRINT 'El procedimiento [dbo][Insert_Camion] no existe.'
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
		IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_NAME = 'Select_Camion'
			AND ROUTINE_SCHEMA = 'dbo')
			BEGIN
				--Eliminar: procedimiento Select_Camion
				DROP PROCEDURE dbo.Select_Camion;
				PRINT 'Procedimiento Select_Camion eliminado correctamente.';
			END
		ELSE
			BEGIN
				PRINT 'El procedimiento [dbo][Select_Camion] no existe.'
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
		IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_NAME = 'Update_Camion'
			AND ROUTINE_SCHEMA = 'dbo')
			BEGIN
				--Eliminar: procedimiento Update_Camion
				DROP PROCEDURE dbo.Update_Camion;
				PRINT 'Procedimiento Update_Camion eliminado correctamente.';
			END
		ELSE
			BEGIN
				PRINT 'El procedimiento [dbo][Update_Camion] no existe.'
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
		IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_NAME = 'Delete_Camion'
			AND ROUTINE_SCHEMA = 'dbo')
			BEGIN
				--Eliminar: procedimiento Delete_Camion
				DROP PROCEDURE dbo.Delete_Camion;
				PRINT 'Procedimiento Delete_Camion eliminado correctamente.';
			END
		ELSE
			BEGIN
				PRINT 'El procedimiento [dbo][Delete_Camion] no existe.'
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
--------------Eliminar SPs de choferes------------------------
BEGIN TRANSACTION
	BEGIN TRY
		--VALIDACIONES
		IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_NAME = 'Insert_Choferes'
			AND ROUTINE_SCHEMA = 'dbo')
			BEGIN
				--Eliminar: procedimiento Insert_Choferes
				DROP PROCEDURE dbo.Insert_Choferes;
				PRINT 'Procedimiento Insert_Choferes eliminado correctamente.';
			END
		ELSE
			BEGIN
				PRINT 'El procedimiento [dbo][Insert_Choferes] no existe.'
			END
		COMMIT TRANSACTION; --Confirmar cambios
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;
		THROW;
	END CATCH
GO

--------COMMIT Y ROLLBACK-------------
BEGIN TRANSACTION
	BEGIN TRY
		--VALIDACIONES
		IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_NAME = 'Select_Chofer'
			AND ROUTINE_SCHEMA = 'dbo')
			BEGIN
				--Eliminar: procedimiento Select_Chofer
				DROP PROCEDURE dbo.Select_Chofer;
				PRINT 'Procedimiento Select_Chofer eliminado correctamente.';
			END
		ELSE
			BEGIN
				PRINT 'El procedimiento [dbo][Select_Chofer] no existe.'
			END
		COMMIT TRANSACTION; --Confirmar cambios
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;
		THROW;
	END CATCH
GO

--------COMMIT Y ROLLBACK-------------
BEGIN TRANSACTION
	BEGIN TRY
		--VALIDACIONES
		IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_NAME = 'Update_Choferes'
			AND ROUTINE_SCHEMA = 'dbo')
			BEGIN
				--Eliminar: procedimiento Update_Choferes
				DROP PROCEDURE dbo.Update_Choferes;
				PRINT 'Procedimiento Update_Choferes eliminado correctamente.';
			END
		ELSE
			BEGIN
				PRINT 'El procedimiento [dbo][Update_Choferes] no existe.'
			END
		COMMIT TRANSACTION; --Confirmar cambios
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;
		THROW;
	END CATCH
GO

--------COMMIT Y ROLLBACK-------------
BEGIN TRANSACTION
	BEGIN TRY
		--VALIDACIONES
		IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_NAME = 'Delete_Chofer'
			AND ROUTINE_SCHEMA = 'dbo')
			BEGIN
				--Eliminar: procedimiento Delete_Chofer
				DROP PROCEDURE dbo.Delete_Chofer;
				PRINT 'Procedimiento Delete_Chofer eliminado correctamente.';
			END
		ELSE
			BEGIN
				PRINT 'El procedimiento [dbo][Delete_Chofer] no existe.'
			END
		COMMIT TRANSACTION; --Confirmar cambios
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;
		THROW;
	END CATCH
GO

--------------ELIMINAR SPs DE RUTAS-------------
--------COMMIT Y ROLLBACK-------------
BEGIN TRANSACTION
	BEGIN TRY
		--VALIDACIONES
		IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_NAME = 'Insert_Rutas'
			AND ROUTINE_SCHEMA = 'dbo')
			BEGIN
				--Eliminar: procedimiento Insert_Rutas
				DROP PROCEDURE dbo.Insert_Rutas;
				PRINT 'Procedimiento Insert_Rutas eliminado correctamente.';
			END
		ELSE
			BEGIN
				PRINT 'El procedimiento [dbo][Insert_Rutas] no existe.'
			END
		COMMIT TRANSACTION; --Confirmar cambios
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;
		THROW;
	END CATCH
GO

--------COMMIT Y ROLLBACK-------------
BEGIN TRANSACTION
	BEGIN TRY
		--VALIDACIONES
		IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_NAME = 'Select_Rutas'
			AND ROUTINE_SCHEMA = 'dbo')
			BEGIN
				--Eliminar: procedimiento Select_Rutas
				DROP PROCEDURE dbo.Select_Rutas;
				PRINT 'Procedimiento Select_Rutas eliminado correctamente.';
			END
		ELSE
			BEGIN
				PRINT 'El procedimiento [dbo][Select_Rutas] no existe.'
			END
		COMMIT TRANSACTION; --Confirmar cambios
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;
		THROW;
	END CATCH
GO

--------COMMIT Y ROLLBACK-------------
BEGIN TRANSACTION
	BEGIN TRY
		--VALIDACIONES
		IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_NAME = 'Update_Rutas'
			AND ROUTINE_SCHEMA = 'dbo')
			BEGIN
				--Eliminar: procedimiento Update_Rutas
				DROP PROCEDURE dbo.Update_Rutas;
				PRINT 'Procedimiento Update_Rutas eliminado correctamente.';
			END
		ELSE
			BEGIN
				PRINT 'El procedimiento [dbo][Update_Rutas] no existe.'
			END
		COMMIT TRANSACTION; --Confirmar cambios
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;
		THROW;
	END CATCH
GO

--------COMMIT Y ROLLBACK-------------
BEGIN TRANSACTION
	BEGIN TRY
		--VALIDACIONES
		IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_NAME = 'Delete_Ruta'
			AND ROUTINE_SCHEMA = 'dbo')
			BEGIN
				--Eliminar: procedimiento Delete_Ruta
				DROP PROCEDURE dbo.Delete_Ruta;
				PRINT 'Procedimiento Delete_Ruta eliminado correctamente.';
			END
		ELSE
			BEGIN
				PRINT 'El procedimiento [dbo][Delete_Ruta] no existe.'
			END
		COMMIT TRANSACTION; --Confirmar cambios
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;
		THROW;
	END CATCH
GO

--------------ELIMINAR SPs ESPECIALES---------------
--------COMMIT Y ROLLBACK-------------
BEGIN TRANSACTION
	BEGIN TRY
		--VALIDACIONES
		IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_NAME = 'Select_Rutas_Detalle'
			AND ROUTINE_SCHEMA = 'dbo')
			BEGIN
				--Eliminar: procedimiento Select_Rutas_Detalle
				DROP PROCEDURE dbo.Select_Rutas_Detalle;
				PRINT 'Procedimiento Select_Rutas_Detalle eliminado correctamente.';
			END
		ELSE
			BEGIN
				PRINT 'El procedimiento [dbo][Select_Rutas_Detalle] no existe.'
			END
		COMMIT TRANSACTION; --Confirmar cambios
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;
		THROW;
	END CATCH
GO

--------COMMIT Y ROLLBACK-------------
BEGIN TRANSACTION
	BEGIN TRY
		--VALIDACIONES
		IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_NAME = 'Existe_Licencia'
			AND ROUTINE_SCHEMA = 'dbo')
			BEGIN
				--Eliminar: procedimiento Existe_Licencia
				DROP PROCEDURE dbo.Existe_Licencia;
				PRINT 'Procedimiento Existe_Licencia eliminado correctamente.';
			END
		ELSE
			BEGIN
				PRINT 'El procedimiento [dbo][Existe_Licencia] no existe.'
			END
		COMMIT TRANSACTION; --Confirmar cambios
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;
		THROW;
	END CATCH
GO

--------COMMIT Y ROLLBACK-------------
BEGIN TRANSACTION
	BEGIN TRY
		--VALIDACIONES
		IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_NAME = 'Obtener_Camion_ID'
			AND ROUTINE_SCHEMA = 'dbo')
			BEGIN
				--Eliminar: procedimiento Obtener_Camion_ID
				DROP PROCEDURE dbo.Obtener_Camion_ID;
				PRINT 'Procedimiento Obtener_Camion_ID eliminado correctamente.';
			END
		ELSE
			BEGIN
				PRINT 'El procedimiento [dbo][Obtener_Camion_ID] no existe.'
			END
		COMMIT TRANSACTION; --Confirmar cambios
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;
		THROW;
	END CATCH
GO

--------COMMIT Y ROLLBACK-------------
BEGIN TRANSACTION
	BEGIN TRY
		--VALIDACIONES
		IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_NAME = 'Existe_Matricula'
			AND ROUTINE_SCHEMA = 'dbo')
			BEGIN
				--Eliminar: procedimiento Existe_Matricula
				DROP PROCEDURE dbo.Existe_Matricula;
				PRINT 'Procedimiento Existe_Matricula eliminado correctamente.';
			END
		ELSE
			BEGIN
				PRINT 'El procedimiento [dbo][Existe_Matricula] no existe.'
			END
		COMMIT TRANSACTION; --Confirmar cambios
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;
		THROW;
	END CATCH
GO

--------COMMIT Y ROLLBACK-------------
BEGIN TRANSACTION
	BEGIN TRY
		--VALIDACIONES
		IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_NAME = 'Listar_Camiones'
			AND ROUTINE_SCHEMA = 'dbo')
			BEGIN
				--Eliminar: procedimiento Listar_Camiones
				DROP PROCEDURE dbo.Listar_Camiones;
				PRINT 'Procedimiento Listar_Camiones eliminado correctamente.';
			END
		ELSE
			BEGIN
				PRINT 'El procedimiento [dbo][Listar_Camiones] no existe.'
			END
		COMMIT TRANSACTION; --Confirmar cambios
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;
		THROW;
	END CATCH
GO