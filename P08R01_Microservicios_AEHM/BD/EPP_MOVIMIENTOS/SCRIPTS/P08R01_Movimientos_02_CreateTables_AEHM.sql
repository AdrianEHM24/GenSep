/*
P08R01_MICROSERVICIOS_AEHM
AUTOR: ADRIAN ELEUTERIO HERNANDEZ MARTINEZ
 FECHA: 08/09/2026
*/

USE EPP_Movimientos;
GO

--===================
	--CREATE TABLES
--===================
--COMMIT Y ROLLBACK
BEGIN TRANSACTION;
	BEGIN TRY
		--VALIDACIONES
		IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Empleados' AND TABLE_SCHEMA = 'dbo')
			BEGIN
			--TABLA Empleados
				CREATE TABLE Empleados(
				EmpleadoId INT PRIMARY KEY IDENTITY(1,1),
				NumEmpleado NVARCHAR(20) NOT NULL UNIQUE,
				Nombre NVARCHAR(100) NOT NULL,
				Apellidos NVARCHAR(150) NOT NULL,
				Departamento NVARCHAR(100),
				Puesto NVARCHAR(100),
				Activo BIT DEFAULT 1,
				FechaAlta DATETIME DEFAULT GETDATE()
				);
				PRINT 'Tabla Empleados fue creada correctamente';
			END
		ELSE
			BEGIN
				PRINT 'La tabla [dbo].[Empleados] ya existe';
			END
		COMMIT TRANSACTION; --CONFIRMAR CAMBIOS
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT >0
			ROLLBACK TRANSACTION;
		THROW;
	END CATCH
GO

--COMMIT Y ROLLBACK
BEGIN TRANSACTION;
	BEGIN TRY
		--VALIDACIONES
		IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Movimientos' AND TABLE_SCHEMA = 'dbo')
			BEGIN
			--TABLA Movimientos
				CREATE TABLE Movimientos(
				MovimientoId INT PRIMARY KEY IDENTITY(1,1),
				TipoMovimiento NVARCHAR(20) NOT NULL,   --'Entrada' o 'Salida'
				ProductoId INT NOT NULL,				-- Referencia lógica (no FK)
				ProductoNombre NVARCHAR(150) NOT NULL,  -- Se guarda del nombre por si cambia
				EmpleadoId INT,							-- NULL si es entrada de almacén
				Cantidad INT NOT NULL,
				Motivo NVARCHAR(255),
				FechaMovimiento DATETIME DEFAULT GETDATE(),
				RegistradoPor NVARCHAR(100),
				CONSTRAINT FK_Movimientos_Empleados
					FOREIGN KEY (EmpleadoId) REFERENCES Empleados(EmpleadoId)
				);
				PRINT 'Tabla Movimientos fue creada correctamente';
			END
		ELSE
			BEGIN
				PRINT 'La tabla [dbo].[Movimientos] ya existe';
			END
		COMMIT TRANSACTION; --CONFIRMAR CAMBIOS
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT >0
			ROLLBACK TRANSACTION;
		THROW;
	END CATCH
GO