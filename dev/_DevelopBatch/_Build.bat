echo off

IF "%1" == "" echo ビルドバッチ
IF "%1" == "" echo ---------------------------------

IF "%1" == "" goto ERR_EXIT_

set bakPath=%PATH%
rem Path=C:\Program Files (x86)\MSBuild\14.0\Bin;%Path%
rem Path=C:\Program Files (x86)\Microsoft Visual Studio\2017\Community\MSBuild\15.0\Bin\;%Path%
Path=C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\MSBuild\Current\Bin\;%Path%

set paramCategory=%2
set paramProject=%3
set paramBin=%4

echo [%paramCategory%] %paramProject%
echo -----------------------------------------------------------------

cd %paramCategory%\%paramProject%

Call _DebugRebuild.bat /s
set srcFolder=.\bin\debug
set destFolder=..\..\%paramBin%
IF NOT EXIST %destFolder% mkdir %destFolder%
set destFolder=..\..\%paramBin%\debug\
IF NOT EXIST %destFolder% mkdir %destFolder%
set destFolder=..\..\%paramBin%\debug\%paramCategory%
IF NOT EXIST %destFolder% mkdir %destFolder%

IF EXIST %srcFolder%\%paramProject%.dll        copy %srcFolder%\%paramProject%.dll        %destFolder%
IF EXIST %srcFolder%\%paramProject%.exe        copy %srcFolder%\%paramProject%.exe        %destFolder%
IF EXIST %srcFolder%\%paramProject%.exe.config copy %srcFolder%\%paramProject%.exe.config %destFolder%

Call _ReleaseRebuild.bat /s
set srcFolder=.\bin\release
set destFolder=..\..\%paramBin%
IF NOT EXIST %destFolder% mkdir %destFolder%
set destFolder=..\..\%paramBin%\release
IF NOT EXIST %destFolder% mkdir %destFolder%
set destFolder=..\..\%paramBin%\release\%paramCategory%
IF NOT EXIST %destFolder% mkdir %destFolder%

IF EXIST %srcFolder%\%paramProject%.dll        copy %srcFolder%\%paramProject%.dll    %destFolder%
IF EXIST %srcFolder%\%paramProject%.exe        copy %srcFolder%\%paramProject%.exe    %destFolder%
IF EXIST %srcFolder%\%paramProject%.config     copy %srcFolder%\%paramProject%.config %destFolder%

cd ..\..\

Path=%bakPath%

goto EXIT_

:ERR_EXIT_
echo パラメータが必須です。
echo ----------------------------------

pause

:EXIT_
