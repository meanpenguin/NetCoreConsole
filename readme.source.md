This shows how to use the various publish profile options when building a netcore 3 console app.

toc


## Console project settings

 * This sample references and makes use of NodaTime to illustrate a dependency being consumed.
 * This sample references, but does not use, Newtonsoft for illustrate a dependency being trimmed.
 * The [Runtime IDentifier](https://docs.microsoft.com/en-us/dotnet/core/rid-catalog) is hard coded to `win-x64`. All profiles will inherit this setting.
 * `AppendRuntimeIdentifierToOutputPath` and `AppendTargetFrameworkToOutputPath` are disabled to simplify the resulting directory structure. See [Change the build output directory](https://docs.microsoft.com/en-us/visualstudio/ide/how-to-change-the-build-output-directory)

snippet: MyConsole.csproj


## Publish Profiles

Publish profiles are located in [src/MyConsole/Properties/PublishProfiles](/src/MyConsole/Properties/PublishProfiles)


### Default

Uses the default publish profile settings:

snippet: Default.pubxml

include: Default

Publish Command:

```
dotnet publish MyConsole\MyConsole.csproj -c Release /p:PublishProfile=Default
```


### Framework Dependent

Same as the [Default](#default) but makes it [Framework-dependent](https://docs.microsoft.com/en-us/dotnet/core/deploying/#framework-dependent-deployments-fdd):

snippet: Fdd.pubxml

include: Fdd

Notes:

 * Depends on an installed runtime.

Publish Command:

```
dotnet publish MyConsole\MyConsole.csproj -c Release /p:PublishProfile=Fdd
```


### Single-File Exe

Same as [Default](#default) but creates a [Single-file executables](https://docs.microsoft.com/en-us/dotnet/core/whats-new/dotnet-core-3-0#single-file-executables):

snippet: SingleExe.pubxml

include: SingleExe

Publish Command:

```
dotnet publish MyConsole\MyConsole.csproj -c Release /p:PublishProfile=SingleExe
```


### Single Exe and Framework Dependent

Combines [Single-File Exe](#single-file-exe) and [Framework Dependent](#framework-dependent):

snippet: SingleExeFdd.pubxml

include: SingleExeFdd

Notes:

 * Depends on an installed runtime.

Publish Command:

```
dotnet publish MyConsole\MyConsole.csproj -c Release /p:PublishProfile=SingleExeFdd
```


### Trimmed

Same as the [Default](#default) but uses [assembly-linking](https://docs.microsoft.com/en-us/dotnet/core/whats-new/dotnet-core-3-0#assembly-linking):

snippet: Trimmed.pubxml

include: Trimmed

Publish Command:

```
dotnet publish MyConsole\MyConsole.csproj -c Release /p:PublishProfile=Trimmed
```


### Single Exe and Trimmed

Combines [Single-File Exe](#single-file-exe) and [Trimmed](#trimmed):

snippet: SingleExeTrimmed.pubxml

include: SingleExeTrimmed

Publish Command:

```
dotnet publish MyConsole\MyConsole.csproj -c Release /p:PublishProfile=SingleExeTrimmed
```
