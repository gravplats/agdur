# This script is derived from the dotless build script.
include .\extensions.ps1

properties {
	$base_dir    = resolve-path .
	$build_dir   = "$base_dir\build\"
	$nuget_dir   = "$base_dir\nuget"
	$release_dir = "$base_dir\release\"
	$source_dir  = "$base_dir\src"
	$solution    = "$source_dir\Agdur.sln"	
	$tools_dir   = "$base_dir\tools\"
	$version     = "0.5"
}

$framework = '4.0'

task default -depends release

task clean {
	Remove-Item -Force -Recurse $build_dir -ErrorAction SilentlyContinue
	Remove-Item -Force -Recurse $release_dir -ErrorAction SilentlyContinue
}

task init -depends clean {
	Generate-Assembly-Info `
		-file "$source_dir\Agdur\Properties\AssemblyInfo.cs" `
		-title "Agdur $version" `
		-description "Benchmarking for .NET" `
		-company "The Agdur Project" `
		-product "Agdur" `
		-version $version `
		-copyright "Copyright (C) The Agdur Project 2011" `

	New-Item $build_dir -ItemType Directory
	New-Item $release_dir -ItemType Directory
}

task build -depends init {
	msbuild $solution /p:OutDir=$build_dir /p:Configuration=Release
}

task release -depends build {
	& $tools_dir\7-zip\7za.exe a $release_dir\agdur-release-$version.zip `
		$build_dir\Agdur.dll `
		$build_dir\Agdur.pdb `
		license.txt
}

task nuget -depends release {
	Remove-Item -Force -Recurse $nuget_dir -ErrorAction SilentlyContinue
	New-Item $nuget_dir\lib\net40 -ItemType Directory
		
	Generate-NuGet-Spec `
		-file "$nuget_dir\Agdur.nuspec" `
		-id "Agdur" `
		-version $version `
		-description "Agdur is a simple benchmarking library for the .NET framework." `
		-author "Mattias Rydengre " `
		-licenseUrl "https://github.com/mrydengren/agdur/blob/master/license.txt" `
		-projectUrl "https://github.com/mrydengren/agdur" `
		-tags "agdur benchmarking"
		
	Copy-Item $build_dir\Agdur.dll $nuget_dir\lib\net40
	Copy-Item $build_dir\Agdur.xml $nuget_dir\lib\net40
	
	& nuget pack $nuget_dir\Agdur.nuspec -o $nuget_dir
	
	Remove-Item -Force -Recurse $nuget_dir\lib -ErrorAction SilentlyContinue
	Remove-Item -Force $nuget_dir\Agdur.nuspec
}