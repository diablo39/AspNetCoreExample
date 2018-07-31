# Purpose

Sample project

# local

## Pre-requisites

* Installed .NET Core SDK 2.1
	* https://www.microsoft.com/net/download

## Build Application

From command line execute `dotnet build`

## Run application

From command line execute `dotnet run`

# Docker

## Docker build
`docker build -f src/AspNetCoreExample/Dockerfile .`

## Docker run - Production environment

`docker run -p 80:80 <name of container>`

## Docker run - ContractTests environment

`docker run -e "ASPNETCORE_ENVIRONMENT=ContractTests" -p 80:80 <name of container>`

# Swagger

http://localhost/swagger - swagger ui
http://localhost/api-docs - redoc


# Pipelines

Section describes commands that will be used by Cloud Foundry pipelines.

<b>Warning:<b> Output from below commands start with extra spaces in each line. Please make `left trim` 

## Application name

`dotnet msbuild /nologo /t:cfpappname`

## Application version

`dotnet msbuild /nologo /t:cfpversion`

## Application GroupId

`dotnet msbuild /nologo /t:cfpgroupid`

## Application ArtifactId

`dotnet msbuild /nologo /t:cfpartifactid`

## Run UnitTests

`dotnet msbuild /nologo /t:CFPUnitTests`

## Publish

