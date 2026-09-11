@echo off
rem Ejecutar todos los scripts SQL en orden
setlocal

rem Cambiar por el nombre de tu instancia a SQL Server
set "SERVER=LAPTOP-O56R5GG9"
set "AUTH=-E"
set "SQLCMD=sqlcmd"
set "SCRIPTS_DIR=%~dp0"

echo.
echo ============================
echo Ejecutando Scripts 1: Crear Base de Datos
echo ============================

%SQLCMD% -S %SERVER% %AUTH% -C -d master -i "%SCRIPTS_DIR%P08R01_Inventario_01_CreateDatabase_AEHM.sql" -b
if errorlevel 1 goto error

rem Cambia por el nombre de la bd que crea tu script
set "DB=EPP_Inventario"

echo.
echo ============================
echo Ejecutando Scripts 2: Crear Tablas
echo ============================

%SQLCMD% -S %SERVER% %AUTH% -C -d %DB% -i "%SCRIPTS_DIR%P08R01_Inventario_02_CreateTables_AEHM.sql" -b
if errorlevel 1 goto error

echo.
echo ============================
echo Ejecutando Scripts 3: Carga inicial
echo ============================

%SQLCMD% -S %SERVER% %AUTH% -C -d %DB% -i "%SCRIPTS_DIR%P08R01_Inventario_03_CargaInicial_AEHM.sql" -b
if errorlevel 1 goto error

echo.
echo ============================
echo Los scripts se ejecutaron correctamente.
echo ============================
pause
goto end

:error
echo.
echo ============================
echo Error: Fallo en la ejecucion de los scripts.
echo Revisa el mensaje anterior para obtener mas detalles.
echo ============================
pause

:end
endlocal