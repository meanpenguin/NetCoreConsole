This shows how to build a netcore3 console app, including all files needed to deploy to a system with netcore already installed.

This sample targets one dependency (NodaTime) for illustrative purposes

toc


## Publish Profile


### Default

snippet: Default.pubxml

~250 files
~70MB

```
dotnet publish MyConsole\MyConsole.csproj  /p:PublishProfile=Default
```


### Framework Dependent

snippet: Fwd.pubxml

~5 files
~600KB

```
dotnet publish MyConsole\MyConsole.csproj  /p:PublishProfile=Fwd
```


### Single Exe

snippet: SingleExe.pubxml

~1 file
~70MB

```
dotnet publish MyConsole\MyConsole.csproj  /p:PublishProfile=SingleExe
```


### Single Exe and Framework Dependent

snippet: SingleExeFwd.pubxml

~1 file
~600KB

```
dotnet publish MyConsole\MyConsole.csproj  /p:PublishProfile=SingleExeFwd
```