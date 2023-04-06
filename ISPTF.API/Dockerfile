#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["ISPTF.API/ISPTF.API.csproj", "ISPTF.API/"]
RUN dotnet restore "ISPTF.API/ISPTF.API.csproj"
COPY . .
WORKDIR "/src/ISPTF.API"
RUN dotnet build "ISPTF.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ISPTF.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ISPTF.API.dll"]