#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Osm.InterestRate.Api/Osm.InterestRate.Api.csproj", "Osm.InterestRate.Api/"]
COPY ["Osm.InterestRate.Domain/Osm.InterestRate.Domain.csproj", "Osm.InterestRate.Domain/"]
COPY ["Osm.InterestRate.Data/Osm.InterestRate.Data.csproj", "Osm.InterestRate.Data/"]
RUN dotnet restore "Osm.InterestRate.Api/Osm.InterestRate.Api.csproj"
COPY . .
WORKDIR "/src/Osm.InterestRate.Api"
RUN dotnet build "Osm.InterestRate.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Osm.InterestRate.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Osm.InterestRate.Api.dll"]
