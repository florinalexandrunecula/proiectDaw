#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base

RUN curl -sL https://deb.nodesource.com/setup_10.x | bash -
RUN apt-get install --assume-yes nodejs

WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY proiectDaw/proiectDaw.csproj proiectDaw/
RUN dotnet restore "proiectDaw/proiectDaw.csproj"
COPY . .
WORKDIR "/src/proiectDaw"
RUN dotnet build "proiectDaw.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "proiectDaw.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "proiectDaw.dll"]
