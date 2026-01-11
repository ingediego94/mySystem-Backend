FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

ENV ASPNETCORE_ENVIRONMENT=Development
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["mySystem.Api/mySystem.Api.csproj", "mySystem.Api/"]
COPY ["mySystem.Application/mySystem.Application.csproj", "mySystem.Application/"]
COPY ["mySystem.Domain/mySystem.Domain.csproj", "mySystem.Domain/"]
COPY ["mySystem.Infrastructure/mySystem.Infrastructure.csproj", "mySystem.Infrastructure/"]
RUN dotnet restore "mySystem.Api/mySystem.Api.csproj"
COPY . .
WORKDIR "/src/mySystem.Api"
RUN dotnet build "./mySystem.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./mySystem.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "mySystem.Api.dll"]
