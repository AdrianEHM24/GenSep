/*
 P09R01_CCR_NCAPAS_AEHM
 AUTOR: ADRIAN ELEUTERIO HERNANDEZ MARTINEZ
 FECHA: 09/09/2026
*/

USE GenSepCCR;
GO

--=============================
-- CREACIÓN DE VISTAS
--=============================

CREATE OR ALTER VIEW dbo.VWCamiones AS SELECT
	IdCamion,Matricula, TipoCamion, Modelo, Marca, Capacidad, Kilometraje,UrlFoto 
	FROM dbo.Camiones WHERE Disponibilidad = 1;
GO

CREATE OR ALTER VIEW dbo.VWChoferes AS SELECT
	IdChofer, Nombre, ApPaterno, ApMaterno, Telefono, FechaNacimiento, Licencia, UrlFoto, FechaRegistro
	FROM dbo.Choferes WHERE Disponibilidad = 1
GO

CREATE OR ALTER VIEW dbo.VWRutas AS SELECT
	Idruta, IdChofer, IdCamion, Origen, Destino, FechaSalida, FechaLlegada, Distancia, FechaRegistro
	FROM dbo.Rutas WHERE ATiempo = 1
GO