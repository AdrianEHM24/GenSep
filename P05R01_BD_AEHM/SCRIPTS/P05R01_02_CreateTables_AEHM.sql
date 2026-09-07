USE GenSep
GO

/*05
 P05R01_BD_AEHM
 AUTOR: ADRIAN ELEUTERIO HERNANDEZ MARTINEZ
 FECHA: 03/09/2026
*/

--=============================
-- CREACIÓN DE TABLAS
--=============================
--COMMIT Y ROLLBACK
BEGIN TRANSACTION;
	BEGIN TRY
		--VALIDACIONES
		IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Productos' AND TABLE_SCHEMA = 'dbo')
			BEGIN
			--TABLA Productos
				CREATE TABLE Productos(
				ProductoID INT PRIMARY KEY IDENTITY(1,1),
				Nombre NVARCHAR(100) NOT NULL,
				Categoria NVARCHAR(50) NOT NULL,
				Precio Decimal(10,2) NOT NULL,
				Stock INT DEFAULT 0,
				FechaCreacion DATETIME DEFAULT GETDATE()
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

--COMMIT Y ROLLBACK
BEGIN TRANSACTION;
	BEGIN TRY
	--VALIDACIONES
		IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Clientes' AND TABLE_SCHEMA = 'dbo')
			BEGIN
			--TABLA Clientes
				CREATE TABLE Clientes(
				ClienteID INT PRIMARY KEY IDENTITY(1,1),
				Nombre NVARCHAR(100) NOT NULL,
				Email NVARCHAR(100),
				Telefono NVARCHAR(15)
				);
				PRINT 'Tabla Clientes fue creada correctamente';
			END
		ELSE
			BEGIN
				PRINT 'La tabla [dbo].[Clientes] ya existe';
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
		IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Pedidos' AND TABLE_SCHEMA = 'dbo')
			BEGIN
			--TABLA Pedidos
				CREATE TABLE Pedidos(
				PedidoID INT PRIMARY KEY IDENTITY(1,1),
				ClienteID INT FOREIGN KEY REFERENCES Clientes(ClienteID),
				Fecha DATETIME DEFAULT GETDATE(),
				Total DECIMAL(10,2),
				Estado NVARCHAR(20) DEFAULT 'Pendiente'
				);
				PRINT 'Tabla Pedidos fue creada correctamente';
			END
		ELSE
			BEGIN
				PRINT 'La tabla [dbo].[Pedidos] ya existe';
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
		IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'DetallesPedido' AND TABLE_SCHEMA = 'dbo')
			BEGIN
			--TABLA DetallesPedido Con Foreign Key
				CREATE TABLE DetallesPedido(
				DetalleID INT PRIMARY KEY IDENTITY(1,1),
				PedidoID INT FOREIGN KEY REFERENCES Pedidos(PedidoID),
				ProductoID INT FOREIGN KEY REFERENCES Productos(ProductoID),
				Cantidad INT NOT NULL,
				PrecioUnitario DECIMAL(10,2) NOT NULL
				);
				--Agregar Foreign Key a tabla existente
				--ALTER TABLE Pedidos
				--ADD CONSTRAINT FK_Pedidos_Clientes
				--FOREIGN KEY (ClienteID) REFERENCES Clientes(ClienteID)
				PRINT 'Tabla DetallesPedido fue creada correctamente';
			END
		ELSE
			BEGIN
				PRINT 'La tabla [dbo].[DetallesPedido] ya existe';
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
		IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AuditoriaProductos' AND TABLE_SCHEMA = 'dbo')
			BEGIN
			--TABLA AuditoriaProductos
				CREATE TABLE AuditoriaProductos(
				AuditoriaID INT PRIMARY KEY IDENTITY(1,1),
				ProductoID INT,
				Accion NVARCHAR(20),
				PrecioAnterior DECIMAL(10,2),
				PrecioNuevo DECIMAL(10,2),
				Usuario NVARCHAR(100),
				Fecha DATETIME DEFAULT GETDATE()
				);
				PRINT 'Tabla AuditoriaProductos fue creada correctamente';
			END
		ELSE
			BEGIN
				PRINT 'La tabla [dbo].[AuditoriaProductos] ya existe';
			END
		COMMIT TRANSACTION; --CONFIRMAR CAMBIOS
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT >0
			ROLLBACK TRANSACTION;
		THROW;
	END CATCH
GO