/*
P07R01_PruebaTecnica_AEHM
AUTOR: ADRIAN ELEUTERIO HERNANDEZ MARTINEZ
 FECHA: 07/09/2026
*/

--===================
	--CREATE DATABASE
--===================

IF NOT EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'BIOMETRICO')
	BEGIN
		CREATE DATABASE BIOMETRICO
		PRINT 'Base de datos BIOMETRICO creada correctamente'
	END
	ELSE
		BEGIN
			PRINT 'la base de datos ya existe.';
		END
GO