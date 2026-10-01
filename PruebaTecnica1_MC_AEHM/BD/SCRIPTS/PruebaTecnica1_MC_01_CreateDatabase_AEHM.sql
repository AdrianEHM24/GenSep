/*
PruebaTecnica1_MC_AEHM
AUTOR:Adrián Eleuterio Hernández Martínez
FECHA:21/09/2026
*/

-- =============================================
-- CREACIÓN DE LA BASE DE DATOS
-- =============================================
IF NOT EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'SistemaLoginMC')
BEGIN
    CREATE DATABASE SistemaLoginMC;
    PRINT 'Base de datos SistemaLoginMC creada correctamente.';
END
ELSE
BEGIN
    PRINT 'La base de datos SistemaLoginMC ya existe.';
END
GO