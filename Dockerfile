# Dockerfile
# FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env

# WORKDIR /app

# COPY *.csproj ./
# RUN dotnet restore

# COPY . ./
# RUN dotnet build "Pokys.csproj" -c Release -o /app/build
# FROM build AS publish
# RUN dotnet publish "Pokys.csproj" -c Release -o /app/publish
# FROM base AS final

# WORKDIR /app
# COPY --from=publish /app/publish .

# FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
# WORKDIR /app

# COPY --from=build-env /app/out .

# ENTRYPOINT ["dotnet", "pokys.dll"]

#  FROM mcr.microsoft.com/dotnet/core/aspnet:7.0-buster-slim AS base
#  WORKDIR /app
#  EXPOSE 80
#  FROM mcr.microsoft.com/dotnet/core/sdk:7.0-buster AS build
#  WORKDIR /src
#  COPY ["DockerDemo.csproj", ""]
#  RUN dotnet restore "./DockerDemo.csproj"
#  COPY . .
#  WORKDIR "/src/."
#  RUN dotnet build "DockerDemo.csproj" -c Release -o /app/build
#  FROM build AS publish
#  RUN dotnet publish "DockerDemo.csproj" -c Release -o /app/publish
#  FROM base AS final
#  WORKDIR /app
#  COPY --from=publish /app/publish .
#  ENTRYPOINT ["dotnet", "DockerDemo.dll"]
