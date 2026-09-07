/*
 P02R01_APIControl_Escolar_AEHM
 AUTOR: ADRIAN ELEUTERIO HERNANDEZ MARTINEZ
 FECHA: 04/09/2026
*/

--=============================
-- CREACIÓN DE LA BASE DE DATOS
--=============================

IF NOT EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name ='Control_Escolar')
BEGIN
CREATE DATABASE Control_Escolar
END
ELSE PRINT ('YA EXISTE LA BASE DE DATOS')
GO