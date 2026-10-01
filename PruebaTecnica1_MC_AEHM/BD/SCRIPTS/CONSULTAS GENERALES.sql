/*
PruebaTecnica1_MC_AEHM
AUTOR:Adrián Eleuterio Hernández Martínez
FECHA:21/09/2026
*/

-- =============================================
-- CONSULTAS GENERALES
-- =============================================

USE SistemaLoginMC;
GO

SELECT TOP (1000) * FROM tblUsuarios
SELECT TOP (1000) * FROM tblDocumentos
SELECT TOP (1000) * FROM tblConfiguracionImpresion

--SP_HELP 'tblUsuarios'

GO

--UPDATE  tblUsuarios
--SELECT * FROM tblUsuarios
SET HorarioEntrada = '00:00', HorarioSalida = '08:00'
WHERE Id = 7

select @@SERVERNAME

EXEC sp_help 'tblConfiguracionImpresion'
EXEC sp_help 'tblDocumentos'
EXEC sp_help 'tblUsuarios'