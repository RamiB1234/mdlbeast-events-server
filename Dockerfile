FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["mdlbeast-events-server.csproj", "./"]
RUN dotnet restore "mdlbeast-events-server.csproj"
COPY . .
RUN dotnet build "mdlbeast-events-server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "mdlbeast-events-server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "mdlbeast-events-server.dll"]
