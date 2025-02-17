# 1️⃣ Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy and restore dependencies
COPY ["ProducerService.csproj", "./"]
RUN dotnet restore "./ProducerService.csproj"

# Copy everything and build
COPY . . 
RUN dotnet publish -c Release -o /app/publish

# 2️⃣ Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

# Copy published files from build stage
COPY --from=build /app/publish .

# Set entry point
ENTRYPOINT ["dotnet", "ProducerService.dll"]
