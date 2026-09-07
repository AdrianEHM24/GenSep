/*
 P01R01_APIViajes_Saurio_AEHM
 AUTOR: ADRIAN ELEUTERIO HERNANDEZ
 FECHA: 04/09/2026
*/

--=============================
-- CONSULTAS GENERALES
--=============================
USE TURISMO
GO

SELECT * FROM tblDestino

EXEC spDestino 'Oaxaca', 'Oaxaca', 'Turistico';

SELECT TOP (1000) [Id]
      ,[Nombre]
      ,[Direccion]
      ,[Descripcion]
  FROM [TURISMO].[dbo].[vwDestinos]

  select @@SERVERNAME

 sp_Help 'TURISMO.dbo.tblDestino'