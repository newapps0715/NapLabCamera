echo off

set paramProject=NapLabCamera

IF "%1" == "" echo �S�r���h
IF "%1" == "" echo ---------------------------------

IF "%1" == "" pause

cd cs19\src
Call BatchBuild_exe.bat /s
cd ..\..\

echo Product�\�z
echo ------------

set ProductFolder=product
IF EXIST %ProductFolder% rmdir /S /Q %ProductFolder%
mkdir %ProductFolder%

rem product
rem -------------------------
Call _CreateProduct.bat AnyCPU
rem Call _CreateProduct.bat x86
rem Call _CreateProduct.bat x64
rem Call _CreateProduct.bat ARM

IF "%1" == "" pause
