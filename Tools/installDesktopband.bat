@echo off
%1 mshta vbscript:CreateObject("Shell.Application").ShellExecute("cmd.exe","/c %~s0 ::","","runas",1)(window.close)&&exit

set gacutil="C:\Program Files (x86)\Microsoft SDKs\Windows\v10.0A\bin\NETFX 4.6 Tools\x64\gacutil.exe"
set RegAsm="C:\Windows\Microsoft.NET\Framework64\v4.0.30319\RegAsm.exe"

cd /d %~dp0
cd ..
cd .\ChDCStatMenus\bin\Release
%gacutil% /if BandObjectLib.dll
%gacutil% /if ChDCStatMenusLibrary.dll
%gacutil% /if ChDCStatMenus.dll
%regasm% ChDCStatMenus.dll
taskkill.exe /im explorer.exe /f
explorer.exe
rem pause
