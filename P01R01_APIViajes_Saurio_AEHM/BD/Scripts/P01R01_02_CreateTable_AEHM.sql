/*
 P01R01_APIViajes_Saurio_AEHM
 AUTOR: ADRIAN ELEUTERIO HERNANDEZ MARTINEZ
 FECHA: 04/09/2026
*/

--=============================
-- CREACIÓN DE TABLAS
--=============================

USE TURISMO;
GO

IF NOT EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tblDestino')
BEGIN
CREATE TABLE tblDestino(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Nombre NVARCHAR (50),
	Direccion NVARCHAR (50),
	Descripcion NVARCHAR (100)
)
END 
ELSE PRINT ('La tabla ya existe')
GO