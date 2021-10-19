echo off

IF "%1" == "" echo ビルドバッチ処理(Debug/x86/Rebuild)
IF "%1" == "" echo ----------------------------------------

IF "%1" == "" pause
rem IF "%1" == "" Path=C:\Program Files (x86)\MSBuild\14.0\Bin;%Path%
rem IF "%1" == "" Path=C:\Program Files (x86)\Microsoft Visual Studio\2017\Community\MSBuild\15.0\Bin\;%Path%
IF "%1" == "" Path=C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\MSBuild\Current\Bin\;%Path%

MSBuild /p:Configuration=Debug;Platform=x86 /t:Clean;Rebuild /v:q /nologo
IF %ERRORLEVEL% NEQ 0 echo エラーがあります
IF %ERRORLEVEL% NEQ 0 echo %cd%
IF %ERRORLEVEL% NEQ 0 pause

IF "%1" == "" echo -----------------------
IF "%1" == "" echo ビルドが完了しました

IF "%1" == "" pause

