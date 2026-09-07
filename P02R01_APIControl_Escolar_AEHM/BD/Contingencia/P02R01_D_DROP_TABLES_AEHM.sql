USE Control_Escolar
GO
/*
 P02R01_APIControl_Escolar_AEHM
 AUTOR: ADRIAN ELEUTERIO HERNANDEZ MARTINEZ
 FECHA: 04/09/2026
*/

--=============================
-- ELIMINAR TABLAS
--=============================

--COMMIT Y ROLLBACK
BEGIN TRANSACTION
	BEGIN TRY
		--VALIDACIONES - ELIMINAR EN ORDEN INVERSO DE DEPENDENCIAS
		--TABLA: AuditoriaProductos
		IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tblAlumnos'
			AND TABLE_SCHEMA = 'dbo')
			BEGIN
				DROP TABLE tblAlumnos;
				PRINT 'Tabla tblAlumnos eliminada correctamente'
			END
		ELSE 
			BEGIN
				PRINT 'La tabla tblAlumnos no existe'
			END
		COMMIT TRANSACTION; --CONFIRMAR CAMBIOS
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION
		THROW;
	END CATCH
GO