echo off
cd %~d0%~p0

IF "%1" == "" echo GACìoò^(óvä«óùé“å†å¿)
IF "%1" == "" echo ---------------------------------

IF "%1" == "" pause
IF "%1" == ""  Path=C:\Program Files (x86)\Microsoft SDKs\Windows\v10.0A\bin\NETFX 4.6.1 Tools;%Path%

GACUTIL -i %~d0%~p0\TestAssembly.P4.dll
IF %ERRORLEVEL% NEQ 0 echo ÉGÉâÅ[Ç™Ç†ÇËÇ‹Ç∑
IF %ERRORLEVEL% NEQ 0 echo %cd%
IF %ERRORLEVEL% NEQ 0 pause

IF "%1" == "" echo -----------------------
IF "%1" == "" echo ìoò^Ç™äÆóπÇµÇ‹ÇµÇΩ

IF "%1" == "" pause

