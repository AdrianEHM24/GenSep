/*
P07R01_PruebaTecnica_AEHM
AUTOR: ADRIAN ELEUTERIO HERNANDEZ MARTINEZ
 FECHA: 07/09/2026
*/

USE BIOMETRICO
GO

--===================
--CONSULTAS GENERALES
--===================

SELECT * FROM [dbo].[tblColaboradores]
SELECT * FROM [dbo].[tblnivelEducativo]
SELECT * FROM [dbo].[tblturnoTrabajo]

DECLARE @FechaActual DATETIME = '15:00';
DECLARE @FECHAGET DATETIME = GETDATE();

EXEC spInsert_Colaboradores 'NOMBRE', 'Hernandez', 'Martinez', '1985-12-21', 4, '7821343961',
	1, '2026-09-07T13:35:01.940', '2026-01-01', 2, @FechaActual, @FECHAGET, 8

EXEC spUpdate_Colaboradores 5, 'NOMBRE', 'Hernandez', 'Martinez', '1985-12-21', 4, '7821343961',
	1, '2026-09-07T13:35:01.940', '2026-01-01', 2, @FechaActual, @FECHAGET, 8

EXEC spConsultar_FechaTurno_Colaboradores null, null, null

EXEC spEliminarColaborador 4

EXEC spConsultar_FechaHora_Colaboradores '2026-09-07', '2026-09-07', '15:00', '19:00'


EXEC sp_help 'tblColaboradores'
EXEC sp_help 'tblnivelEducativo'
EXEC sp_help 'tblturnoTrabajo'