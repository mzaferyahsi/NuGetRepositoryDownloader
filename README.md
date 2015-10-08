# NuGetRepositoryDownloader
Downloads NuGet packages of the given repository.

#Parameters
  * repo (r) : Repository Uri (required)
  * path (p) : Path to download packages (optional)
  * package (i) : NuGet package id (optional)
  * version (v) : Package semantic version (optional)

#Example Usage
Downloads all packages in the repo to current folder
```csharp
NuGetRepositoryDownloader.exe -r "http://examplerepo/nexus/service/local/nuget/Example/"
```
Downloads all packages in the repo to "D:\packages\nuget" folder
```csharp
NuGetRepositoryDownloader.exe -r "http://examplerepo/nexus/service/local/nuget/Example/" -p "d:\packages\nuget"
```
Downloads all packages in the repo with "Expl" package id to "D:\packages\nuget" folder
```csharp
NuGetRepositoryDownloader.exe -r "http://examplerepo/nexus/service/local/nuget/Example/" -p "d:\packages\nuget" -i "Expl"
```
Downloads all packages in the repo with "Expl" package id and "1.0.0" version to "D:\packages\nuget" folder
```csharp
NuGetRepositoryDownloader.exe -r "http://examplerepo/nexus/service/local/nuget/Example/" -p "d:\packages\nuget" -i "Expl" -v "1.0.0"
```
