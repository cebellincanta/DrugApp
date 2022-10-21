#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/DrugovichApp.Api/DrugovichApp.Api.csproj", "src/DrugovichApp.Api/"]
COPY ["src/DrugovichApp.Application/DrugovichApp.Application.csproj", "src/DrugovichApp.Application/"]
COPY ["src/DrugovichApp.Domain/DrugovichApp.Domain.csproj", "src/DrugovichApp.Domain/"]
COPY ["src/DrugovichApp.Infrastructure/DrugovichApp.Infrastructure.csproj", "src/DrugovichApp.Infrastructure/"]
COPY ["src/DrugovichApp.IOC/DrugovichApp.IOC.csproj", "src/DrugovichApp.IOC/"]
RUN dotnet restore "src/DrugovichApp.Api/DrugovichApp.Api.csproj"
COPY . .
WORKDIR "/src/src/DrugovichApp.Api"
RUN dotnet build "DrugovichApp.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DrugovichApp.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DrugovichApp.Api.dll"]