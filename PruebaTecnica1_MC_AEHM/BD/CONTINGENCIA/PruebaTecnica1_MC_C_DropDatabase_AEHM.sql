/*
PruebaTecnica1_MC_AEHM
AUTOR:Adrián Eleuterio Hernández Martínez
FECHA:21/09/2026
*/

-- =============================================
-- DROP DATABASE
-- =============================================
BEGIN TRY
    --VALIDACIONES
    IF EXISTS (SELECT 1 FROM sys.databases WHERE name = 'SistemaLoginMC')
        BEGIN
            --ELIMINAR: Base de Datos SistemaLoginMC
            USE master;  -- Asegurarse de no estar dentro de la BD a eliminar

            ALTER DATABASE SistemaLoginMC SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
            DROP DATABASE SistemaLoginMC;

            PRINT 'Base de Datos SistemaLoginMC eliminada correctamente.';
        END
    ELSE
        BEGIN
            PRINT 'La Base de Datos [SistemaLoginMC] no existe.'
        END
END TRY
BEGIN CATCH
    -- Intentar restaurar acceso multi-usuario si algo falló
    IF EXISTS (SELECT 1 FROM sys.databases WHERE name = 'SistemaLoginMC')
        ALTER DATABASE SistemaLoginMC SET MULTI_USER;

    THROW;
END CATCH
GO