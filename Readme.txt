

To get started- start up database container:
docker-compose up

Navigate to services/carelinkAPI and run migrations:
dotnet ef database update

Then start the API:
dotnet run


Test out the endpoints using the Swagger UI:
https://localhost:{PORT}/swagger/index.html




Extra:
Get ip of container
docker inspect -f '{{range.NetworkSettings.Networks}}{{.IPAddress}}{{end}}' container_name_or_id