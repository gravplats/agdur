# This script is derived from the dotless build script.
include .\extensions.ps1

properties {
	$base_dir    = resolve-path .
	$build_dir   = "$base_dir\build\"
	$release_dir = "$base_dir\release\"
	$source_dir  = "$base_dir\src"
	$solution    = "$source_dir\Agdur.sln"	
	$tools_dir   = "$base_dir\tools\"
	$version     = "0.5"
}

$framework = '4.0'

task default -depends Release

task Clean {
	Remove-Item -Force -Recurse $build_dir -ErrorAction SilentlyContinue
	Remove-Item -Force -Recurse $release_dir -ErrorAction SilentlyContinue
}

task Init -depends Clean {

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

task Build -depends Init {
	msbuild $solution /p:OutDir=$build_dir /p:Configuration=Release
}

task Release -depends Build {
	& $tools_dir\7-zip\7za.exe a $release_dir\agdur-release-$version.zip `
		$build_dir\Agdur.dll `
		$build_dir\Agdur.pdb `
		license.txt
}