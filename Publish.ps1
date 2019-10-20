# GTiff2Tiles.Benhmarks


#Win-x64
dotnet publish "GTiff2Tiles.Benchmarks/GTiff2Tiles.Benchmarks.csproj" -c Release -r win-x64 -o Publish/GTiff2Tiles.Benchmarks/win-x64 /p:PublishSingleFile=true /p:PublishTrimmed=true --self-contained

#Win-x86
dotnet publish "GTiff2Tiles.Benchmarks/GTiff2Tiles.Benchmarks.csproj" -c Release -r win-x86 -o Publish/GTiff2Tiles.Benchmarks/win-x86 /p:PublishSingleFile=true /p:PublishTrimmed=true --self-contained

#osx-x64
dotnet publish "GTiff2Tiles.Benchmarks/GTiff2Tiles.Benchmarks.csproj" -c Release -r osx-x64 -o Publish/GTiff2Tiles.Benchmarks/osx-x64 /p:PublishSingleFile=true /p:PublishTrimmed=true --self-contained

#linux-x64
dotnet publish "GTiff2Tiles.Benchmarks/GTiff2Tiles.Benchmarks.csproj" -c Release -r linux-x64 -o Publish/GTiff2Tiles.Benchmarks/linux-x64 /p:PublishSingleFile=true /p:PublishTrimmed=true --self-contained


# GTiff2Tiles.Console


#Win-x64
dotnet publish "GTiff2Tiles.Console/GTiff2Tiles.Console.csproj" -c Release -r win-x64 -o Publish/GTiff2Tiles.Console/win-x64 /p:PublishSingleFile=true /p:PublishTrimmed=true --self-contained

#Win-x86
dotnet publish "GTiff2Tiles.Console/GTiff2Tiles.Console.csproj" -c Release -r win-x86 -o Publish/GTiff2Tiles.Console/win-x86 /p:PublishSingleFile=true /p:PublishTrimmed=true --self-contained

#osx-x64
dotnet publish "GTiff2Tiles.Console/GTiff2Tiles.Console.csproj" -c Release -r osx-x64 -o Publish/GTiff2Tiles.Console/osx-x64 /p:PublishSingleFile=true /p:PublishTrimmed=true --self-contained

#linux-x64
dotnet publish "GTiff2Tiles.Console/GTiff2Tiles.Console.csproj" -c Release -r linux-x64 -o Publish/GTiff2Tiles.Console/linux-x64 /p:PublishSingleFile=true /p:PublishTrimmed=true --self-contained


# GTiff2Tiles.GUI


#Win-x64
dotnet publish "GTiff2Tiles.GUI/GTiff2Tiles.GUI.csproj" -c Release -r win-x64 -o Publish/GTiff2Tiles.GUI/win-x64 /p:PublishSingleFile=true /p:PublishTrimmed=true --self-contained

#Win-x86
dotnet publish "GTiff2Tiles.GUI/GTiff2Tiles.GUI.csproj" -c Release -r win-x86 -o Publish/GTiff2Tiles.GUI/win-x86 /p:PublishSingleFile=true /p:PublishTrimmed=true --self-contained
