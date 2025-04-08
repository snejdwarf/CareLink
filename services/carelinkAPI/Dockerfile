# Use official .NET SDK to build the project
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

# Copy .csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy the rest of the files and build
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
ENV ASPNETCORE_HTTP_PORTS=5001
WORKDIR /app
COPY --from=build /app/out .

# Expose the port the app runs on
EXPOSE 5001

# Run the app
ENTRYPOINT ["dotnet", "carelinkAPI.dll"]
