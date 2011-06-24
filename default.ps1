# This script is derived from the dotless build script.
include .\extensions.ps1

properties {
    $path             = resolve-path .
    $buildDirectory   = "$path\build\"
    $nugetDirectory   = "$path\nuget"
    $releaseDirectory = "$path\release\"
    $sourceDirectory  = "$path\src"
    $solution         = "$sourceDirectory\Agdur.sln"	
    $toolsDirectory   = "$path\tools\"
    $version          = "0.6"
}

$framework = '4.0'

task default -depends release

task clean {
    Remove-Item -Force -Recurse -ErrorAction SilentlyContinue -LiteralPath $buildDirectory, $nugetDirectory, $releaseDirectory
}

task build -depends clean {
    New-Item $buildDirectory -ItemType Directory | Out-Null

    Generate-Assembly-Info `
        -file "$sourceDirectory\Agdur\Properties\AssemblyInfo.cs" `
        -title "Agdur $version" `
        -description "Micro-benchmarking for the .NET framework" `
        -product "Agdur" `
        -version $version `
        -copyright "Copyright (C) Mattias Rydengren 2011" `

    msbuild $solution /p:OutDir=$buildDirectory /p:Configuration=Release | Out-Null
}

task release -depends build {
    New-Item $releaseDirectory -ItemType Directory | Out-Null

    & $toolsDirectory\7-zip\7za.exe a $releaseDirectory\agdur-$version-release-net-4.0.zip `
        $buildDirectory\Agdur.dll `
        $buildDirectory\Agdur.pdb `
        $buildDirectory\Agdur.xml `
        license.txt | Out-Null
}

task nuget -depends release {
    New-Item $nugetDirectory\lib\net40 -ItemType Directory | Out-Null
        
    Generate-NuGet-Spec `
        -file "$nugetDirectory\Agdur.nuspec" `
        -id "Agdur" `
        -version $version `
        -description "Agdur is a simple micro-benchmarking library for the .NET framework." `
        -author "Mattias Rydengren" `
        -licenseUrl "https://github.com/mrydengren/agdur/blob/master/license.txt" `
        -projectUrl "https://github.com/mrydengren/agdur" `
        -tags "agdur benchmarking"
        
    Copy-Item -Destination $nugetDirectory\lib\net40 -LiteralPath `
        $buildDirectory\Agdur.dll, `
        $buildDirectory\Agdur.pdb, `
        $buildDirectory\Agdur.xml 
    
    & nuget pack $nugetDirectory\Agdur.nuspec -o $nugetDirectory | Out-Null
    Remove-Item -LiteralPath $nugetDirectory\lib, $nugetDirectory\Agdur.nuspec -Force -Recurse -ErrorAction SilentlyContinue
}