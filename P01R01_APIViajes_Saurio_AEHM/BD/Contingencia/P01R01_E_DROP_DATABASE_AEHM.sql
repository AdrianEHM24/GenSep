/*
 P02R01_APIControl_Escolar_AEHM
 AUTOR: ADRIAN ELEUTERIO HERNANDEZ MARTINEZ
 FECHA: 04/09/2026
*/

--=============================
-- DROP DATABASE
--=============================
BEGIN TRY
	--VALIDACIONES
	IF EXISTS (SELECT 1 FROM sys.databases WHERE name = 'TURISMO')
		BEGIN
			--Eliminar base de datos TURISMO
			USE master; --Asegurarse de no estar en la base de datos a eliminar

			ALTER DATABASE TURISMO SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
			DROP DATABASE TURISMO;
			PRINT 'Base de datos TURISMO eliminada correctamente.';
		END
	ELSE
		BEGIN
			PRINT 'La base de datos TURISMO no existe.'
		END
END TRY
BEGIN CATCH
	--Intentar restaurar acceso multiusuario
	IF EXISTS (SELECT 1 FROM sys.databases WHERE name = 'TURISMO')
		ALTER DATABASE TURISMO SET MULTI_USER;
	THROW;
END CATCH
GO