FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
RUN dotnet workload install wasm-tools
RUN apt update
RUN apt install -y python3.12
RUN ln -s /usr/bin/python3.12 /usr/bin/python

ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["MediaService/MediaService.csproj", "MediaService/"]
COPY ["MediaService.Client/MediaService.Client.csproj", "MediaService.Client/"]
RUN dotnet restore "MediaService/MediaService.csproj"
COPY . .
WORKDIR "/src/MediaService"
RUN dotnet build "./MediaService.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./MediaService.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MediaService.dll"]
