/*
P07R01_PruebaTecnica_AEHM
AUTOR: ADRIAN ELEUTERIO HERNANDEZ MARTINEZ
 FECHA: 07/09/2026
*/

USE BIOMETRICO
GO

--===================
--CREAR SPs
--===================
CREATE OR ALTER PROCEDURE spInsert_Colaboradores
(
	@nombres VARCHAR(60),
    @apellidoPaterno VARCHAR(60),
    @apellidoMaterno VARCHAR(60),
    @fechaNacimiento DATE,
    @idnivelEducativo INT,
    @numeroCelular VARCHAR(10),
    @estatus    BIT,
    @registro   DATETIME,
    @fechaIngreso DATE,
    @idTurno    INT,
    @horaEntrada TIME,
    @horaSalida  TIME,
    @horasLaboradasPorDia DECIMAL(10,2)
)
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRANSACTION;
        IF NOT EXISTS(SELECT 1 FROM tblColaboradores WHERE CAST(registro AS DATE) = CAST(@registro AS DATE) AND idTurno = @idTurno AND 
        CONCAT(Nombres, apellidoPaterno, apellidoMaterno) = CONCAT(@Nombres, @apellidoPaterno, @apellidoMaterno))
        BEGIN
            INSERT INTO tblColaboradores
            VALUES (
                 @nombres
                ,@apellidoPaterno
                ,@apellidoMaterno
                ,@fechaNacimiento
                ,@idnivelEducativo
                ,@numeroCelular
                ,@estatus
                ,@registro
                ,@fechaIngreso
                ,@idTurno
                ,@horaEntrada
                ,@horaSalida
                ,@horasLaboradasPorDia
            )
        END
        ELSE PRINT 'Ese colaborador ' + @Nombres +' '+ @apellidoPaterno+' '+ @apellidoMaterno +' ya tiene ese turno ese día' ;
        COMMIT TRANSACTION;
        END TRY
        BEGIN CATCH
            IF @@TRANCOUNT >0
			ROLLBACK TRANSACTION;
		THROW;
        END CATCH
END
GO

--UPDATE Colaborador
CREATE OR ALTER PROCEDURE spUpdate_Colaboradores
(
    @idColaborador int,
	@nombres VARCHAR(60),
    @apellidoPaterno VARCHAR(60),
    @apellidoMaterno VARCHAR(60),
    @fechaNacimiento DATE,
    @idnivelEducativo INT,
    @numeroCelular VARCHAR(10),
    @estatus    BIT,
    @registro   DATETIME,
    @fechaIngreso DATE,
    @idTurno    INT,
    @horaEntrada TIME,
    @horaSalida  TIME,
    @horasLaboradasPorDia DECIMAL(10,2)
)
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRANSACTION;
        IF EXISTS(SELECT 1 FROM tblColaboradores WHERE idColaborador = 1)
        BEGIN
            --IF NOT EXISTS(SELECT 1 FROM tblColaboradores WHERE idTurno = 1 AND idColaborador != 1)
            IF NOT EXISTS(SELECT 1 FROM tblColaboradores WHERE CAST(registro AS DATE) = '2026-09-07' AND idTurno = 1 AND 
            CONCAT(Nombres, apellidoPaterno, apellidoMaterno) = CONCAT('Leonardo', 'Zamudio', 'Gonzalez') 
            AND idColaborador != 1)
            BEGIN 
            UPDATE tblColaboradores
            SET 
                 nombres = @nombres
                ,apellidoPaterno = @apellidoPaterno
                ,apellidoMaterno = @apellidoMaterno
                ,fechaNacimiento = @fechaNacimiento
                ,idnivelEducativo = @idnivelEducativo
                ,numeroCelular = @numeroCelular
                ,estatus = @estatus
                ,registro = @registro
                ,fechaIngreso = @fechaIngreso
                ,idTurno = @idTurno
                ,horaEntrada = @horaEntrada
                ,horaSalida = @horaSalida
                ,horasLaboradasPorDia = @horasLaboradasPorDia
            WHERE idColaborador = @idColaborador
            END
            ELSE PRINT 'YA EXISTE UN REGISTRO CON ESE TURNO'
        END
        ELSE PRINT 'NO EXISTE NINGÚN REGISTRO CON ESE ID' ;
        COMMIT TRANSACTION;
        END TRY
        BEGIN CATCH
            IF @@TRANCOUNT >0
			ROLLBACK TRANSACTION;
		THROW;
        END CATCH
