/*
P07R01_PruebaTecnica_AEHM
AUTOR: ADRIAN ELEUTERIO HERNANDEZ MARTINEZ
 FECHA: 07/09/2026
*/

--=============================
-- ELIMINAR DATABASE
--=============================

BEGIN TRY
	--VALIDACIONES
	IF EXISTS (SELECT 1 FROM sys.databases WHERE name = 'BIOMETRICO')
		BEGIN
			--Eliminar base de datos BIOMETRICO
			USE master; --Asegurarse de no estar en la base de datos a eliminar

			ALTER DATABASE BIOMETRICO SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
			DROP DATABASE BIOMETRICO;
			PRINT 'Base de datos BIOMETRICO eliminada correctamente.';
		END
	ELSE
		BEGIN
			PRINT 'La base de datos BIOMETRICO no existe.'
		END
END TRY
BEGIN CATCH
	--Intentar restaurar acceso multiusuario
	IF EXISTS (SELECT 1 FROM sys.databases WHERE name = 'BIOMETRICO')
		ALTER DATABASE BIOMETRICO SET MULTI_USER;
	THROW;
END CATCH
GO