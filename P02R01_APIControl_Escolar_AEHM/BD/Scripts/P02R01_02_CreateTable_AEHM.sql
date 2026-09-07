/*
 P02R01_APIControl_Escolar_AEHM
 AUTOR: ADRIAN ELEUTERIO HERNANDEZ MARTINEZ
 FECHA: 04/09/2026
*/

--=============================
-- CREACIÓN DE TABLAS
--=============================

USE Control_Escolar;
GO

IF NOT EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tblAlumnos')
BEGIN
CREATE TABLE tblAlumnos(
	Matricula INT PRIMARY KEY IDENTITY(1,1),
	Nombre VARCHAR (50),
	Direccion VARCHAR (50),
	Apellido_Paterno VARCHAR (50),
	Apellido_Materno VARCHAR (50),
	Correo VARCHAR (100),
	Telefono INT
)
END 
ELSE PRINT ('La tabla ya existe')
GO