@echo off
cd /d "%~dp0NeuraLink"
start cmd /k "dotnet run --launch-profile https --no-build"
