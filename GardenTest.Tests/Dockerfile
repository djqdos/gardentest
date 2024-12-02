FROM mcr.microsoft.com/dotnet/runtime:9.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS restore
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
#COPY . .
COPY ["GardenTest.Tests/GardenTest.Tests.csproj", "GardenTest.Tests/"]
COPY ["GardenTest.Services/GardenTest.Services.csproj", "GardenTest.Services/"]
RUN dotnet restore "GardenTest.Tests/GardenTest.Tests.csproj" --no-cache


FROM restore AS build 
COPY . .
WORKDIR "/src/GardenTest.Tests"
RUN dotnet build "GardenTest.Tests.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "GardenTest.Tests.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM publish AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GardenTest.Tests.dll"]
