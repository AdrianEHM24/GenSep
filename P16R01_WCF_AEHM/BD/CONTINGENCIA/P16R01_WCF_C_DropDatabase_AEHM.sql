/*
 P10R01_WS_AEHM
 AUTOR: ADRIAN ELEUTERIO HERNANDEZ MARTINEZ
 FECHA: 11/09/2026
*/

--=============================
-- ELIMINAR BASE DE DATOS
--=============================
BEGIN TRY
	--VALIDACIONES
	IF EXISTS (SELECT 1 FROM sys.databases WHERE name = 'BD_Ejemplo')
		BEGIN
			--Eliminar base de datos BD_Ejemplo
			USE master; --Asegurarse de no estar en la base de datos a eliminar

			ALTER DATABASE BD_Ejemplo SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
			DROP DATABASE BD_Ejemplo;
			PRINT 'Base de datos BD_Ejemplo eliminada correctamente.';
		END
	ELSE
		BEGIN
			PRINT 'La base de datos BD_Ejemplo no existe.'
		END
END TRY
BEGIN CATCH
	--Intentar restaurar acceso multiusuario
	IF EXISTS (SELECT 1 FROM sys.databases WHERE name = 'BD_Ejemplo')
		ALTER DATABASE BD_Ejemplo SET MULTI_USER;
	THROW;
END CATCH
GO