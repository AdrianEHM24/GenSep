/*
P08R01_MICROSERVICIOS_AEHM
AUTOR: ADRIAN ELEUTERIO HERNANDEZ MARTINEZ
 FECHA: 08/09/2026
*/

--===================
	--DROP DATABASE
--===================
BEGIN TRY
	--VALIDACIONES
	IF EXISTS (SELECT 1 FROM sys.databases WHERE name = 'EPP_Movimientos')
		BEGIN
			--Eliminar base de datos EPP_Movimientos
			USE master; --Asegurarse de no estar en la base de datos a eliminar

			ALTER DATABASE EPP_Movimientos SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
			DROP DATABASE EPP_Movimientos;
			PRINT 'Base de datos EPP_Movimientos eliminada correctamente.';
		END
	ELSE
		BEGIN
			PRINT 'La base de datos EPP_Movimientos no existe.'
		END
END TRY
BEGIN CATCH
	--Intentar restaurar acceso multiusuario
	IF EXISTS (SELECT 1 FROM sys.databases WHERE name = 'EPP_Movimientos')
		ALTER DATABASE EPP_Movimientos SET MULTI_USER;
	THROW;
END CATCH
GO