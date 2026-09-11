/*
P07R01_PruebaTecnica_AEHM
AUTOR: ADRIAN ELEUTERIO HERNANDEZ MARTINEZ
 FECHA: 07/09/2026
*/

USE EPP_Inventario
GO

--===================
	--CREATE TABLES
--===================
--COMMIT Y ROLLBACK
BEGIN TRANSACTION;
	BEGIN TRY
		--VALIDACIONES
		IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Categorias' AND TABLE_SCHEMA = 'dbo')
			BEGIN
			--TABLA Categorias
				CREATE TABLE Categorias(
				CategoriaId INT PRIMARY KEY IDENTITY(1,1),
				Nombre NVARCHAR(100) NOT NULL,
				Descripcion NVARCHAR(255) NOT NULL,
				Activo BIT DEFAULT 1,
				FechaCreacion DATETIME DEFAULT GETDATE()
				);
				PRINT 'Tabla Categorias fue creada correctamente';
			END
		ELSE
			BEGIN
				PRINT 'La tabla [dbo].[Categorias] ya existe';
			END
		COMMIT TRANSACTION; --CONFIRMAR CAMBIOS
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
		IF NOT EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'Productos' AND TABLE_SCHEMA = 'dbo')
			BEGIN
			--TABLA Productos
				CREATE TABLE Productos(
				ProductoId INT PRIMARY KEY IDENTITY(1,1),
				CategoriaId INT NOT NULL,
				Codigo NVARCHAR(20) NOT NULL UNIQUE,
				Nombre NVARCHAR(150) NOT NULL,
				Descripcion NVARCHAR(500),
				Marca NVARCHAR(100),
				Talla NVARCHAR(20),
				StockActual INT DEFAULT 0,
				StockMinimo INT DEFAULT 5,
				Precio DECIMAL(10,2),
				Activo BIT DEFAULT 1,
				FechaCreacion DATETIME DEFAULT GETDATE(),
				CONSTRAINT FK_Productos_Categorias
					FOREIGN KEY (CategoriaId) REFERENCES Categorias(CategoriaId)
				);
				PRINT 'Tabla Productos fue creada correctamente';
			END
		ELSE
			BEGIN
				PRINT 'La tabla [dbo].[Productos] ya existe';
			END
	COMMIT TRANSACTION; --CONFIRMAR CAMBIOS
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT >0
			ROLLBACK TRANSACTION;
		THROW;
	END CATCH
GO
