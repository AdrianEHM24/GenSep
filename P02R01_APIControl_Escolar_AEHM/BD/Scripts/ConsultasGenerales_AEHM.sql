/*
 P02R01_APIControl_Escolar_AEHM
 AUTOR: ADRIAN ELEUTERIO HERNANDE
 FECHA: 04/09/2026
*/

--=============================
-- CONSULTAS GENERALES
--=============================
USE Control_Escolar
GO

SELECT * FROM tblAlumnos

EXEC spAlumno 'Juan', 'Guerrero', 'Perez', 'Garcia','Juan@gmail.com', '5512';

SELECT TOP (1000) [Matricula]
      ,[Nombre]
      ,[Direccion]
      ,[Apellido_Paterno]
      ,[Apellido_Materno]
      ,[Correo]
      ,[Telefono]
  FROM [Control_Escolar].[dbo].[vwAlumnos]