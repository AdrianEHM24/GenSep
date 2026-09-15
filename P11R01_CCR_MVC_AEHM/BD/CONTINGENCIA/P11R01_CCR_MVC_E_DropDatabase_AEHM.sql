/*
 P09R01_CCR_NCAPAS_AEHM
 AUTOR: ADRIAN ELEUTERIO HERNANDEZ MARTINEZ
 FECHA: 09/09/2026
*/

--=============================
-- DROP BASE DE DATOS
--=============================
BEGIN TRY
	--VALIDACIONES
	IF EXISTS (SELECT 1 FROM sys.databases WHERE name = 'GenSepCCR')
		BEGIN
			--Eliminar base de datos GenSepCCR
			USE master; --Asegurarse de no estar en la base de datos a eliminar

			ALTER DATABASE GenSepCCR SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
			DROP DATABASE GenSepCCR;
			PRINT 'Base de datos GenSepCCR eliminada correctamente.';
		END
	ELSE
		BEGIN
			PRINT 'La base de datos GenSepCCR no existe.'
		END
END TRY
BEGIN CATCH
	--Intentar restaurar acceso multiusuario
	IF EXISTS (SELECT 1 FROM sys.databases WHERE name = 'GenSepCCR')
		ALTER DATABASE GenSepCCR SET MULTI_USER;
	THROW;
END CATCH
GO