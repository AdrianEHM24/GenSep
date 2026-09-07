/*
 P01R01_APIViajes_Saurio_AEHM
 AUTOR: ADRIAN ELEUTERIO HERNANDEZ MARTINEZ
 FECHA: 04/09/2026
*/

--=============================
-- CREACIÓN DE LA BASE DE DATOS
--=============================
IF NOT EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name ='TURISMO')
BEGIN
CREATE DATABASE TURISMO
END
ELSE PRINT ('YA EXISTE LA BASE DE DATOS')
GO