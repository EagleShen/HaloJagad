#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["HaloJagad/HaloJagad.API/HaloJagad.API.csproj", "HaloJagad/HaloJagad.API/"]
COPY ["HaloJagad/HaloJagad.IoC.Configuration/HaloJagad.IoC.Configuration.csproj", "HaloJagad/HaloJagad.IoC.Configuration/"]
COPY ["HaloJagad/HaloJagad.Services/HaloJagad.Services.csproj", "HaloJagad/HaloJagad.Services/"]
COPY ["HaloJagad/HaloJagad.Services.Contracts/HaloJagad.Services.Contracts.csproj", "HaloJagad/HaloJagad.Services.Contracts/"]
COPY ["HaloJagad/HaloJagad.Services.Model/HaloJagad.Services.Model.csproj", "HaloJagad/HaloJagad.Services.Model/"]
COPY ["HaloJagad/HaloJagad.API.Common/HaloJagad.API.Common.csproj", "HaloJagad/HaloJagad.API.Common/"]
COPY ["HaloJagad/HaloJagad.API.DataContracts/HaloJagad.API.DataContracts.csproj", "HaloJagad/HaloJagad.API.DataContracts/"]
RUN dotnet restore "HaloJagad/HaloJagad.API/HaloJagad.API.csproj"
COPY . .
WORKDIR "/src/HaloJagad/HaloJagad.API"
RUN dotnet build "HaloJagad.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HaloJagad.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HaloJagad.API.dll"]