@echo off
setlocal

set "API_KEY=%NUGET_API_KEY%"
set "PACKAGE_DIR=bin\Release"

if "%API_KEY%"=="" (
    echo ERROR: NUGET_API_KEY environment variable is not set.
    goto :end
)

if not exist "%PACKAGE_DIR%\*.nupkg" (
    echo ERROR: No packages found in "%PACKAGE_DIR%".
    goto :end
)

echo Publishing packages: "%PACKAGE_DIR%"
for %%f in (%PACKAGE_DIR%\*.nupkg) do (
    echo --------------------------------------------------
    echo Publishing package: %%~nxf

    dotnet nuget push "%%f" ^
        --api-key %API_KEY% ^
        --source https://api.nuget.org/v3/index.json ^
        --symbol-source https://symbols.nuget.org/upload ^
        --skip-duplicate

    if errorlevel 1 (
        echo ERROR: Failed to publish: %%~nxf
        goto :end
    )

    echo Package published: %%~nxf
)

echo --------------------------------------------------
echo All packages have been published successfully.

:end
echo --------------------------------------------------
endlocal
pause
