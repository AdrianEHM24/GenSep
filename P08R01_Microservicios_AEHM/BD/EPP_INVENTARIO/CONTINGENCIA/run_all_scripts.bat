@echo off
rem Ejecutar todos los scripts de contingencia en orden (rollback completo)
setlocal

rem Cambiar por el nombre de tu instancia a SQL Server
set "SERVER=LAPTOP-O56R5GG9"
set "AUTH=-E"
set "SQLCMD=sqlcmd"
set "SCRIPTS_DIR=%~dp0"
set "DB=EPP_Inventario"

echo.
echo ============================
echo Ejecutando Contingencia A: Limpieza de Datos
echo ============================

%SQLCMD% -S %SERVER% %AUTH% -C -d %DB% -i "%SCRIPTS_DIR%P08R01_Inventario_A_LimpiezaData_AEHM.sql" -b
if errorlevel 1 goto error

echo.
echo ============================
echo Ejecutando Contingencia B: Eliminar Tablas
echo ============================

%SQLCMD% -S %SERVER% %AUTH% -C -d %DB% -i "%SCRIPTS_DIR%P08R01_Inventario_B_DropTables_AEHM.sql" -b
if errorlevel 1 goto error

echo.
echo ============================
echo Ejecutando Contingencia C: Eliminar Base de Datos
echo ============================

%SQLCMD% -S %SERVER% %AUTH% -C -d %DB% -i "%SCRIPTS_DIR%P08R01_Inventario_C_DropDatabase_AEHM.sql" -b
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
