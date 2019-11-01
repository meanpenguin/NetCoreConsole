<!--
GENERATED FILE - DO NOT EDIT
This file was generated by [MarkdownSnippets](https://github.com/SimonCropp/MarkdownSnippets).
Source File: /readme.source.md
To change this file edit the source file and then run MarkdownSnippets.
-->

This shows how to use the various publish profile options when building a netcore 3 console app.

This sample targets one dependency (NodaTime) for illustrative purposes

<!-- toc -->
## Contents

  * [Publish Profile](#publish-profile)
    * [Default](#default)
    * [Framework Dependent](#framework-dependent)
    * [Single-File Exe](#single-file-exe)
    * [Single Exe and Framework Dependent](#single-exe-and-framework-dependent)
    * [Default Trimmed](#default-trimmed)
<!-- endtoc -->



## Publish Profile

Publish profiles are located in [src/MyConsole/Properties/PublishProfiles](/src/MyConsole/Properties/PublishProfiles)


### Default

Uses the default publish profile settings:

<!-- snippet: Default.pubxml -->
<a id='snippet-Default.pubxml'/></a>
```pubxml
<Project>
  <PropertyGroup>
    <PublishDir>bin\Release\publish\Default\</PublishDir>
  </PropertyGroup>
</Project>
```
<sup>[snippet source](/src/MyConsole/Properties/PublishProfiles/Default.pubxml#L1-L5) / [anchor](#snippet-Default.pubxml)</sup>
<!-- endsnippet -->

 * ~ 250 files
 * ~ 70MB

Publish Command:

```
dotnet publish MyConsole\MyConsole.csproj -c Release /p:PublishProfile=Default
```


### Framework Dependent

Same as the Default but makes it [Framework-dependent](https://docs.microsoft.com/en-us/dotnet/core/deploying/#framework-dependent-deployments-fdd):

<!-- snippet: Fdd.pubxml -->
<a id='snippet-Fdd.pubxml'/></a>
```pubxml
<Project>
  <PropertyGroup>
    <PublishDir>bin\Release\publish\Fdd\</PublishDir>
    <SelfContained>false</SelfContained>
  </PropertyGroup>
</Project>
```
<sup>[snippet source](/src/MyConsole/Properties/PublishProfiles/Fdd.pubxml#L1-L6) / [anchor](#snippet-Fdd.pubxml)</sup>
<!-- endsnippet -->

 * 5 files
 * ~ 600KB
 * Depends on an installed runtime.

Publish Command:

```
dotnet publish MyConsole\MyConsole.csproj -c Release /p:PublishProfile=Fdd
```


### Single-File Exe

Same as default but creates a [Single-file executables](https://docs.microsoft.com/en-us/dotnet/core/whats-new/dotnet-core-3-0#single-file-executables):

<!-- snippet: SingleExe.pubxml -->
<a id='snippet-SingleExe.pubxml'/></a>
```pubxml
<Project>
  <PropertyGroup>
    <PublishDir>bin\Release\publish\SingleExe\</PublishDir>
    <PublishSingleFile>true</PublishSingleFile>
  </PropertyGroup>
</Project>
```
<sup>[snippet source](/src/MyConsole/Properties/PublishProfiles/SingleExe.pubxml#L1-L6) / [anchor](#snippet-SingleExe.pubxml)</sup>
<!-- endsnippet -->

 * 1 file
 * ~ 70MB

Publish Command:

```
dotnet publish MyConsole\MyConsole.csproj -c Release /p:PublishProfile=SingleExe
```


### Single Exe and Framework Dependent

Combines Framework Dependent and Single-File Exe:

<!-- snippet: SingleExeFdd.pubxml -->
<a id='snippet-SingleExeFdd.pubxml'/></a>
```pubxml
<Project>
  <PropertyGroup>
    <PublishDir>bin\Release\publish\SingleExeFdd\</PublishDir>
    <PublishSingleFile>true</PublishSingleFile>
    <SelfContained>false</SelfContained>
  </PropertyGroup>
</Project>
```
<sup>[snippet source](/src/MyConsole/Properties/PublishProfiles/SingleExeFdd.pubxml#L1-L7) / [anchor](#snippet-SingleExeFdd.pubxml)</sup>
<!-- endsnippet -->

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

<!-- snippet: DefaultTrimmed.pubxml -->
<a id='snippet-DefaultTrimmed.pubxml'/></a>
```pubxml
<Project>
  <PropertyGroup>
    <PublishDir>bin\Release\publish\DefaultTrimmed\</PublishDir>
    <PublishTrimmed>true</PublishTrimmed>
  </PropertyGroup>
</Project>
```
<sup>[snippet source](/src/MyConsole/Properties/PublishProfiles/DefaultTrimmed.pubxml#L1-L6) / [anchor](#snippet-DefaultTrimmed.pubxml)</sup>
<!-- endsnippet -->

 * ~ 100 files
 * ~ 33MB

Publish Command:

```
dotnet publish MyConsole\MyConsole.csproj -c Release /p:PublishProfile=DefaultTrimmed
```

PublishTrimmed can also be applied to the other above profile examples.
