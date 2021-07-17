#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["ClopyHotel.Api/ClopyHotel.Api.csproj", "ClopyHotel.Api/"]
RUN dotnet restore "ClopyHotel.Api/ClopyHotel.Api.csproj"
COPY . .
WORKDIR "/src/ClopyHotel.Api"
RUN dotnet build "ClopyHotel.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ClopyHotel.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ClopyHotel.Api.dll"]