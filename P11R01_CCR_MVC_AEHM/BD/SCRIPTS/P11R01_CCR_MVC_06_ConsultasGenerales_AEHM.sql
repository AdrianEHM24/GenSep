/*
 P09R01_CCR_NCAPAS_AEHM
 AUTOR: ADRIAN ELEUTERIO HERNANDEZ MARTINEZ
 FECHA: 09/09/2026
*/

USE GenSepCCR;
GO
--=============================
-- CONSULTAS GENERALES
--=============================
SELECT * FROM Camiones
SELECT * FROM Camiones order by TipoCamion
SELECT * FROM Rutas
SELECT * FROM Choferes
SELECT TOP 10 * FROM [dbo].[Camiones]
SELECT TOP 10 * FROM [dbo].[Choferes]
SELECT TOP 10 * FROM [dbo].[Rutas]

----VISTAS-----

SELECT TOP (10) [IdCamion]
      ,[Matricula]
      ,[TipoCamion]
      ,[Modelo]
      ,[Marca]
      ,[Capacidad]
      ,[Kilometraje]
      ,[UrlFoto]
  FROM [GenSepCCR].[dbo].[VWCamiones]

  SELECT TOP (10) [IdChofer]
      ,[Nombre]
      ,[ApPaterno]
      ,[ApMaterno]
      ,[Telefono]
      ,[FechaNacimiento]
      ,[Licencia]
      ,[UrlFoto]
      ,[FechaRegistro]
  FROM [GenSepCCR].[dbo].[VWChoferes]

  SELECT TOP (10) [Idruta]
      ,[IdChofer]
      ,[IdCamion]
      ,[Origen]
      ,[Destino]
      ,[FechaSalida]
      ,[FechaLlegada]
      ,[Distancia]
      ,[FechaRegistro]
  FROM [GenSepCCR].[dbo].[VWRutas]

-------EJECUTAR SPs-------
-----SPs Camiones---------
EXEC Insert_Camion 'EFG321', 'Refrigerado', 2024, 'Volvo', 19000, 25000, 1, 'https://picsum.photos/200?truck11'

EXEC Select_Camion 'EFG321'

EXEC Update_Camion 11, 'EFG321', 'Trailer ', 2024, 'Volvo', 19000, 25000, 1, 'https://picsum.photos/200?truck11'

EXEC Delete_Camion 11

 -----SPs Choferes---------
EXEC Insert_Choferes 'Julian', 'Navarro', 'Jiménez', '5561234567', '1986-05-12', 'LIC899', 'https://picsum.photos/200?driver11', 1

EXEC Select_Chofer 1

EXEC Update_Choferes 11, 'Samuel', 'Navarro', 'Jimenez', '5561234567', '1986-05-12', 'LIC999', 'https://picsum.photos/200?driver11', 1

EXEC Delete_Chofer 11

----SPs Rutas--------
EXEC Insert_Rutas 12, 12, 'Ciudad de México', 'Monterrey', '2026-09-11 06:00', '2026-09-11 18:00', 1, 910

EXEC Select_Rutas 11

EXEC Update_Rutas 11, 12, 12, 'CDMX', 'Monterrey', '2026-09-11 06:00', '2026-09-11 18:00', 1, 910

EXEC Delete_Ruta 11

-----SPs Especiales-------
EXEC Select_Rutas_Detalle 
EXEC Existe_Licencia 'LIC123'
EXEC Obtener_Camion_ID 10
EXEC Existe_Matricula EFG321
EXEC Listar_Camiones 1