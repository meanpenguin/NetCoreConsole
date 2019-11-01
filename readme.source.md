This shows how to build a netcore3 console app, including all files needed to deploy to a system with netcore already installed.

This sample targets one dependency (NodaTime) for illustrative purposes


## Moving pieces


### Publish Profile


snippet: Win64.pubxml

dotnet publish MyConsole\MyConsole.csproj  /p:PublishProfile=Win64


## Final output

The full resultant file list

```
hostfxr.dll
hostpolicy.dll
MyConsole.deps.json
MyConsole.dll
MyConsole.exe
MyConsole.runtimeconfig.dev.json
MyConsole.runtimeconfig.json
NodaTime.dll
```

## Debug files

This project uses embedded symbols, so no pdb is created. However if a pdb is required, or it is necessary to include pdbs from referenced packages, consider using the [SourceLink.Copy.PdbFiles NuGet package](https://www.nuget.org/packages/SourceLink.Copy.PdbFiles/):

```xml
<PackageReference Include="SourceLink.Copy.PdbFiles" Version="2.8.3" PrivateAssets="All" />
```

See [dotnet/sdk/issues/1458](https://github.com/dotnet/sdk/issues/1458) for more information.

