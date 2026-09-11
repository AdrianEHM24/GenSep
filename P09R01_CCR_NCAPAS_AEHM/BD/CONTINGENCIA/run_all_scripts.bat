@echo off
rem Ejecutar todos los scripts de contingencia en orden (rollback completo)
setlocal

rem Cambiar por el nombre de tu instancia a SQL Server
set "SERVER=LAPTOP-O56R5GG9"
set "AUTH=-E"
set "SQLCMD=sqlcmd"
set "SCRIPTS_DIR=%~dp0"
set "DB=GenSepCCR"

echo.
echo ============================
echo Ejecutando Contingencia A: Eliminar Procedimientos Almacenados
echo ============================

%SQLCMD% -S %SERVER% %AUTH% -C -d %DB% -i "%SCRIPTS_DIR%P09R01_CCR_NCAPAS_A_SPs_AEHM.sql" -b
if errorlevel 1 goto error

echo.
echo ============================
echo Ejecutando Contingencia B: Eliminar Vistas
echo ============================

%SQLCMD% -S %SERVER% %AUTH% -C -d %DB% -i "%SCRIPTS_DIR%P09R01_CCR_NCAPAS_B_EliminarVistas_AEHM.sql" -b
if errorlevel 1 goto error

echo.
echo ============================
echo Ejecutando Contingencia C: Eliminar Registros (Carga Inicial)
echo ============================

%SQLCMD% -S %SERVER% %AUTH% -C -d %DB% -i "%SCRIPTS_DIR%P09R01_CCR_NCAPAS_C_LimpiezaData_AEHM.sql" -b
if errorlevel 1 goto error

echo.
echo ============================
echo Ejecutando Contingencia D: Eliminar Tablas
echo ============================

%SQLCMD% -S %SERVER% %AUTH% -C -d %DB% -i "%SCRIPTS_DIR%P09R01_CCR_NCAPAS_D_DropTables_AEHM.sql" -b
if errorlevel 1 goto error

echo.
echo ============================
echo Ejecutando Contingencia E: Eliminar Base de Datos
echo ============================

%SQLCMD% -S %SERVER% %AUTH% -C -d master -i "%SCRIPTS_DIR%P09R01_CCR_NCAPAS_E_DropDatabase_AEHM.sql" -b
if errorlevel 1 goto error


echo.
echo ============================
echo Los scripts de contingencia se ejecutaron correctamente.
echo ============================
pause
goto end

:error
echo.
echo ============================
echo Error: Fallo en la ejecucion de los scripts de contingencia.
echo Revisa el mensaje anterior para obtener mas detalles.
echo ============================
pause

:end
endlocal
