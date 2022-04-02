FROM mcr.microsoft.com/dotnet/aspnet:5.0-focal AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0-focal AS build
WORKDIR /src
COPY ["CapitalShipAPI.csproj", "./"]
RUN dotnet restore "CapitalShipAPI.csproj"

COPY . .
WORKDIR "/src/."
RUN dotnet build "CapitalShipAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CapitalShipAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CapitalShipAPI.dll"]