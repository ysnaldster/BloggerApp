# GET .NET IMAGE BY DOCKER
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 5123

# COPY PROJECT FILES
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY . ./
RUN dotnet restore BlogApplication.Api

COPY . .
WORKDIR "/src/BlogApplication.Api"
RUN dotnet build "BlogApplication.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BlogApplication.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BlogApplication.Api.dll"]