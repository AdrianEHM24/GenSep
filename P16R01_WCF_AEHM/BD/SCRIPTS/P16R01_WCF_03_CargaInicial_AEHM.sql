/*
 P10R01_WS_AEHM
 AUTOR: ADRIAN ELEUTERIO HERNANDEZ MARTINEZ
 FECHA: 11/09/2026
*/

USE BD_Ejemplo
GO

--=============================
-- CARGA INICIAL
--=============================

BEGIN TRANSACTION
	BEGIN TRY
			INSERT INTO Usuarios (Nombre)
			VALUES ('Juan Pérez'), 
					('Maria Garcia'), 
					('Carlos Lopez'), 
					('Ana Martínez'), 
					('Pedro Sanchez') 
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION
		THROW;
	END CATCH
GO

SELECT * FROM Usuarios