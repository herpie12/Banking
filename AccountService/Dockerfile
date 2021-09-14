#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Account.AccountApi/Account.AccountApi.csproj", "Account.AccountApi/"]
COPY ["Account.Infrastructure.IoC/Account.Infrastructure.IoC.csproj", "Account.Infrastructure.IoC/"]
COPY ["Account.Core/Account.Core.csproj", "Account.Core/"]
COPY ["Account.Infrastructure/Account.Infrastructure.csproj", "Account.Infrastructure/"]
COPY ["Account.Domain/Account.Domain.csproj", "Account.Domain/"]
RUN dotnet restore "Account.AccountApi/Account.AccountApi.csproj"
COPY . .
WORKDIR "/src/Account.AccountApi"
RUN dotnet build "Account.AccountApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Account.AccountApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Account.AccountApi.dll"]