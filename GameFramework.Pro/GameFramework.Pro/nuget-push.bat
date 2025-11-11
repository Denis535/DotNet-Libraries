@echo off
setlocal

set "API_KEY=%NUGET_API_KEY%"
set "PACKAGE_DIR=bin\Release"

if "%API_KEY%"=="" (
    echo ERROR: NUGET_API_KEY environment variable is not set.
    echo --------------------------------------------------
    goto :end
)

if not exist "%PACKAGE_DIR%\*.nupkg" (
    echo ERROR: No packages found in "%PACKAGE_DIR%".
    echo --------------------------------------------------
    goto :end
)

echo Publishing started: "%PACKAGE_DIR%".
echo --------------------------------------------------

for %%f in (%PACKAGE_DIR%\*.nupkg) do (
    dotnet nuget push "%%f" ^
        --api-key %API_KEY% ^
        --source https://api.nuget.org/v3/index.json ^
        --symbol-source https://symbols.nuget.org/upload ^
        --skip-duplicate

    if errorlevel 1 (
        echo ERROR: Failed to publish: %%~nxf.
        echo --------------------------------------------------
        goto :end
    )

    echo --------------------------------------------------
)

echo Publishing completed.
echo --------------------------------------------------

:end
endlocal
pause
