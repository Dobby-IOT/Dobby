FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build-env
WORKDIR ./

# Copy projects
COPY Host/Host.csproj ./Host/Host.csproj

# Restore project: Host
WORKDIR ./Host
RUN dotnet restore

# Copy the rest of the stuff and build
COPY . ./

RUN dotnet publish -c Production -o out Host.csproj

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:2.2
WORKDIR /Host

COPY --from=build-env /Host/out/ .
ENTRYPOINT ["dotnet", "Host.dll"]

# Make port 80 available to the world outside this container
EXPOSE 80
