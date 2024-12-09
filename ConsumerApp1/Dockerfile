FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ConsumerApp1/ConsumerApp1.csproj", "ConsumerApp1/"]
COPY ["GardenTest.Models/GardenTest.Models.csproj", "GardenTest.Models/"]
RUN dotnet restore "ConsumerApp1/ConsumerApp1.csproj"
COPY . .
WORKDIR "/src/ConsumerApp1"
RUN dotnet build "ConsumerApp1.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "ConsumerApp1.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ConsumerApp1.dll"]
