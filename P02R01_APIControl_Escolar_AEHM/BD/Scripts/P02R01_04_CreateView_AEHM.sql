/*
 P02R01_APIControl_Escolar_AEHM
 AUTOR: ADRIAN ELEUTERIO HERNANDEZ MARTINEZ
 FECHA: 04/09/2026
*/

--=============================
-- CREACIÓN DE VIEWS
--=============================

USE Control_Escolar;
GO

CREATE OR ALTER VIEW vwAlumnos
AS
SELECT * FROM tblAlumnos;
GO