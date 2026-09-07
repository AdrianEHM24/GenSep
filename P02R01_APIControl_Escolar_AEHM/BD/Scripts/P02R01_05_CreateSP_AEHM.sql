/*
 P02R01_APIControl_Escolar_AEHM
 AUTOR: ADRIAN ELEUTERIO HERNANDE
 FECHA: 04/09/2026
*/

--=============================
-- CREACIÓN DE SP
--=============================
USE Control_Escolar;
GO

CREATE OR ALTER PROCEDURE spAlumno
@Nombre VARCHAR (50), @Direccion VARCHAR (50), @Apellido_Paterno VARCHAR (50),
@Apellido_Materno VARCHAR (50), @Correo VARCHAR (100), @Telefono INT
AS
BEGIN
INSERT INTO tblAlumnos(Nombre, Direccion, Apellido_Paterno, Apellido_Materno, Correo, Telefono)
VALUES(@Nombre, @Direccion, @Apellido_Paterno, @Apellido_Materno, @Correo, @Telefono)
END
GO