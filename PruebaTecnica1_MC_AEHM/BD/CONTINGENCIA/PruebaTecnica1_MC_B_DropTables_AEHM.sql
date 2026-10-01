USE SistemaLoginMC
GO

/*
PruebaTecnica1_MC_AEHM
AUTOR:Adrián Eleuterio Hernández Martínez
FECHA:21/09/2026
*/

-- =============================================
-- DROP TABLES
-- =============================================

--COMMIT Y ROLLBACK
BEGIN TRANSACTION;
    BEGIN TRY
        --VALIDACIONES - Eliminar en orden inverso de dependencias
        
        --TABLA: tblDocumentos
        IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tblDocumentos'
                        AND TABLE_SCHEMA = 'dbo')
            BEGIN
                DROP TABLE dbo.tblDocumentos;
                PRINT 'Tabla tblDocumentos eliminada correctamente.';
            END

			COMMIT TRANSACTION; -- Confirmar cambios
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
        --VALIDACIONES - Eliminar en orden inverso de dependencias
        
        --TABLA: tblConfiguracionImpresion
        IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tblConfiguracionImpresion'
                        AND TABLE_SCHEMA = 'dbo')
            BEGIN
                DROP TABLE dbo.tblConfiguracionImpresion;
                PRINT 'Tabla tblConfiguracionImpresion eliminada correctamente.';
            END

			COMMIT TRANSACTION; -- Confirmar cambios
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
        --VALIDACIONES - Eliminar en orden inverso de dependencias
        
        --TABLA: tblUsuarios
        IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tblUsuarios'
                        AND TABLE_SCHEMA = 'dbo')
            BEGIN
                DROP TABLE dbo.tblUsuarios;
                PRINT 'Tabla tblUsuarios eliminada correctamente.';
            END

			COMMIT TRANSACTION; -- Confirmar cambios
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;
        THROW;
    END CATCH
GO