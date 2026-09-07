USE Control_Escolar
GO
/*
 P02R01_APIControl_Escolar_AEHM
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
		IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.VIEWS WHERE TABLE_NAME = 'vwAlumnos'
			AND TABLE_SCHEMA = 'dbo')
			BEGIN
				--ELIMINAR: Vista vwAlumnos
				DROP VIEW dbo.vwAlumnos;
				PRINT 'Vista vwAlumnos eliminada correctamente.';
			END
		ELSE
			BEGIN
				PRINT 'La vista [dbo][vwAlumnos] no existe.'
			END
		COMMIT TRANSACTION --confirmar cambios
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;
		THROW
	END CATCH
GO