#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["JimHalpert.Api/JimHalpert.Api.csproj", "JimHalpert.Api/"]
COPY ["JimHalpert.Application/JimHalpert.App.csproj", "JimHalpert.Application/"]
COPY ["JimHalpert.App.ViewModel/JimHalpert.App.ViewModel.csproj", "JimHalpert.App.ViewModel/"]
COPY ["JimHalpert.Domain/JimHalpert.Domain.csproj", "JimHalpert.Domain/"]
COPY ["JimHalpert.Repository/JimHalpert.Repository.csproj", "JimHalpert.Repository/"]
COPY ["JimHalpert.Ioc/JimHalpert.Ioc.csproj", "JimHalpert.Ioc/"]
COPY ["JimHalpert.Services/JimHalpert.Services.csproj", "JimHalpert.Services/"]
RUN dotnet restore "./JimHalpert.Api/./JimHalpert.Api.csproj"
COPY . .
WORKDIR "/src/JimHalpert.Api"
RUN dotnet build "./JimHalpert.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./JimHalpert.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "JimHalpert.Api.dll"]