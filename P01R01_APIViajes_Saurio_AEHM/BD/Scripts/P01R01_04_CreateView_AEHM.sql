/*
 P01R01_APIViajes_Saurio_AEHM
 AUTOR: ADRIAN ELEUTERIO HERNANDEZ MARTINEZ
 FECHA: 04/09/2026
*/

--=============================
-- CREACIÓN DE VIEWS
--=============================
USE TURISMO;
GO

CREATE OR ALTER VIEW vwDestinos
AS
SELECT * FROM tblDestino;
GO