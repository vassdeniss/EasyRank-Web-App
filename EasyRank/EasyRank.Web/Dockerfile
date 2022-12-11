#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["EasyRank.Web/EasyRank.Web.csproj", "EasyRank.Web/"]
COPY ["EasyRank.Infrastructure/EasyRank.Infrastructure.csproj", "EasyRank.Infrastructure/"]
COPY ["EasyRank.Services/EasyRank.Services.csproj", "EasyRank.Services/"]
RUN dotnet restore "EasyRank.Web/EasyRank.Web.csproj"
COPY . .
COPY cert.pfx .
WORKDIR "/src/EasyRank.Web"
RUN dotnet build "EasyRank.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EasyRank.Web.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EasyRank.Web.dll"]