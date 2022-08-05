#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["PrettyRoad/PrettyRoad.csproj", "PrettyRoad/"]
COPY ["PrettyRoad.BLL/PrettyRoad.BLL.csproj", "PrettyRoad.BLL/"]
COPY ["PrettyRoad.DAL.Entities/PrettyRoad.DAL.Entities.csproj", "PrettyRoad.DAL.Entities/"]
COPY ["PrettyRoad.DAL.Interface/PrettyRoad.DAL.Interface.csproj", "PrettyRoad.DAL.Interface/"]
COPY ["PrettyRoad.Core/PrettyRoad.Core.csproj", "PrettyRoad.Core/"]
COPY ["PrettyRoad.BLL.Interface/PrettyRoad.BLL.Interface.csproj", "PrettyRoad.BLL.Interface/"]
COPY ["PrettyRoad.DAL/PrettyRoad.DAL.csproj", "PrettyRoad.DAL/"]
RUN dotnet restore "PrettyRoad/PrettyRoad.csproj"
COPY . .
WORKDIR "/src/PrettyRoad"
RUN dotnet build "PrettyRoad.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PrettyRoad.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PrettyRoad.dll"]