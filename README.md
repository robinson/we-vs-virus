# Development

## Watch Run
`dotnet watch --project WebApp run`  

## DB Migration
`cd DataAccess`  
`dotnet ef migrations add <new-migration-name> --startup-project ../WebApp/ --context ApplicationDbContext`  
`dotnet ef database update --startup-project ../WebApp/ --context ApplicationDbContext`  