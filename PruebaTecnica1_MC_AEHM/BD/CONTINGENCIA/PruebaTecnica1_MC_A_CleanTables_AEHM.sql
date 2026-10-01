USE SistemaLoginMC
GO

/*
PruebaTecnica1_MC_AEHM
AUTOR:Adrián Eleuterio Hernández Martínez
FECHA:21/09/2026
*/

-- =============================================
-- CLEAN TABLES
-- =============================================

--COMMIT Y ROLLBACK
BEGIN TRANSACTION;
    BEGIN TRY
        --VALIDACIONES
        IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tblDocumentos'
                        AND TABLE_SCHEMA = 'dbo')
            BEGIN
                --ELIMINAR: Datos de tblDocumentos
                
                DELETE FROM dbo.tblDocumentos;

                PRINT 'Datos de la tabla tblDocumentos eliminados correctamente.';
            END
        ELSE
            BEGIN
                PRINT 'La tabla [dbo].[tblDocumentos] no existe.'
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
        --VALIDACIONES
        IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tblConfiguracionImpresion'
                        AND TABLE_SCHEMA = 'dbo')
            BEGIN
                --ELIMINAR: Datos de tblConfiguracionImpresion
                
                DELETE FROM dbo.tblConfiguracionImpresion;

                PRINT 'Datos de la tabla tblConfiguracionImpresion eliminados correctamente.';
            END
        ELSE
            BEGIN
                PRINT 'La tabla [dbo].[tblConfiguracionImpresion] no existe.'
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
        --VALIDACIONES
        IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tblUsuarios'
                        AND TABLE_SCHEMA = 'dbo')
            BEGIN
                --ELIMINAR: Datos de tblUsuarios
                
                DELETE FROM dbo.tblUsuarios;

                PRINT 'Datos de la tabla tblUsuarios eliminados correctamente.';
            END
        ELSE
            BEGIN
                PRINT 'La tabla [dbo].[tblUsuarios] no existe.'
            END
        COMMIT TRANSACTION; -- Confirmar cambios
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;
        THROW;
    END CATCH
GO
