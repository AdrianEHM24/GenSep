@echo off
rem Ejecutar todos los scripts de contingencia en orden (rollback completo)
setlocal

rem Cambiar por el nombre de tu instancia a SQL Server
set "SERVER=LAPTOP-O56R5GG9"
set "AUTH=-E"
set "SQLCMD=sqlcmd"
set "SCRIPTS_DIR=%~dp0"
set "DB=GenSep"

echo.
echo ============================
echo Ejecutando Contingencia A: Eliminar Job
echo ============================

%SQLCMD% -S %SERVER% %AUTH% -C -d %DB% -i "%SCRIPTS_DIR%P05R01_BD_A_JOBS_AEHM.sql" -b
if errorlevel 1 goto error

echo.
echo ============================
echo Ejecutando Contingencia B: Eliminar Triggers
echo ============================

%SQLCMD% -S %SERVER% %AUTH% -C -d %DB% -i "%SCRIPTS_DIR%P05R01_BD_B_TRIGGERS_AEHM.sql" -b
if errorlevel 1 goto error

echo.
echo ============================
echo Ejecutando Contingencia C: Eliminar Procedimientos Almacenados
echo ============================

%SQLCMD% -S %SERVER% %AUTH% -C -d %DB% -i "%SCRIPTS_DIR%P05R01_BD_C_SPs_AEHM.sql" -b
if errorlevel 1 goto error

echo.
echo ============================
echo Ejecutando Contingencia D: Eliminar Vistas
echo ============================

%SQLCMD% -S %SERVER% %AUTH% -C -d %DB% -i "%SCRIPTS_DIR%P05R01_BD_D_VISTAS_AEHM.sql" -b
if errorlevel 1 goto error

echo.
echo ============================
echo Ejecutando Contingencia E: Eliminar Registros (Carga Inicial)
echo ============================

%SQLCMD% -S %SERVER% %AUTH% -C -d %DB% -i "%SCRIPTS_DIR%P05R01_BD_E_LIMPIEZA_DATA_AEHM.sql" -b
if errorlevel 1 goto error

echo.
echo ============================
echo Ejecutando Contingencia F: Eliminar Tablas
echo ============================

%SQLCMD% -S %SERVER% %AUTH% -C -d %DB% -i "%SCRIPTS_DIR%P05R01_BD_F_DROP_TABLES_AEHM.sql" -b
if errorlevel 1 goto error

echo.
echo ============================
echo Ejecutando Contingencia G: Eliminar Base de Datos
echo ============================

%SQLCMD% -S %SERVER% %AUTH% -C -d master -i "%SCRIPTS_DIR%P05R01_BD_G_DROP_DATABASE_AEHM.sql" -b
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
