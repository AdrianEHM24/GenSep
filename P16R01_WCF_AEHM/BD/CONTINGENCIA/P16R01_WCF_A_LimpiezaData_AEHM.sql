/*
 P10R01_WS_AEHM
 AUTOR: ADRIAN ELEUTERIO HERNANDEZ MARTINEZ
 FECHA: 11/09/2026
*/

USE BD_Ejemplo
GO

--=============================
-- LIMPIEZA DATA
--=============================
--COMMIT Y ROLLBACK
BEGIN TRANSACTION
	BEGIN TRY
		--VALIDACIONES
		IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Usuarios'
			AND TABLE_SCHEMA = 'dbo')
			BEGIN
				--ELIMINAR: Datos de Rutas
				DELETE FROM dbo.Usuarios;
				PRINT 'Datos de la tabla Usuarios eliminados corretamente.';
			END
		ELSE
			BEGIN
				PRINT 'La tabla [dbo].[Usuarios] no existe.'
			END
		COMMIT TRANSACTION; --CONFIRMAR CAMBIOS
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION
		THROW;
	END CATCH
GO
