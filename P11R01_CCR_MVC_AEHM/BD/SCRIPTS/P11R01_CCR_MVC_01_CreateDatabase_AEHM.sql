/*
 P09R01_CCR_NCAPAS_AEHM
 AUTOR: ADRIAN ELEUTERIO HERNANDEZ MARTINEZ
 FECHA: 09/09/2026
*/

--=============================
-- CREACIÓN DE LA BASE DE DATOS
--=============================
IF NOT EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'GenSepCCR')
BEGIN
		CREATE DATABASE GenSepCCR;
		PRINT 'Base de datos GenSepCCR creada correctamente.';
END
ELSE
BEGIN
	PRINT 'la base de datos GenSepCCR ya existe.';
END
GO