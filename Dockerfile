#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ams.api/ams.api.csproj", "ams.api/"]
COPY ["ams.application/ams.application.csproj", "ams.application/"]
COPY ["ams.domain/ams.domain.csproj", "ams.domain/"]
COPY ["ams.infrastructure/ams.infrastructure.csproj", "ams.infrastructure/"]
RUN dotnet restore "./ams.api/ams.api.csproj"
COPY . .
WORKDIR "/src/ams.api"
RUN dotnet build "./ams.api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ams.api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ams.api.dll"]