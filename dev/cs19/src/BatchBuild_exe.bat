echo off

IF "%1" == "" echo バッチビルド(exe)
IF "%1" == "" echo ---------------------------------

IF "%1" == "" pause

Call ..\..\_DevelopBatch\_Build_AnyCPU.bat /s exe NapLabCamera          ..\bin

rem Call ..\..\_DevelopBatch\_Build_x86.bat    /s exe Sample          ..\bin
rem Call ..\..\_DevelopBatch\_Build_x64.bat    /s exe Sample          ..\bin

IF "%1" == "" pause
