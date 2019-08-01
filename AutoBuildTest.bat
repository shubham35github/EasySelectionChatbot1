@echo off

echo Project Build Started...
echo.
echo.
echo --------------------------------------------------------

set SolutionPath=./EasySelectionChatbot.sln
call %windir%\Microsoft.NET\Framework\v4.0.30319\msbuild.exe /m /nologo %SolutionPath%

echo --------------------------------------------------------
echo.
echo.
echo Project Build Ended...
echo.
echo.
echo Project Execution Started...
echo.
echo Start Time - %TIME%
echo.
echo.

set EXEPath=.\EasySelectionChatbot\bin\Debug\EasySelectionChatbot.exe
call %EXEPath%

echo.
echo.
echo End Time - %TIME%
echo.
echo Project Execution Ended...
echo.
echo.
echo Press ENTER to Execute Unit Tests...
set /p key=
echo.
echo.
echo Unit Tests Execution Started...
echo.
echo.
echo --------------------------------------------------------

set TestPath=.\EasySelectionChatbotUnitTest\bin\Debug\EasySelectionChatbotUnitTest.dll
vstest.console.exe %TestPath% /ResultsDirectory:./TestResults /InIsolation /logger:trx

echo --------------------------------------------------------
echo.
echo.
echo Unit Tests Execution Ended...
echo.
echo.
pause