END
GO


/*
SELECT [idColaborador]
      ,[nombres]
      ,[apellidoPaterno]
      ,[apellidoMaterno]
      ,[fechaNacimiento]
      ,[idnivelEducativo]
      ,[numeroCelular]
      ,[estatus]
      ,[registro]
      ,[fechaIngreso]
      ,[idTurno]
      ,[horaEntrada]
      ,[horaSalida]
      ,[horasLaboradasPorDia]
  FROM [dbo].[tblColaboradores]
*/

--Select sp

CREATE OR ALTER PROCEDURE spConsultar_FechaTurno_Colaboradores
    @FechaInicio DATE,
    @FechaFin DATE,
    @idTurno INT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRANSACTION;
        SELECT [idColaborador]
      ,[nombres]
      ,[apellidoPaterno]
      ,[apellidoMaterno]
      ,[fechaNacimiento]
      ,[idnivelEducativo]
      ,[numeroCelular]
      ,[estatus]
      ,[registro]
      ,[fechaIngreso]
      ,[idTurno]
      ,[horaEntrada]
      ,[horaSalida]
      ,[horasLaboradasPorDia]
  FROM [dbo].[tblColaboradores] as C
            WHERE 
        -- Filtro por rango de fechas (si se proporcionan ambas)
        ((@FechaInicio IS NULL OR @FechaFin IS NULL OR CAST(c.registro AS DATE) BETWEEN @FechaInicio AND @FechaFin)
        AND
        -- Filtro por tipoTurno (si se proporciona)
        (@idTurno IS NULL OR C.idTurno = @idTurno)
        
        AND estatus = 1)
        COMMIT TRANSACTION
    END TRY
    BEGIN CATCH
            IF @@TRANCOUNT >0
			ROLLBACK TRANSACTION;
		THROW;
    END CATCH
END
GO

CREATE OR ALTER PROCEDURE spEliminarColaborador
    @idColaborador INT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRANSACTION;
            UPDATE tblColaboradores
            SET estatus = 0
            WHERE idColaborador = @idColaborador
        COMMIT TRANSACTION
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT >0
            ROLLBACK TRANSACTION
        THROW;
    END CATCH
END
GO

--Consultar entre fecha y hora
CREATE OR ALTER PROCEDURE spConsultar_FechaHora_Colaboradores
    (@FechaInicio DATE,
    @FechaFin DATE,
    @horaInicio TIME,
    @horaFin TIME)
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRANSACTION;
        SELECT 
            COUNT(*) AS TotalActivos,
            SUM(CASE WHEN C.idTurno = 1 THEN C.horasLaboradasPorDia ELSE 0 END) AS'Matutino',
            SUM(CASE WHEN C.idTurno = 2 THEN C.horasLaboradasPorDia ELSE 0 END) AS'Vespertino',
            SUM(CASE WHEN C.idTurno = 3 THEN C.horasLaboradasPorDia ELSE 0 END) AS 'Nocturno'
        FROM [dbo].[tblColaboradores] AS C
        WHERE 
            ---- Filtro por rango de fechas
            --((@FechaInicio IS NULL OR @FechaFin IS NULL 
            --OR CAST(C.registro AS DATE) BETWEEN @FechaInicio AND @FechaFin))
            --AND
            ---- Filtro por rango de horas
            --(@horaInicio IS NULL OR @horaFin IS NULL 

            --OR ((C.horaEntrada BETWEEN @horaInicio AND @horaFin) 
            ----OR (C.horaSalida BETWEEN @horaInicio AND @horaFin))   --2026/09/08 AEHM
            --OR (C.horaSalida BETWEEN @horaInicio AND @horaFin)))
            --AND 
            --(C.estatus = 1)  -- Solo activos
            (@FechaInicio IS NULL OR @FechaFin IS NULL OR CAST( C.registro AS DATE) BETWEEN CAST(@FechaInicio AS DATE) AND CAST(@FechaFin AS DATE))
                    AND 
                    (
                      @horaInicio IS NULL OR @horaFin IS NULL OR 
                      (
                        (C.horaEntrada BETWEEN @horaInicio AND @horaFin) 
                        -- OR 2026/09/08 AMML
                        AND
                        (C.horaSalida BETWEEN @horaInicio AND @horaFin)
                      )
                    ) 
                    AND
                    (C.estatus = 1)
        COMMIT TRANSACTION
    END TRY
    BEGIN CATCH
            IF @@TRANCOUNT >0
			ROLLBACK TRANSACTION;
		THROW;
    END CATCH
