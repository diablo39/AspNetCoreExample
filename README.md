# Purpose

Sample project

# Pre-requisites

* Installed .NET Core SDK 2.1
	* https://www.microsoft.com/net/download

# Build Application

From command line execute `dotnet build`

# Run application

From command line execute `dotnet run`

# Docker

## Docker build
`docker build -f src/AspNetCoreExample/Dockerfile .`

## Docker run

`docker run -e "ASPNETCORE_ENVIRONMENT=ContractTests" <name of container>`