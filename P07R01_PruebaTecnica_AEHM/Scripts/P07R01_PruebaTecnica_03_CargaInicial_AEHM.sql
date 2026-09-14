/*
P07R01_PruebaTecnica_AEHM
AUTOR: ADRIAN ELEUTERIO HERNANDEZ MARTINEZ
 FECHA: 07/09/2026
*/

USE BIOMETRICO
GO

--===================
	--CARGA INICIAL
--===================


--INSERT INTO tblnivelEducativo 
--VALUES ('Primaria'),
--		('Secundaria'),
--		('Bachillerato'),
--		('Licenciatura'),
--		('Posgrado')
--GO

BEGIN TRY
	BEGIN TRANSACTION;

	IF EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tblnivelEducativo' AND TABLE_SCHEMA = 'dbo')
	BEGIN

		IF NOT EXISTS(SELECT 1 FROM tblnivelEducativo WHERE nivel = 'Primaria')
		BEGIN
			INSERT INTO tblnivelEducativo VALUES ('Primaria')
		END
		ELSE PRINT('Ya Existe un registro con ese nivel');
		IF NOT EXISTS(SELECT 1 FROM tblnivelEducativo WHERE nivel = 'Secundaria')
		BEGIN
			INSERT INTO tblnivelEducativo VALUES ('Secundaria')
		END
		ELSE PRINT('Ya Existe un registro con ese nivel');
		IF NOT EXISTS(SELECT 1 FROM tblnivelEducativo WHERE nivel = 'Bachillerato')
		BEGIN
			INSERT INTO tblnivelEducativo VALUES ('Bachillerato')
		END
		ELSE PRINT('Ya Existe un registro con ese nivel');
		IF NOT EXISTS(SELECT 1 FROM tblnivelEducativo WHERE nivel = 'Licenciatura')
		BEGIN
			INSERT INTO tblnivelEducativo VALUES ('Licenciatura')
		END
		ELSE PRINT('Ya Existe un registro con ese nivel');
		IF NOT EXISTS(SELECT 1 FROM tblnivelEducativo WHERE nivel = 'Posgrado')
		BEGIN
			INSERT INTO tblnivelEducativo VALUES ('Posgrado')
		END
		ELSE PRINT('Ya Existe un registro con ese nivel');

	END
	ELSE PRINT 'No existe la tabla tblnivelEducativo'

	COMMIT TRANSACTION;
END TRY
BEGIN CATCH

	IF @@TRANCOUNT > 0
		ROLLBACK TRANSACTION;

	PRINT 'Hubo un error ' + ERROR_MESSAGE();

END CATCH
GO

BEGIN TRY
	BEGIN TRANSACTION;

	IF EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tblturnoTrabajo' AND TABLE_SCHEMA = 'dbo')
	BEGIN

		IF NOT EXISTS(SELECT 1 FROM tblturnoTrabajo WHERE tipoTurno = 'Matutino')
		BEGIN
			INSERT INTO tblturnoTrabajo VALUES ('Matutino')
		END
		ELSE PRINT('Ya Existe un registro con ese tipo de Turno');
		IF NOT EXISTS(SELECT 1 FROM tblturnoTrabajo WHERE tipoTurno = 'Vespertino')
		BEGIN
			INSERT INTO tblturnoTrabajo VALUES ('Vespertino')
		END
		ELSE PRINT('Ya Existe un registro con ese tipo de Turno');
		IF NOT EXISTS(SELECT 1 FROM tblturnoTrabajo WHERE tipoTurno = 'Nocturno')
		BEGIN
			INSERT INTO tblturnoTrabajo VALUES ('Nocturno')
		END
		ELSE PRINT('Ya Existe un registro con ese tipo de Turno');

	END
	ELSE PRINT 'No existe la tabla tblturnoTrabajo'

	COMMIT TRANSACTION;
END TRY
BEGIN CATCH

	IF @@TRANCOUNT > 0
		ROLLBACK TRANSACTION;

	PRINT 'Hubo un error ' + ERROR_MESSAGE();

END CATCH
GO

--INSERT INTO tblturnoTrabajo
--VALUES ('Matutino'),
--		('Vespertino'),
--		('Nocturno')
--GO

INSERT INTO tblColaboradores (
	   [nombres]
      ,[apellidoPaterno]
      ,[apellidoMaterno]
      ,[fechaNacimiento]
      ,[idnivelEducativo]
      ,[numeroCelular]
      ,[estatus]
      ,[registro]
      ,[fechaIngreso]
      ,[idTurno]
      ,[horaEntrada]
      ,[horaSalida]
      ,[horasLaboradasPorDia]
	  )
VALUES (
	   'Leonardo'
      ,'Zamudio'
      ,'Gonzalez'
      ,'1985-12-21'
      ,4
      ,'7821343961'
      ,1
      ,GETDATE()
      ,'2026-01-01'
      ,1
      ,GETDATE()
      ,GETDATE()
      ,8
	  )
GO