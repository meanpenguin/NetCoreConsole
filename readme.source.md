This shows how to use the various publish profile options when building a netcore 3 console app.

toc


## Console project settings

 * This sample references and makes use of NodaTime to illustrate a dependency being consumed.
 * This sample references, but does not use, Newtonsoft to illustrate a dependency being trimmed.
 * The [Runtime IDentifier](https://docs.microsoft.com/en-us/dotnet/core/rid-catalog) is hard coded to `win-x64`. All profiles will inherit this setting.
 * `PublishDir` is set to `src\MyConsole\publish\$(PublishProfile)\`.

snippet: MyConsole.csproj


## Publish Profiles

Publish profiles are located in [src/MyConsole/Properties/PublishProfiles](/src/MyConsole/Properties/PublishProfiles)


### Default

Uses an empty (default) publish profile:

snippet: Default.pubxml

include: Default

Publish Command:

```
dotnet publish MyConsole\MyConsole.csproj -c Release /p:PublishProfile=Default
```


### Framework Dependent

Same as the [Default](#default) but makes it [Framework-dependent](https://docs.microsoft.com/en-us/dotnet/core/deploying/#framework-dependent-deployments-fdd).

> For an FDD, you deploy only your app and third-party dependencies. Your app will use the version of .NET Core that's present on the target system. 

snippet: Fdd.pubxml

include: Fdd

Notes:

 * Depends on an installed runtime.

Publish Command:

```
dotnet publish MyConsole\MyConsole.csproj -c Release /p:PublishProfile=Fdd
```


### Single File

Same as [Default](#default) but creates a [Single-file executables](https://docs.microsoft.com/en-us/dotnet/core/whats-new/dotnet-core-3-0#single-file-executables).

> The executable is self-extracting and contains all dependencies (including native) that are required to run your app. When the app is first run, the application is extracted to a directory based on the app name and build identifier. Startup is faster when the application is run again. The application doesn't need to extract itself a second time unless a new version was used.

snippet: SingleFile.pubxml

include: SingleFile

Notes:

Publish Command:

```
dotnet publish MyConsole\MyConsole.csproj -c Release /p:PublishProfile=SingleFile
```


### Single File and Framework Dependent

Combines [Single-File](#single-file) and [Framework Dependent](#framework-dependent).

snippet: SingleFileFdd.pubxml

include: SingleFileFdd

Notes:

 * Depends on an installed runtime.

Publish Command:

```
dotnet publish MyConsole\MyConsole.csproj -c Release /p:PublishProfile=SingleFileFdd
```


### Trimmed

Same as the [Default](#default) but uses [assembly-linking](https://docs.microsoft.com/en-us/dotnet/core/whats-new/dotnet-core-3-0#assembly-linking).

> The .NET core 3.0 SDK comes with a tool that can reduce the size of apps by analyzing IL and trimming unused assemblies. Self-contained apps include everything needed to run your code, without requiring .NET to be installed on the host computer. However, many times the app only requires a small subset of the framework to function, and other unused libraries could be removed.

snippet: Trimmed.pubxml

include: Trimmed

Publish Command:

```
dotnet publish MyConsole\MyConsole.csproj -c Release /p:PublishProfile=Trimmed
```


### Single File and Trimmed

Combines [Single File](#single-file) and [Trimmed](#trimmed):

snippet: SingleFileTrimmed.pubxml

include: SingleFileTrimmed

Publish Command:

```
dotnet publish MyConsole\MyConsole.csproj -c Release /p:PublishProfile=SingleFileTrimmed
```


## ReadyToRun images

ReadyToRun images (`<PublishReadyToRun>true</PublishReadyToRun>`) are not covered in the above scenarios, but should be considered as an option for production apps.

> R2R binaries improve startup performance by reducing the amount of work the JIT needs to do as your application is loading. The binaries contain similar native code as what the JIT would produce, giving the JIT a bit of a vacation when performance matters most (at startup). R2R binaries are larger because they contain both intermediate language (IL) code, which is still needed for some scenarios, and the native version of the same code, to improve startup. - https://devblogs.microsoft.com/dotnet/announcing-net-core-3-0/


## Further Reading

 * [Announcing .NET Core 3.0](https://devblogs.microsoft.com/dotnet/announcing-net-core-3-0/)
 * [What's new in .NET Core 3.0](https://docs.microsoft.com/en-us/dotnet/core/whats-new/dotnet-core-3-0)
 * [Making a tiny .NET Core 3.0 entirely self-contained single executable - Scott Hanselman](https://www.hanselman.com/blog/MakingATinyNETCore30EntirelySelfcontainedSingleExecutable.aspx)
 * [Create a Trimmed Self-Contained Single Executable in .NET Core 3.0](https://www.talkingdotnet.com/create-trimmed-self-contained-executable-in-net-core-3-0/)