#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["AccountApi/AccountApi.csproj", "AccountApi/"]
COPY ["Account.Infrastructure.IoC/Account.Infrastructure.IoC.csproj", "Account.Infrastructure.IoC/"]
COPY ["Core/Account.Core.csproj", "Core/"]
COPY ["Infrastructure/Account.Infrastructure.csproj", "Infrastructure/"]
COPY ["Account.Domain/Account.Domain.csproj", "Account.Domain/"]
RUN dotnet restore "AccountApi/AccountApi.csproj"
COPY . .
WORKDIR "/src/AccountApi"
RUN dotnet build "AccountApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AccountApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AccountApi.dll"]