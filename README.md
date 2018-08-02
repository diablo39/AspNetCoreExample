# Purpose

Sample project written in .net

# Running contract tests

It's enough for you to run `./scripts/runAcceptanceTests.sh` to

- Build a docker image with Artifactory (normally you would have that running / you could also use Git instead)
- We run the app on port `5000` in the `ContractTests` mode
- We run the Spring Cloud Contract docker image that has the `contracts` folder mounted with contracts
- From the mounted folder tests are generated against the running application
- Once the tests have passed stubs are generated and uploaded to Artifactory

# Running the app locally

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

<b>Warning:<b> Output from below commands start with extra spaces in each line. Please make `left trim` (you can do it by piping to `xargs`)

e.g.

## Application name

`dotnet msbuild /nologo /t:cfpappname | xargs`

## Application version

`dotnet msbuild /nologo /t:cfpversion | xargs`

## Application GroupId

`dotnet msbuild /nologo /t:cfpgroupid | xargs`

## Application ArtifactId

`dotnet msbuild /nologo /t:cfpartifactid | xargs`

## Run UnitTests

`dotnet msbuild /nologo /t:CFPUnitTests`

## Publish
