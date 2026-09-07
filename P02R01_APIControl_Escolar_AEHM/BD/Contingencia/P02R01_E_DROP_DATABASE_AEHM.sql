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
	IF EXISTS (SELECT 1 FROM sys.databases WHERE name = 'Control_Escolar')
		BEGIN
			--Eliminar base de datos Control_Escolar
			USE master; --Asegurarse de no estar en la base de datos a eliminar

			ALTER DATABASE Control_Escolar SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
			DROP DATABASE Control_Escolar;
			PRINT 'Base de datos Control_Escolar eliminada correctamente.';
		END
	ELSE
		BEGIN
			PRINT 'La base de datos Control_Escolar no existe.'
		END
END TRY
BEGIN CATCH
	--Intentar restaurar acceso multiusuario
	IF EXISTS (SELECT 1 FROM sys.databases WHERE name = 'Control_Escolar')
		ALTER DATABASE Control_Escolar SET MULTI_USER;
	THROW;
END CATCH
GO