USE SistemaLoginMC;
GO

/*
PruebaTecnica1_MC_AEHM
AUTOR:Adrián Eleuterio Hernández Martínez
FECHA:21/09/2026
*/

-- =============================================
-- CREACIÓN  DE TABLAS 
-- =============================================

--COMMIT Y ROLLBACK
BEGIN TRANSACTION;
    BEGIN TRY
        --VALIDACIONES
        IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tblUsuarios'
                            AND TABLE_SCHEMA = 'dbo')
            BEGIN

					-- Tabla de Usuarios
					CREATE TABLE tblUsuarios (
					Id INT PRIMARY KEY IDENTITY(1,1),
					NombreUsuario NVARCHAR(50) NOT NULL UNIQUE,
					Pass NVARCHAR(255) NOT NULL,
					Nombre NVARCHAR(100) NOT NULL,
					Email NVARCHAR(100) NOT NULL,
					Rol NVARCHAR(20) NOT NULL DEFAULT 'Usuario',
					FechaCreacion DATETIME DEFAULT GETDATE(),
					--Activo BIT DEFAULT 1
					Estatus INT NOT NULL,
					HorarioEntrada DATETIME,
					HorarioSalida DATETIME,
					Contrato NVARCHAR(100),
					Saldos INT DEFAULT 0,
					FechaIngreso DATETIME DEFAULT GETDATE(),
					Telefono NVARCHAR(20) DEFAULT '7821343961'
					);

					 PRINT 'Tabla : tblUsuarios fue creada correctamente.';
            END
        ELSE
            BEGIN
                PRINT 'La tabla [dbo].[tblUsuarios] ya existe.'
            END
        COMMIT TRANSACTION; -- Confirmar cambios
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;
        THROW;
    END CATCH
GO


BEGIN TRANSACTION;
    BEGIN TRY
        --VALIDACIONES
        IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tblDocumentos'
                            AND TABLE_SCHEMA = 'dbo')
            BEGIN

				CREATE TABLE tblDocumentos (
                    Id INT PRIMARY KEY IDENTITY(1,1),
                    Nombre NVARCHAR(150) NULL,
                    Contrato NVARCHAR(100) NULL,
                    Saldos INT NULL DEFAULT 0,
                    Fecha DATETIME NOT NULL DEFAULT GETDATE(),
                    Telefono NVARCHAR(20) NULL   -- ← opcional
                );

					 PRINT 'Tabla : tblDocumentos fue creada correctamente.';
            END
        ELSE
            BEGIN
                PRINT 'La tabla [dbo].[tblDocumentos] ya existe.'
            END
        COMMIT TRANSACTION; -- Confirmar cambios
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;
        THROW;
    END CATCH
GO

BEGIN TRANSACTION;
    BEGIN TRY
        --VALIDACIONES
        IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tblConfiguracionImpresion'
                            AND TABLE_SCHEMA = 'dbo')
            BEGIN

				CREATE TABLE tblConfiguracionImpresion (
                    Id INT PRIMARY KEY IDENTITY(1,1),
                    TamanoHoja NVARCHAR(20) NOT NULL DEFAULT 'A4',
                    TamanoFuente INT NOT NULL DEFAULT 12,
                    TipoFuente NVARCHAR(50) NOT NULL DEFAULT 'Arial',
                    ImagenFondoBase64 NVARCHAR(MAX) NULL,
                    FechaActualizacion DATETIME NOT NULL DEFAULT GETDATE()
                );

					 PRINT 'Tabla : tblConfiguracionImpresion fue creada correctamente.';
            END
        ELSE
            BEGIN
                PRINT 'La tabla [dbo].[tblConfiguracionImpresion] ya existe.'
            END
        COMMIT TRANSACTION; -- Confirmar cambios
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;
        THROW;
    END CATCH
GO

---------------------------------------------------------------------



--GO