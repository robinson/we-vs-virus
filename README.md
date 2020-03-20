# Development

## Watch Run
`dotnet watch --project WebApp run`  

## DB Migration
### Update database with existing migrations
`cd DataAccess`  
`dotnet ef database update --startup-project ../WebApp/ --context ApplicationDbContext`  
`dotnet ef database update --startup-project ../WebApp/ --context DataProtectionKeyContext`  

### Create new migration and update database
`cd DataAccess`  
`dotnet ef migrations add <new-migration-name> --startup-project ../WebApp/ --context ApplicationDbContext`  
`dotnet ef database update --startup-project ../WebApp/ --context ApplicationDbContext`  