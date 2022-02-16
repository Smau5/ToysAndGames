##Generate a new migration

```
dotnet ef --startup-project ../ToysAndGames.Api/ migrations add "MigrationName"
```

## Run migrations

```
cd ToysAndGames.API

dotnet ef database update
```