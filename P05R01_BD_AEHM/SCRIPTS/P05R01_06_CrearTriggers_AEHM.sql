USE GenSep
GO

/*05
 P05R01_BD_AEHM
 AUTOR: ADRIAN ELEUTERIO HERNANDEZ MARTINEZ
 FECHA: 03/09/2026
*/

--=============================
-- CREACIÓN DE TRIGGERS
--=============================
--Crear trigger
CREATE OR ALTER TRIGGER TR_AuditarCambioPrecio
ON Productos --Nombre de la tabla a auditar
AFTER UPDATE
AS
BEGIN
	IF UPDATE(Precio)
	BEGIN
		INSERT INTO AuditoriaProductos
			(ProductoID, Accion, PrecioAnterior, PrecioNuevo, Usuario)
		SELECT
			d.ProductoID,
			'UPDATE',
			d.Precio,
			i.Precio,
			SYSTEM_USER
		FROM deleted AS d --inserted → contiene las filas nuevas que se insertaron o actualizaron.
						  --deleted → contiene las filas que se eliminaron o que fueron reemplazadas por una actualización.
		INNER JOIN inserted i ON d.ProductoID = i.ProductoID;
	END
END;
GO

CREATE OR ALTER TRIGGER TR_Auditoria_After_Insert
ON Productos --Nombre de la tabla a auditar
AFTER INSERT
AS
BEGIN
		INSERT INTO AuditoriaProductos
			(ProductoID, Accion, PrecioAnterior, PrecioNuevo, Usuario)
		SELECT
			i.ProductoID,
			'INSERT',
			NULL,
			i.Precio,
			SYSTEM_USER
		FROM inserted i;
END;
GO

--BEFORE INSERT (SQL SERVER = INSTEAD OF INSERT)
CREATE OR ALTER TRIGGER TR_Auditoria_Instead_Insert
ON Productos --Nombre de la tabla a auditar
INSTEAD OF INSERT
AS
BEGIN
		INSERT INTO AuditoriaProductos
			(ProductoID, Accion, PrecioAnterior, PrecioNuevo, Usuario)
		SELECT
			ProductoID,
			'INSERT',
			NULL,
			Precio,
			SYSTEM_USER
		FROM inserted;

		INSERT INTO Productos(Nombre, Categoria, Precio,Stock)
		SELECT Nombre, Categoria, Precio, Stock
		FROM inserted;
END;
GO
--INSERT INTO Productos(Nombre, Categoria, Precio, Stock)
--Values ('Cuernito', 'panaderia', 20, 35)

--Select * from AuditoriaProductos

--BEFORE UPDATE (SQL SERVER = INSTEAD OF UPDATE)
CREATE OR ALTER TRIGGER TR_Auditoria_Instead_Update
ON Productos --Nombre de la tabla a auditar
INSTEAD OF UPDATE
AS
BEGIN
	INSERT INTO AuditoriaProductos
			(ProductoID, Accion, PrecioAnterior, PrecioNuevo, Usuario)
	SELECT
			d.ProductoID,
			'UPDATE',
			d.Precio,
			i.Precio,
			SYSTEM_USER
	FROM deleted AS d --inserted → contiene las filas nuevas que se insertaron o actualizaron.
						  --deleted → contiene las filas que se eliminaron o que fueron reemplazadas por una actualización.
	INNER JOIN inserted i ON d.ProductoID = i.ProductoID;

	UPDATE p
	SET 
		p.Nombre = i.Nombre,
		p.Precio = i.Precio
	FROM Productos p
	INNER JOIN inserted i ON p.ProductoID = i.ProductoID;
END;
GO

CREATE OR ALTER TRIGGER TR_Auditoria_After_Delete
ON Productos --Nombre de la tabla a auditar
AFTER DELETE
AS
BEGIN
		INSERT INTO AuditoriaProductos
			(ProductoID, Accion, PrecioAnterior, PrecioNuevo, Usuario)
		SELECT
			d.ProductoID,
			'DELETE',
			d.Precio,
			NULL,
			SYSTEM_USER
		FROM deleted d;
END;
GO

--BEFORE DELETE (SQL SERVER = INSTEAD OF DELETE)
CREATE OR ALTER TRIGGER TR_Auditoria_Instead_Delete
ON Productos --Nombre de la tabla a auditar
INSTEAD OF DELETE
AS
BEGIN
		INSERT INTO AuditoriaProductos
			(ProductoID, Accion, PrecioAnterior, PrecioNuevo, Usuario)
		SELECT
			ProductoID,
			'DELETE',
			Precio,
			NULL,
			SYSTEM_USER
		FROM deleted;

		DELETE p 
		FROM Productos p
		INNER JOIN deleted d --tabla temporal
			ON p.ProductoID = d.ProductoID;
END;
GO