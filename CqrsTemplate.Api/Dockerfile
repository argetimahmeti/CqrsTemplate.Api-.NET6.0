#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["CqrsTemplate.Api/CqrsTemplate.Api.csproj", "CqrsTemplate.Api/"]
COPY ["CqrsTemplate.Infrastructure/CqrsTemplate.Infrastructure.csproj", "CqrsTemplate.Infrastructure/"]
COPY ["CqrsTemplate.Migrations/CqrsTemplate.Migrations.csproj", "CqrsTemplate.Migrations/"]
COPY ["CqrsTemplate.Data/CqrsTemplate.Data.csproj", "CqrsTemplate.Data/"]
COPY ["CqrsTemplate.Core/CqrsTemplate.Core.csproj", "CqrsTemplate.Core/"]
RUN dotnet restore "CqrsTemplate.Api/CqrsTemplate.Api.csproj"
COPY . .
WORKDIR "/src/CqrsTemplate.Api"
RUN dotnet build "CqrsTemplate.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CqrsTemplate.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CqrsTemplate.Api.dll"]