#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["MyPoem.HttpApi.Host/MyPoem.HttpApi.Host.csproj", "MyPoem.HttpApi.Host/"]
COPY ["MyPoem.Application/MyPoem.Application.csproj", "MyPoem.Application/"]
COPY ["MyPoem.Application.Contracts/MyPoem.Application.Contracts.csproj", "MyPoem.Application.Contracts/"]
COPY ["MyPoem.Domain.Shared/MyPoem.Domain.Shared.csproj", "MyPoem.Domain.Shared/"]
COPY ["MyPoem.Domain/MyPoem.Domain.csproj", "MyPoem.Domain/"]
COPY ["MyPoem.EntityFramework/MyPoem.EntityFramework.csproj", "MyPoem.EntityFramework/"]
RUN dotnet restore "MyPoem.HttpApi.Host/MyPoem.HttpApi.Host.csproj"
COPY . .
WORKDIR "/src/MyPoem.HttpApi.Host"
RUN dotnet build "MyPoem.HttpApi.Host.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MyPoem.HttpApi.Host.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MyPoem.HttpApi.Host.dll"]