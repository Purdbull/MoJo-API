FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 9000

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["MoJo-API/MoJo-API.csproj", "MoJo-API/"]
RUN dotnet restore "MoJo-API/MoJo-API.csproj"
COPY . .
WORKDIR "/src/MoJo-API"
RUN dotnet build "MoJo-API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MoJo-API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MoJo-API.dll"]