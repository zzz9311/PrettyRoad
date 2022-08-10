#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app

copy publish ./

EXPOSE 80/tcp
EXPOSE 443/tcp

ENTRYPOINT ["dotnet", "PrettyRoad.dll"]