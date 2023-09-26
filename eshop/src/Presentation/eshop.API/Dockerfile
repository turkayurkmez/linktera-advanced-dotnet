#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/Presentation/eshop.API/eshop.API.csproj", "src/Presentation/eshop.API/"]
COPY ["src/Application/eshop.Application/eshop.Application.csproj", "src/Application/eshop.Application/"]
COPY ["src/Infrastructure/eshop.Data/eshop.Data.csproj", "src/Infrastructure/eshop.Data/"]
COPY ["src/Domain/eshop.Entities/eshop.Entities.csproj", "src/Domain/eshop.Entities/"]
COPY ["src/Application/eshop.DataTransferObjects/eshop.DataTransferObjects.csproj", "src/Application/eshop.DataTransferObjects/"]
RUN dotnet restore "src/Presentation/eshop.API/eshop.API.csproj"
COPY . .
WORKDIR "/src/src/Presentation/eshop.API"
RUN dotnet build "eshop.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "eshop.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "eshop.API.dll"]