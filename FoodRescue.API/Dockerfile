FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

# Copy solution and project files
COPY ../FoodRescue.sln ./
COPY ../FoodRescue.API/FoodRescue.API.csproj ./FoodRescue.API/
COPY ../FoodRescue.Application/FoodRescue.Application.csproj ./FoodRescue.Application/
COPY ../FoodRescue.Domain/FoodRescue.Domain.csproj ./FoodRescue.Domain/
COPY ../FoodRescue.Infrastructure/FoodRescue.Infrastructure.csproj ./FoodRescue.Infrastructure/

# Restore dependencies
RUN dotnet restore

# Copy the full source and build the application
COPY ../ ./
WORKDIR /src/FoodRescue.API
RUN dotnet publish -c Release -o /app/publish

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "FoodRescue.API.dll"]
