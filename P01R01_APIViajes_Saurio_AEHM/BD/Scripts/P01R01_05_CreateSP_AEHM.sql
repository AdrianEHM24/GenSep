/*
 P01R01_APIViajes_Saurio_AEHM
 AUTOR: ADRIAN ELEUTERIO HERNANDEZ MARTINEZ
 FECHA: 04/09/2026
*/

--=============================
-- CREACIÓN DE SPs
--=============================
USE TURISMO;
GO

CREATE OR ALTER PROCEDURE spDestino 
@Nombre NVARCHAR (50), @Direccion NVARCHAR (50), @Descripcion NVARCHAR (100)
AS
BEGIN
INSERT INTO tblDestino(Nombre, Direccion, Descripcion)
VALUES(@Nombre, @Direccion, @Descripcion)
END
GO