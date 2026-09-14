/*
P07R01_PruebaTecnica_AEHM
AUTOR: ADRIAN ELEUTERIO HERNANDEZ MARTINEZ
 FECHA: 07/09/2026
*/

USE BIOMETRICO;
GO

--===================
	--CREATE TABLES
--===================
BEGIN TRANSACTION
	BEGIN TRY
		--VALIDACIONES
		IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'tblnivelEducativo' 
		AND TABLE_SCHEMA = 'dbo')
		BEGIN
			--TABLA tblnivelEducativo
			CREATE TABLE tblnivelEducativo(
				idnivelEducativo INT PRIMARY KEY IDENTITY(1,1),
				nivel VARCHAR(20)
			)
			PRINT 'Tabla tblnivelEducativo creada correctamente'
		END
		ELSE
		BEGIN
			PRINT 'La tabla tblNivelEducativo ya existe'
		END
		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT >0
			ROLLBACK TRANSACTION;
		THROW;
	END CATCH
GO

BEGIN TRANSACTION
	BEGIN TRY
		--VALIDACIONES
		IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'tblturnoTrabajo' 
		AND TABLE_SCHEMA = 'dbo')
		BEGIN
			--TABLA tblturnoTrabajo
			CREATE TABLE tblturnoTrabajo(
				idTurno INT PRIMARY KEY IDENTITY(1,1),
				tipoTurno VARCHAR(20)
			)
			PRINT 'Tabla tblturnoTrabajo creada correctamente'
		END
		ELSE
		BEGIN
			PRINT 'La tabla tblturnoTrabajo ya existe'
		END
		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT >0
			ROLLBACK TRANSACTION;
		THROW;
	END CATCH
GO

BEGIN TRANSACTION
	BEGIN TRY
		--VALIDACIONES
		IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'tblColaboradores' 
		AND TABLE_SCHEMA = 'dbo')
		BEGIN
			--TABLA tblColaboradores
			CREATE TABLE tblColaboradores(
				idColaborador INT PRIMARY KEY IDENTITY(1,1),
				nombres VARCHAR(60) NOT NULL,
				apellidoPaterno VARCHAR(60) NOT NULL,
				apellidoMaterno VARCHAR(60) NOT NULL,
				fechaNacimiento DATE NOT NULL,
				idnivelEducativo INT FOREIGN KEY REFERENCES tblnivelEducativo(idnivelEducativo),
				numeroCelular VARCHAR(10) NOT NULL,
				estatus BIT DEFAULT 1,
				registro DATETIME DEFAULT GETDATE(),
				fechaIngreso DATE NOT NULL,
				idTurno INT FOREIGN KEY REFERENCES tblturnoTrabajo(idTurno),
				horaEntrada TIME NOT NULL,
				horaSalida TIME NOT NULL,
				horasLaboradasPorDia DECIMAL(10,2) NOT NULL
			)
			PRINT 'Tabla tblColaboradores creada correctamente'
		END
		ELSE
		BEGIN
			PRINT 'La tabla tblColaboradores ya existe'
		END
		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT >0
			ROLLBACK TRANSACTION;
		THROW;
	END CATCH
GO