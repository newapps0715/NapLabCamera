echo off
IF "%1" == "" echo 製品構築バッチ
IF "%1" == "" echo -------------------------
IF "%1" == "" echo 使い方 : _CreateProduct [Platform]
IF "%1" == "" pause
IF "%1" == "" goto :EXIT_

set paramPlatform=%1
set paramProject=NapLabCamera

echo Product構築
echo 対象プラットフォーム：%paramPlatform%
echo ------------------------------------------

rem コピー先フォルダの設定および作成

rem product\
set destProductFolder=product
IF NOT EXIST %destProductFolder% mkdir %destProductFolder%

rem product\[Platform]
set destProductPlatformFolder=%destProductFolder%\%paramPlatform%
IF NOT EXIST %destProductPlatformFolder% mkdir %destProductPlatformFolder%

rem コピー先フォルダの設定
rem product\[Platform]\[Project]
set destProductProjectFolder=%destProductFolder%\%paramPlatform%\%paramProject%
IF NOT EXIST %destProductProjectFolder% mkdir %destProductProjectFolder%

rem コピー元フォルダの設定
set srcBinFolder=cs19\bin\%paramPlatform%\release
set srcBinFolder_AnyCPU=cs19\bin\AnyCPU\release
set srcExternalFolder=_ExternalApps
set srcDocFolder=doc
set srcSettngsFolder=settings
set srcPackagesFolder=_packages

rem product
rem -------------------------
set dest=%destProductProjectFolder%

rem set src=%srcExternalFolder%
rem IF EXIST %src%\NAP_R7\*.dll                 copy %src%\NAP_R7\*.dll                %dest%

set src=%srcPackagesFolder%
IF EXIST %src%\DirectShowLib.1.0.0\lib\*.dll                 copy %src%\DirectShowLib.1.0.0\lib\*.dll                %dest%

set src=%srcBinFolder%
IF EXIST %src%\exe\*.exe                    copy %src%\exe\*.exe               %dest%
rem IF EXIST %src%\library\*.dll                    copy %src%\library\*.dll               %dest%

:EXIT_

