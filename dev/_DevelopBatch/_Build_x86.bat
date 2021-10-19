echo off

IF "%1" == "" echo ビルドバッチ(x86)
IF "%1" == "" echo ---------------------------------

IF "%1" == "" goto ERR_EXIT_

set bakPath=%PATH%
rem Path=C:\Program Files (x86)\MSBuild\14.0\Bin;%Path%
rem Path=C:\Program Files (x86)\Microsoft Visual Studio\2017\Community\MSBuild\15.0\Bin\;%Path%
Path=C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\MSBuild\Current\Bin\;%Path%

set paramCategory=%2
set paramProject=%3
set paramBin=%4

set paramPlatform=x86

echo [%paramCategory%] %paramProject% / %paramPlatform%
echo -----------------------------------------------------------------

cd %paramCategory%\%paramProject%

Call _%paramPlatform%_DebugRebuild.bat /s
set srcFolder=.\bin\%paramPlatform%\debug
set destFolder=..\..\%paramBin%
IF NOT EXIST %destFolder% mkdir %destFolder%
set destFolder=..\..\%paramBin%\%paramPlatform%
IF NOT EXIST %destFolder% mkdir %destFolder%
set destFolder=..\..\%paramBin%\%paramPlatform%\Debug
IF NOT EXIST %destFolder% mkdir %destFolder%
set destFolder=..\..\%paramBin%\%paramPlatform%\Debug\%paramCategory%
IF NOT EXIST %destFolder% mkdir %destFolder%

IF EXIST %srcFolder%\%paramProject%.dll        copy %srcFolder%\%paramProject%.dll        %destFolder%
IF EXIST %srcFolder%\%paramProject%.exe        copy %srcFolder%\%paramProject%.exe        %destFolder%
IF EXIST %srcFolder%\%paramProject%.exe.config copy %srcFolder%\%paramProject%.exe.config %destFolder%

Call _%paramPlatform%_ReleaseRebuild.bat /s
set srcFolder=.\bin\%paramPlatform%\release
set destFolder=..\..\%paramBin%
IF NOT EXIST %destFolder% mkdir %destFolder%
set destFolder=..\..\%paramBin%\%paramPlatform%
IF NOT EXIST %destFolder% mkdir %destFolder%
set destFolder=..\..\%paramBin%\%paramPlatform%\Release
IF NOT EXIST %destFolder% mkdir %destFolder%
set destFolder=..\..\%paramBin%\%paramPlatform%\Release\%paramCategory%
IF NOT EXIST %destFolder% mkdir %destFolder%

IF EXIST %srcFolder%\%paramProject%.dll        copy %srcFolder%\%paramProject%.dll          %destFolder%
IF EXIST %srcFolder%\%paramProject%.exe        copy %srcFolder%\%paramProject%.exe          %destFolder%
IF EXIST %srcFolder%\%paramProject%.config     copy %srcFolder%\%paramProject%.exe.config   %destFolder%

cd ..\..\

Path=%bakPath%

goto EXIT_

:ERR_EXIT_
echo パラメータが必須です。
echo ----------------------------------

pause

:EXIT_
