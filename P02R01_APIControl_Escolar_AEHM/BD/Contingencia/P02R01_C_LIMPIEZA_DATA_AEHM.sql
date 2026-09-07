USE Control_Escolar
GO

/*
 P02R01_APIControl_Escolar_AEHM
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
		IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tblAlumnos'
			AND TABLE_SCHEMA = 'dbo')
			BEGIN
				--ELIMINAR: Datos de tblAlumnos
				DELETE FROM dbo.tblAlumnos;
				PRINT 'Datos de la tabla tblAlumnos eliminados corretamente.';
			END
		ELSE
			BEGIN
				PRINT 'La tabla [dbo].[tblAlumnos] no existe.'
			END
		COMMIT TRANSACTION; --CONFIRMAR CAMBIOS
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION
		THROW;
	END CATCH
GO
