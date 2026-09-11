/*
P08R01_MICROSERVICIOS_AEHM
AUTOR: ADRIAN ELEUTERIO HERNANDEZ MARTINEZ
 FECHA: 08/09/2026
*/

--===================
	--CREATE DATABASE
--===================

IF NOT EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'EPP_Inventario')
	BEGIN
		CREATE DATABASE EPP_Inventario
		PRINT 'Base de datos EPP_Inventario creada correctamente'
	END
	ELSE
		BEGIN
			PRINT 'la base de datos EPP_Inventario ya existe.';
		END
GO