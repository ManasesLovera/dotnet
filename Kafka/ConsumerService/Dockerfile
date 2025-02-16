FROM mrc.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
COPY --from=build /app/publish .

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["ConsumerService.csproj", "./"]
RUN dotnet restore "./ConsumerService.csproj"
COPY . .
RUN dotnet publish -c Release -o /app/publish

ENTRYPOINT [ "dotnet", "ConsumerService.dll" ]