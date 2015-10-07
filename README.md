# NuGetRepositoryDownloader
Downloads NuGet packages of the given repository.

#Parameters
  * repo : Repository Uri (required)
  * path : Path to download packages (optional)
  * package : NuGet package id (optional)
  * version : Package semantic version (optional)

#Example Usage
Downloads all packages in the repo to "D:\packages\nuget" folder
```csharp
NuGetRepositoryDownloader.exe -repo "http://examplerepo/nexus/service/local/nuget/Example/" -path "d:\packages\nuget"
```
Downloads all packages in the repo with "Expl" package id to "D:\packages\nuget" folder
```csharp
NuGetRepositoryDownloader.exe -repo "http://examplerepo/nexus/service/local/nuget/Example/" -path "d:\packages\nuget" -package "Expl"
```
Downloads all packages in the repo with "Expl" package id and "1.0.0" version to "D:\packages\nuget" folder
```csharp
NuGetRepositoryDownloader.exe -repo "http://examplerepo/nexus/service/local/nuget/Example/" -path "d:\packages\nuget" -package "Expl" -version "1.0.0"
```
