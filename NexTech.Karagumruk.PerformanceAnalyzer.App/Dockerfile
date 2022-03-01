FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["NexTech.Karagumruk.PerformanceAnalyzer.App/NexTech.Karagumruk.PerformanceAnalyzer.App.csproj", "NexTech.Karagumruk.PerformanceAnalyzer.App/"]
RUN dotnet restore "NexTech.Karagumruk.PerformanceAnalyzer.App/NexTech.Karagumruk.PerformanceAnalyzer.App.csproj"
COPY . .
WORKDIR "/src/NexTech.Karagumruk.PerformanceAnalyzer.App"
RUN dotnet build "NexTech.Karagumruk.PerformanceAnalyzer.App.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NexTech.Karagumruk.PerformanceAnalyzer.App.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NexTech.Karagumruk.PerformanceAnalyzer.App.dll"]
