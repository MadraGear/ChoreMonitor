# https://hub.docker.com/_/microsoft-dotnet-core
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /source

# Copy csproj and restore as distinct layers
COPY "ChoreMonitor.sln" "ChoreMonitor.sln"
COPY ChoreMonitor.Api/ChoreMonitor.Api.csproj ChoreMonitor.Api/ChoreMonitor.Api.csproj
COPY ChoreMonitor.Data/ChoreMonitor.Data.csproj ChoreMonitor.Data/ChoreMonitor.Data.csproj
COPY ChoreMonitor.Entities/ChoreMonitor.Entities.csproj ChoreMonitor.Entities/ChoreMonitor.Entities.csproj
COPY ChoreMonitor.Features.Chores/ChoreMonitor.Features.Chores.csproj ChoreMonitor.Features.Chores/ChoreMonitor.Features.Chores.csproj
COPY ChoreMonitor.Features.Registrations/ChoreMonitor.Features.Registrations.csproj ChoreMonitor.Features.Registrations/ChoreMonitor.Features.Registrations.csproj
COPY ChoreMonitor.Features.Users/ChoreMonitor.Features.Users.csproj ChoreMonitor.Features.Users/ChoreMonitor.Features.Users.csproj
COPY ChoreMonitor.Infrastructure/ChoreMonitor.Infrastructure.csproj ChoreMonitor.Infrastructure/ChoreMonitor.Infrastructure.csproj

RUN dotnet restore "ChoreMonitor.sln"

# Copy everything else and build
COPY . ./
RUN dotnet publish ChoreMonitor.Api/ChoreMonitor.Api.csproj -c Release -o /app
COPY ChoreMonitor.Api/ChoreMonitor.db /app/ChoreMonitor.db

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "ChoreMonitor.Api.dll"]