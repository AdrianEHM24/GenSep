
/*05
 P05R01_BD_AEHM
 AUTOR: ADRIAN ELEUTERIO HERNANDEZ MARTINEZ
 FECHA: 03/09/2026
*/

--=============================
-- DROP DATABASE
--=============================
BEGIN TRY
	--VALIDACIONES
	IF EXISTS (SELECT 1 FROM sys.databases WHERE name = 'GenSep')
		BEGIN
			--Eliminar base de datos GenSep
			USE master; --Asegurarse de no estar en la base de datos a eliminar

			ALTER DATABASE GenSep SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
			DROP DATABASE GenSep;
			PRINT 'Base de datos GenSep eliminada correctamente.';
		END
	ELSE
		BEGIN
			PRINT 'La base de datos GenSep no existe.'
		END
END TRY
BEGIN CATCH
	--Intentar restaurar acceso multiusuario
	IF EXISTS (SELECT 1 FROM sys.databases WHERE name = 'GenSep')
		ALTER DATABASE GenSep SET MULTI_USER;
	THROW;
END CATCH
GO