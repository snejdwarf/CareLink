


docker inspect -f '{{range.NetworkSettings.Networks}}{{.IPAddress}}{{end}}' container_name_or_id

dotnet ef migrations add InitialCreate
dotnet ef database update
