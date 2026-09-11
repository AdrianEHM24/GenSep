/*
P08R01_MICROSERVICIOS_AEHM
AUTOR: ADRIAN ELEUTERIO HERNANDEZ MARTINEZ
 FECHA: 08/09/2026
*/

--===================
	--CREATE DATABASE
--===================

IF NOT EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'EPP_Movimientos')
	BEGIN
		CREATE DATABASE EPP_Movimientos
		PRINT 'Base de datos EPP_Movimientos creada correctamente'
	END
	ELSE
		BEGIN
			PRINT 'la base de datos EPP_Movimientos ya existe.';
		END
GO