This shows how to use the various publish profile options when building a netcore 3 console app.

This sample targets one dependency (NodaTime) for illustrative purposes

toc


## Publish Profile


### Default

Uses the default publis profile settings:

snippet: Default.pubxml

 * ~ 250 files
 * ~ 70MB

Publish Command:

```
dotnet publish MyConsole\MyConsole.csproj -c Release /p:PublishProfile=Default
```


### Framework Dependent

Same as the Default but makes it [Framework-dependent](https://docs.microsoft.com/en-us/dotnet/core/deploying/#framework-dependent-deployments-fdd):

snippet: Fdd.pubxml

 * ~ 5 files
 * ~ 600KB
 * Depends on an installed runtime.

Publish Command:

```
dotnet publish MyConsole\MyConsole.csproj -c Release /p:PublishProfile=Fdd
```


### Single-File Exe

Same as default but creates a [Single-file executables](https://docs.microsoft.com/en-us/dotnet/core/whats-new/dotnet-core-3-0#single-file-executables):

snippet: SingleExe.pubxml

 * 1 file
 * ~ 70MB

Publish Command:

```
dotnet publish MyConsole\MyConsole.csproj -c Release /p:PublishProfile=SingleExe
```


### Single Exe and Framework Dependent

Combines Framework Dependent and Single-File Exe:

snippet: SingleExeFdd.pubxml

Result:

 * 1 file
 * ~ 600KB
 * Depends on an installed runtime.

Publish Command:

```
dotnet publish MyConsole\MyConsole.csproj -c Release /p:PublishProfile=SingleExeFdd
```


### Default Trimmed

Same as the Default but uses [assembly-linking](https://docs.microsoft.com/en-us/dotnet/core/whats-new/dotnet-core-3-0#assembly-linking):

snippet: DefaultTrimmed.pubxml

 * ~ 100 files
 * ~ 33MB

Publish Command:

```
dotnet publish MyConsole\MyConsole.csproj -c Release /p:PublishProfile=DefaultTrimmed
```

PublishTrimmed can also be applied to the other above profile examples.
