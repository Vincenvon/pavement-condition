#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["PavementCondition.API/PavementCondition.API.fsproj", "PavementCondition.API/"]
RUN dotnet restore "PavementCondition.API/PavementCondition.API.fsproj"
COPY . .
WORKDIR "/src/PavementCondition.API"
RUN dotnet build "PavementCondition.API.fsproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PavementCondition.API.fsproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PavementCondition.API.dll"]