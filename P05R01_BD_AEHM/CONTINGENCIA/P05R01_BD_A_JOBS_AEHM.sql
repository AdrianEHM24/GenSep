USE msdb
GO

/*05
 P05R01_BD_AEHM
 AUTOR: ADRIAN ELEUTERIO HERNANDEZ MARTINEZ
 FECHA: 03/09/2026
*/

--=============================
-- CONTINGENCIA DE JOBS
--=============================

IF EXISTS (SELECT 1 FROM dbo.sysjobs WHERE name = 'jExecSP')
BEGIN
	EXEC dbo.sp_delete_job
	@job_name = N'jExecSP',
	@delete_unused_schedule = 1--;
	--@force_delete = 1;
PRINT 'Job y sus recursos asociados eliminados';

--borrar duplicados
DECLARE @SCHEDULE_ID INT;
DECLARE cur CURSOR FOR
SELECT SCHEDULE_ID FROM msdb.dbo.sysschedules WHERE name = N'Schedule_Cada5Min';
OPEN cur;
FETCH NEXT FROM cur INTO @SCHEDULE_ID;
WHILE @@FETCH_STATUS = 0
BEGIN
	EXEC dbo.sp_delete_schedule @SCHEDULE_ID = @SCHEDULE_ID,
	@FORCE_DELETE = 1
	FETCH NEXT FROM cur INTO @SCHEDULE_ID;
END
CLOSE cur
	DEALLOCATE cur;
	PRINT 'Se borraron duplicates'
END