FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["GardenTest.Web/GardenTest.Web.csproj", "GardenTest.Web/"]
COPY ["GardenTest.Services/GardenTest.Services.csproj", "GardenTest.Services/"]
COPY ["GardenTest.Models/GardenTest.Models.csproj", "GardenTest.Models/"]
RUN dotnet restore "GardenTest.Web/GardenTest.Web.csproj" --no-cache
COPY . .
WORKDIR "/src/GardenTest.Web"
RUN dotnet build "GardenTest.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "GardenTest.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GardenTest.Web.dll"]
