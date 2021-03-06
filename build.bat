@echo Off
set config=%1
if "%config%" == "" (
   set config=Release
)
 
set version=0.1.3
if not "%PackageVersion%" == "" (
   set version=%PackageVersion%
)

set nuget=
if "%nuget%" == "" (
	set nuget=nuget
)

%nuget% restore Src

%WINDIR%\Microsoft.NET\Framework\v4.0.30319\msbuild src\Enfold.sln /p:Configuration="%config%" /m /v:M /fl /flp:LogFile=msbuild.log;Verbosity=diag /nr:false

mkdir Build
mkdir Build\lib
mkdir Build\lib\net45

%nuget% pack "Nuget\Enfold.Javascript.nuspec" -NoPackageAnalysis -verbosity detailed -o Build -Version %version% -p Configuration="%config%"
