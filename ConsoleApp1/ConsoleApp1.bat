@echo off
rem ???????? ???? ??? ?????????? ConsoleApp1.exe,
rem ? ??????? ????????????? ???????????? ?? ????????.
.\ConsoleApp1\bin\Debug\ConsoleApp1
@if "%ERRORLEVEL" == "0" goto success
:fail
rem ?????????? ????????? ???????,
echo This application has failed!
echo return value = %ERRORLEVEL%
goto end
:success
rem ?????????? ??????? ?????????,
echo This application has succeeded!
echo return value = %ERRORLEVEL%
goto end
: end
rem ?????? ???????,
echo All Done.