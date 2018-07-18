FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY src/AspNetCoreExample/AspNetCoreExample.csproj src/AspNetCoreExample/
RUN dotnet restore src/AspNetCoreExample/AspNetCoreExample.csproj
COPY . .
WORKDIR /src/src/AspNetCoreExample
RUN dotnet build AspNetCoreExample.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish AspNetCoreExample.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "AspNetCoreExample.dll"]