END
GO

--DECLARE @FechaInicio DATE = '2026-09-07'
--DECLARE @FechaFin DATE = '2026-09-07'
--DECLARE @horaInicio TIME = '15:00'
--DECLARE @horaFin TIME = '19:00'
--SELECT [idColaborador]
--      ,[nombres]
--      ,[apellidoPaterno]
--      ,[apellidoMaterno]
--      ,[fechaNacimiento]
--      ,[idnivelEducativo]
--      ,[numeroCelular]
--      ,[estatus]
--      ,[registro]
--      ,[fechaIngreso]
--      ,[idTurno]
--      ,[horaEntrada]
--      ,[horaSalida]
--      ,[horasLaboradasPorDia]
--  FROM [dbo].[tblColaboradores] as C
--            WHERE 
--        -- Filtro por rango de fechas (si se proporcionan ambas)
--        ((@FechaInicio IS NULL OR @FechaFin IS NULL OR CAST(c.registro AS DATE) BETWEEN @FechaInicio AND @FechaFin)
--        AND
--        -- Filtro por tipoTurno (si se proporciona)
--        (@horaInicio IS NULL OR @horaFin IS NULL OR (C.horaEntrada BETWEEN @horaInicio AND @horaFin) 
--        OR (C.horaSalida BETWEEN @horaInicio AND @horaFin))
        
--        AND estatus = 1)

--DECLARE @FechaInicio DATE = '2026-09-07'
--DECLARE @FechaFin DATE = '2026-09-07'
--DECLARE @horaInicio TIME = '15:00'
--DECLARE @horaFin TIME = '19:00'

--SELECT 
--COUNT(*) AS TotalActivos,
--        SUM(CASE WHEN C.idTurno = 1 THEN C.horasLaboradasPorDia ELSE 0 END) AS'Matutino',
--        SUM(CASE WHEN C.idTurno = 2 THEN C.horasLaboradasPorDia ELSE 0 END) AS'Vespertino',
--        SUM(CASE WHEN C.idTurno = 3 THEN C.horasLaboradasPorDia ELSE 0 END) AS 'Nocturno'
--FROM [dbo].[tblColaboradores] AS C
--WHERE 
--    -- Filtro por rango de fechas
--    ((@FechaInicio IS NULL OR @FechaFin IS NULL 
--      OR CAST(C.registro AS DATE) BETWEEN @FechaInicio AND @FechaFin)
--    AND
--    -- Filtro por rango de horas
--    (@horaInicio IS NULL OR @horaFin IS NULL 
--      OR (C.horaEntrada BETWEEN @horaInicio AND @horaFin) 
--      OR (C.horaSalida BETWEEN @horaInicio AND @horaFin))
--    AND 
--    C.estatus = 1)  -- Solo activos