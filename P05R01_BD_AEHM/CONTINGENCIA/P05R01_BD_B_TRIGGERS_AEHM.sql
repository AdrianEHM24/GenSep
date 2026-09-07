USE GenSep
GO

/*05
 P05R01_BD_AEHM
 AUTOR: ADRIAN ELEUTERIO HERNANDEZ MARTINEZ
 FECHA: 03/09/2026
*/

--=============================
-- CONTINGENCIA DE TRIGGERS
--=============================
--COMMIT Y ROLLBACK
BEGIN TRANSACTION;
	BEGIN TRY
		--VALIDACIONES
		IF EXISTS(
			SELECT 1 
			FROM sys.objects
			WHERE name = 'TR_AuditarCambioPrecio'
				AND type = 'TR'
				AND SCHEMA_NAME(schema_id) = 'dbo'
		)
			BEGIN
				--ELIMINA R: TRIGGER TR_AuditarCambioPrecio;
				DROP TRIGGER dbo.TR_AuditarCambioPrecio;
				PRINT 'TRIGGER TR_AuditarCambioPrecio eliminado correctamente.';
			END
		ELSE
			BEGIN
				PRINT 'El trigger [dbo.][TR_AuditarCambioPrecio] no existe.'
			END
		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;
		THROW;
	END CATCH
GO

--COMMIT Y ROLLBACK
BEGIN TRANSACTION;
	BEGIN TRY
		--VALIDACIONES
		IF EXISTS(
			SELECT 1 
			FROM sys.objects
			WHERE name = 'TR_Auditoria_After_Insert'
				AND type = 'TR'
				AND SCHEMA_NAME(schema_id) = 'dbo'
		)
			BEGIN
				--ELIMINA R: TRIGGER TR_Auditoria_After_Insert;
				DROP TRIGGER dbo.TR_Auditoria_After_Insert;
				PRINT 'TRIGGER TR_Auditoria_After_Insert eliminado correctamente.';
			END
		ELSE
			BEGIN
				PRINT 'El trigger [dbo.][TR_Auditoria_After_Insert] no existe.'
			END
		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;
		THROW;
	END CATCH
GO

--COMMIT Y ROLLBACK
BEGIN TRANSACTION;
	BEGIN TRY
		--VALIDACIONES
		IF EXISTS(
			SELECT 1 
			FROM sys.objects
			WHERE name = 'TR_Auditoria_Instead_Insert'
				AND type = 'TR'
				AND SCHEMA_NAME(schema_id) = 'dbo'
		)
			BEGIN
				--ELIMINA R: TRIGGER TR_Auditoria_Instead_Insert;
				DROP TRIGGER dbo.TR_Auditoria_Instead_Insert;
				PRINT 'TRIGGER TR_Auditoria_Instead_Insert eliminado correctamente.';
			END
		ELSE
			BEGIN
				PRINT 'El trigger [dbo.][TR_Auditoria_Instead_Insert] no existe.'
			END
		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;
		THROW;
	END CATCH
GO

--COMMIT Y ROLLBACK
BEGIN TRANSACTION;
	BEGIN TRY
		--VALIDACIONES
		IF EXISTS(
			SELECT 1 
			FROM sys.objects
			WHERE name = 'TR_Auditoria_Instead_Update'
				AND type = 'TR'
				AND SCHEMA_NAME(schema_id) = 'dbo'
		)
			BEGIN
				--ELIMINA R: TRIGGER TR_Auditoria_Instead_Update;
				DROP TRIGGER dbo.TR_Auditoria_Instead_Update;
				PRINT 'TRIGGER TR_Auditoria_Instead_Update eliminado correctamente.';
			END
		ELSE
			BEGIN
				PRINT 'El trigger [dbo.][TR_Auditoria_Instead_Update] no existe.'
			END
		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;
		THROW;
	END CATCH
GO

--COMMIT Y ROLLBACK
BEGIN TRANSACTION;
	BEGIN TRY
		--VALIDACIONES
		IF EXISTS(
			SELECT 1 
			FROM sys.objects
			WHERE name = 'TR_Auditoria_After_Delete'
				AND type = 'TR'
				AND SCHEMA_NAME(schema_id) = 'dbo'
		)
			BEGIN
				--ELIMINA R: TRIGGER TR_Auditoria_After_Delete;
				DROP TRIGGER dbo.TR_Auditoria_After_Delete;
				PRINT 'TRIGGER TR_Auditoria_After_Delete eliminado correctamente.';
			END
		ELSE
			BEGIN
				PRINT 'El trigger [dbo.][TR_Auditoria_After_Delete] no existe.'
			END
		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;
		THROW;
	END CATCH
GO

--COMMIT Y ROLLBACK
BEGIN TRANSACTION;
	BEGIN TRY
		--VALIDACIONES
		IF EXISTS(
			SELECT 1 
			FROM sys.objects
			WHERE name = 'TR_Auditoria_Instead_Delete'
				AND type = 'TR'
				AND SCHEMA_NAME(schema_id) = 'dbo'
		)
			BEGIN
				--ELIMINA R: TRIGGER TR_Auditoria_Instead_Delete;
				DROP TRIGGER dbo.TR_Auditoria_Instead_Delete;
				PRINT 'TRIGGER TR_Auditoria_Instead_Delete eliminado correctamente.';
			END
		ELSE
			BEGIN
				PRINT 'El trigger [dbo.][TR_Auditoria_Instead_Delete] no existe.'
			END
		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;
		THROW;
	END CATCH
GO