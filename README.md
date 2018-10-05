This shows how to build a netcore console app, including all files needed to deploy to a system with netcore already installed.

This sample targets one dependency (NodaTime) for illustrative purposes


## Moving pieces


### CopyLocalLockFileAssemblies

The project needs to have `CopyLocalLockFileAssemblies` set to `true`.

```xml
<CopyLocalLockFileAssemblies>true</CopyLocalLockFileAssemblies>
```

This will force all the package dependencies to be copied to the output.


### Primary build

The primary build will produce the following files:

```
MyConsole.dll
MyConsole.pdb
NodaTime.dll
NodaTime.pdb
MyConsole.deps.json
MyConsole.runtimeconfig.dev.json
MyConsole.runtimeconfig.json
```

Note that is it missing the bootstrap exe `MyConsole.exe` and the host policy and host resolver files.


### Secondary build

A secondary nested build is used to produce the missing bootstrap and hosting files. 

It effectively executes the following command:

```
 dotnet build MyConsole.csproj -r win-x64 /p:CopyLocalLockFileAssemblies=false;IsNestedBuild=true
```

The `IsNestedBuild` property is used to prevent infinite recursion. 

```xml
<PropertyGroup>
  <NestedBuild>$(TargetDir)\nestedBuild\</NestedBuild>
</PropertyGroup>
<ItemGroup>
  <BootStrapFiles Include="$(NestedBuild)hostpolicy.dll;$(NestedBuild)$(ProjectName).exe;$(NestedBuild)hostfxr.dll;" />
</ItemGroup>
<Target Name="GenerateNetcoreExe"
        AfterTargets="Build"
        Condition="$(IsNestedBuild) != true">
  <RemoveDir Directories="$(NestedBuild)" />
  <Exec ConsoleToMSBuild="true"
        Command="dotnet build $(ProjectPath) -r win-x64 /p:CopyLocalLockFileAssemblies=false;IsNestedBuild=true --output $(NestedBuild)">
    <Output TaskParameter="ConsoleOutput"
            PropertyName="OutputOfExec" />
  </Exec>
  <Copy SourceFiles="@(BootStrapFiles)"
        DestinationFolder="$(OutputPath)" />
  <RemoveDir Directories="$(NestedBuild)" />
</Target>
```


## Final output

The full resultant file list

```
hostfxr.dll
hostpolicy.dll
MyConsole.deps.json
MyConsole.dll
MyConsole.exe
MyConsole.pdb
MyConsole.runtimeconfig.dev.json
MyConsole.runtimeconfig.json
NodaTime.dll
NodaTime.pdb
```


## Full csproj

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>netcoreapp2.1</TargetFramework>
    <CopyLocalLockFileAssemblies>true</CopyLocalLockFileAssemblies>
  </PropertyGroup>

  <ItemGroup>
    <!-- Forced pdbs to be copied to the output directory. see https://github.com/dotnet/sdk/issues/1458 -->
    <PackageReference Include="SourceLink.Copy.PdbFiles" Version="2.8.3" PrivateAssets="All" />
    <PackageReference Include="NodaTime" Version="2.4.0" />
  </ItemGroup>

  <PropertyGroup>
    <NestedBuild>$(TargetDir)\nestedBuild\</NestedBuild>
  </PropertyGroup>
  <ItemGroup>
    <BootStrapFiles Include="$(NestedBuild)hostpolicy.dll;$(NestedBuild)$(ProjectName).exe;$(NestedBuild)hostfxr.dll;" />
  </ItemGroup>
  <Target Name="GenerateNetcoreExe"
          AfterTargets="Build"
          Condition="$(IsNestedBuild) != true">
    <RemoveDir Directories="$(NestedBuild)" />
    <Exec ConsoleToMSBuild="true"
          Command="dotnet build $(ProjectPath) -r win-x64 /p:CopyLocalLockFileAssemblies=false;IsNestedBuild=true --output $(NestedBuild)">
      <Output TaskParameter="ConsoleOutput"
              PropertyName="OutputOfExec" />
    </Exec>
    <Copy SourceFiles="@(BootStrapFiles)"
          DestinationFolder="$(OutputPath)" />
    <RemoveDir Directories="$(NestedBuild)" />
  </Target>

</Project>
```