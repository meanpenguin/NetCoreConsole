<!--
GENERATED FILE - DO NOT EDIT
This file was generated by [MarkdownSnippets](https://github.com/SimonCropp/MarkdownSnippets).
Source File: /readme.source.md
To change this file edit the source file and then run MarkdownSnippets.
-->

This shows how to use the various publish profile options when building a netcore 3 console app.

<!-- toc -->
## Contents

  * [Console project settings](#console-project-settings)
  * [Publish Profiles](#publish-profiles)
    * [Default](#default)
    * [Framework Dependent](#framework-dependent)
    * [Single File](#single-file)
    * [Single File and Framework Dependent](#single-file-and-framework-dependent)
    * [Trimmed](#trimmed)
    * [Single File and Trimmed](#single-file-and-trimmed)
  * [ReadyToRun images](#readytorun-images)
  * [Further Reading](#further-reading)
<!-- endtoc -->



## Console project settings

 * This sample references and makes use of NodaTime to illustrate a dependency being consumed.
 * This sample references, but does not use, Newtonsoft to illustrate a dependency being trimmed.
 * The [Runtime IDentifier](https://docs.microsoft.com/en-us/dotnet/core/rid-catalog) is hard coded to `win-x64`. All profiles will inherit this setting.
 * `PublishDir` is set to `src\MyConsole\publish\$(PublishProfile)\`.

<!-- snippet: MyConsole.csproj -->
<a id='snippet-MyConsole.csproj'/></a>
```csproj
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>netcoreapp3.0</TargetFramework>
    <RuntimeIdentifier>win-x64</RuntimeIdentifier>
    <PublishDir>publish\$(PublishProfile)\</PublishDir>
  </PropertyGroup>
  <ItemGroup>
    <Content Include="ContentFile.txt">
      <CopyToOutputDirectory>Always</CopyToOutputDirectory>
    </Content>
    <PackageReference Include="Newtonsoft.Json" Version="12.0.2" />
    <PackageReference Include="NodaTime" Version="2.4.7" />
    <PackageReference Include="System.Configuration.ConfigurationManager" Version="4.6.0" />
  </ItemGroup>
</Project>
```
<sup>[snippet source](/src/MyConsole/MyConsole.csproj#L1-L16) / [anchor](#snippet-MyConsole.csproj)</sup>
<!-- endsnippet -->


## Publish Profiles

Publish profiles are located in [src/MyConsole/Properties/PublishProfiles](/src/MyConsole/Properties/PublishProfiles)


### Default

Uses an empty (default) publish profile:

<!-- snippet: Default.pubxml -->
<a id='snippet-Default.pubxml'/></a>
```pubxml
<Project>
  <PropertyGroup>
  </PropertyGroup>
</Project>
```
<sup>[snippet source](/src/MyConsole/Properties/PublishProfiles/Default.pubxml#L1-L4) / [anchor](#snippet-Default.pubxml)</sup>
<!-- endsnippet -->

<!--
include: Default
path: C:\Code\NetCoreConsole\src\includes\Default.include.md
-->

 * Files: 234
 * Size: 67.86 MB

Publish Command:

```
dotnet publish MyConsole\MyConsole.csproj -c Release /p:PublishProfile=Default
```


### Framework Dependent

Same as the [Default](#default) but makes it [Framework-dependent](https://docs.microsoft.com/en-us/dotnet/core/deploying/#framework-dependent-deployments-fdd).

> For an FDD, you deploy only your app and third-party dependencies. Your app will use the version of .NET Core that's present on the target system. 

<!-- snippet: Fdd.pubxml -->
<a id='snippet-Fdd.pubxml'/></a>
```pubxml
<Project>
  <PropertyGroup>
    <SelfContained>false</SelfContained>
  </PropertyGroup>
</Project>
```
<sup>[snippet source](/src/MyConsole/Properties/PublishProfiles/Fdd.pubxml#L1-L5) / [anchor](#snippet-Fdd.pubxml)</sup>
<!-- endsnippet -->

<!--
include: Fdd
path: C:\Code\NetCoreConsole\src\includes\Fdd.include.md
-->

 * Files: 14
 * Size: 2.21 MB

Notes:

 * Depends on an installed runtime.

Publish Command:

```
dotnet publish MyConsole\MyConsole.csproj -c Release /p:PublishProfile=Fdd
```


### Single File

Same as [Default](#default) but creates a [Single-file executables](https://docs.microsoft.com/en-us/dotnet/core/whats-new/dotnet-core-3-0#single-file-executables).

> The executable is self-extracting and contains all dependencies (including native) that are required to run your app. When the app is first run, the application is extracted to a directory based on the app name and build identifier. Startup is faster when the application is run again. The application doesn't need to extract itself a second time unless a new version was used.

<!-- snippet: SingleFile.pubxml -->
<a id='snippet-SingleFile.pubxml'/></a>
```pubxml
<Project>
  <PropertyGroup>
    <PublishSingleFile>true</PublishSingleFile>
  </PropertyGroup>
</Project>
```
<sup>[snippet source](/src/MyConsole/Properties/PublishProfiles/SingleFile.pubxml#L1-L5) / [anchor](#snippet-SingleFile.pubxml)</sup>
<!-- endsnippet -->

<!--
include: SingleFile
path: C:\Code\NetCoreConsole\src\includes\SingleFile.include.md
-->

 * Files: 1
 * Size: 67.87 MB

Notes:

Publish Command:

```
dotnet publish MyConsole\MyConsole.csproj -c Release /p:PublishProfile=SingleFile
```


### Single File and Framework Dependent

Combines [Single-File](#single-file) and [Framework Dependent](#framework-dependent).

<!-- snippet: SingleFileFdd.pubxml -->
<a id='snippet-SingleFileFdd.pubxml'/></a>
```pubxml
<Project>
  <PropertyGroup>
    <PublishSingleFile>true</PublishSingleFile>
    <SelfContained>false</SelfContained>
  </PropertyGroup>
</Project>
```
<sup>[snippet source](/src/MyConsole/Properties/PublishProfiles/SingleFileFdd.pubxml#L1-L6) / [anchor](#snippet-SingleFileFdd.pubxml)</sup>
<!-- endsnippet -->

<!--
include: SingleFileFdd
path: C:\Code\NetCoreConsole\src\includes\SingleFileFdd.include.md
-->

 * Files: 1
 * Size: 2.22 MB

Notes:

 * Depends on an installed runtime.

Publish Command:

```
dotnet publish MyConsole\MyConsole.csproj -c Release /p:PublishProfile=SingleFileFdd
```


### Trimmed

Same as the [Default](#default) but uses [assembly-linking](https://docs.microsoft.com/en-us/dotnet/core/whats-new/dotnet-core-3-0#assembly-linking).

> The .NET core 3.0 SDK comes with a tool that can reduce the size of apps by analyzing IL and trimming unused assemblies. Self-contained apps include everything needed to run your code, without requiring .NET to be installed on the host computer. However, many times the app only requires a small subset of the framework to function, and other unused libraries could be removed.

<!-- snippet: Trimmed.pubxml -->
<a id='snippet-Trimmed.pubxml'/></a>
```pubxml
<Project>
  <PropertyGroup>
    <PublishTrimmed>true</PublishTrimmed>
  </PropertyGroup>
</Project>
```
<sup>[snippet source](/src/MyConsole/Properties/PublishProfiles/Trimmed.pubxml#L1-L5) / [anchor](#snippet-Trimmed.pubxml)</sup>
<!-- endsnippet -->

<!--
include: Trimmed
path: C:\Code\NetCoreConsole\src\includes\Trimmed.include.md
-->

 * Files: 124
 * Size: 36.61 MB

Publish Command:

```
dotnet publish MyConsole\MyConsole.csproj -c Release /p:PublishProfile=Trimmed
```


### Single File and Trimmed

Combines [Single File](#single-file) and [Trimmed](#trimmed):

<!-- snippet: SingleFileTrimmed.pubxml -->
<a id='snippet-SingleFileTrimmed.pubxml'/></a>
```pubxml
<Project>
  <PropertyGroup>
    <PublishSingleFile>true</PublishSingleFile>
    <PublishTrimmed>true</PublishTrimmed>
  </PropertyGroup>
</Project>
```
<sup>[snippet source](/src/MyConsole/Properties/PublishProfiles/SingleFileTrimmed.pubxml#L1-L6) / [anchor](#snippet-SingleFileTrimmed.pubxml)</sup>
<!-- endsnippet -->

<!--
include: SingleFileTrimmed
path: C:\Code\NetCoreConsole\src\includes\SingleFileTrimmed.include.md
-->

 * Files: 1
 * Size: 36.62 MB

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
