USE msdb
GO
--SELECT @@SERVERNAME

/*05
 P05R01_BD_AEHM
 AUTOR: ADRIAN ELEUTERIO HERNANDEZ MARTINEZ
 FECHA: 03/09/2026
*/

--=============================
-- CREACIÓN DE JOBS
--=============================
BEGIN TRANSACTION;
	BEGIN TRY
IF NOT EXISTS (SELECT 1 FROM dbo.sysjobs WHERE name = 'jExecSP')
BEGIN
--1. Crear el job
EXEC sp_add_job
	@job_name = N'jExecSP', --Nombre del job
	@enabled = 1,			--Habilitar el job
	@description = N'ejecuta el sp cada 5 minutos';--,
	--@start_step_id = 1,
	--@owner_login_name = N'sa';	--Puedes cambiar esto si es necesario

--2. Crear el step(paso) que ejecuta el stored procedure
EXEC sp_add_jobstep
	@job_name = N'jExecSP', --Nombre del job
	@step_name = N'Ejecutar_Mi_SP',
	@subsystem = N'TSQL',
	@command = N'EXEC dbo.spConsultarContenidoTablas;', --Comando que ejecuta el procedimiento almacenado
	@database_name = N'GenSep',   --Reemplaza con tu base de datos
	--@on_success_action = 1   --Continuar con el siguiente paso o terminar si es el único
	@retry_attempts = 3, 
	--@on_fail_action = 2;     --Parar el job si falla
		@retry_interval =1;
--3. Crear el Schedule (programación) para que se ejecute cada hora
EXEC sp_add_schedule
	--@job_name = N'jExecSP',   --Nombre del job
	--@name = N'RespaldoCadaHora', --Nombre de la programación
	@schedule_name = N'Schedule_Cada5Min',
	--@enabled = 1,			--Habilitar la programación
	@freq_type = 4,			--Frecuencia diaria
	@freq_interval = 1,			--Ejecutar todos los dias
	@freq_subday_type = 4,		--Frecuencia de horas
	@freq_subday_interval = 5,	--Ejecutar cada 5 minutos
	@active_start_time = 000000, --Hora de inicio(formato HHMMSS), empieza a medianoche
	@active_end_time = 235959

--4. Agregar el job al servidor
EXEC sp_attach_schedule
	@job_name = N'jExecSP',
	@schedule_name = N'Schedule_Cada5Min'  --Cambia '(local)' por el nombre de tu servidor si es necesario

--5. Agregar el job al server para que el SQL server Agent lo ejecute
EXEC dbo.sp_add_jobserver
	@job_name = N'jExecSP',
	@server_name = N'LAPTOP-O56R5GG9'  --CAMBIAR EL NOMBRE DEL SERVIDOR
END
COMMIT TRANSACTION
END TRY
BEGIN CATCH
IF @@TRANCOUNT >0
	BEGIN
		ROLLBACK TRANSACTION;
	END
	PRINT ERROR_MESSAGE();
END CATCH
GO