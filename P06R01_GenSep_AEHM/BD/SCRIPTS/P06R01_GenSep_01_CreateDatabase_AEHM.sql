/*
 P06R01_GenSep_AEHM
 AUTOR: ADRIAN ELEUTERIO HERNANDEZ MARTINEZ
 FECHA: 07/09/2026
*/

--=============================
-- CREACIÓN DE LA BASE DE DATOS
--=============================
IF NOT EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'GenSep')
BEGIN
		CREATE DATABASE GenSep;
		PRINT 'Base de datos GenSep creada correctamente.';
END
ELSE
BEGIN
	PRINT 'la base de datos ya existe.';
END
GO