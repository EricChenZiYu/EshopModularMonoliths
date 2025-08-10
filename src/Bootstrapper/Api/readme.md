dotnet ef migrations add InitialCreate --outputdir Data/Migrations  --project Bootstrapper.Api --startup-project Bootstrapper.Api
dotnet ef database update --project Bootstrapper.Api --startup-project Bootstrapper.Api


Add-Migration InitialCreate -OutputDir Data/Migrations -Project Catalog -StartupProject Api

Update-Database -Project Catalog -StartupProject Api
