echo off
cd %~d0%~p0

IF "%1" == "" echo GAC����(�v�Ǘ��Ҍ���)
IF "%1" == "" echo ---------------------------------

IF "%1" == "" pause
IF "%1" == ""  Path=C:\Program Files (x86)\Microsoft SDKs\Windows\v10.0A\bin\NETFX 4.6.1 Tools;%Path%

GACUTIL -u TestAssembly.P4
IF %ERRORLEVEL% NEQ 0 echo �G���[������܂�
IF %ERRORLEVEL% NEQ 0 echo %cd%
IF %ERRORLEVEL% NEQ 0 pause

IF "%1" == "" echo -----------------------
IF "%1" == "" echo �������������܂���

IF "%1" == "" pause

