/*
 P10R01_WS_AEHM
 AUTOR: ADRIAN ELEUTERIO HERNANDEZ MARTINEZ
 FECHA: 11/09/2026
*/

--=============================
-- CREACIÓN DE LA BASE DE DATOS
--=============================
IF NOT EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'BD_Ejemplo')
BEGIN
		CREATE DATABASE BD_Ejemplo;
		PRINT 'Base de datos BD_Ejemplo creada correctamente.';
END
ELSE
BEGIN
	PRINT 'la base de datos BD_Ejemplo ya existe.';
END
GO