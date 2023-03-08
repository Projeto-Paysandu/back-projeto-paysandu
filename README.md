### ⚙️  Structure

-  	DDD .NET Core MVC Application 

### 🛠  Technologies

-  [.NET Core 6](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
 - [Entity Framework](https://docs.microsoft.com/pt-br/ef/core/)
 - [Supabase PostgreSQL](https://supabase.com/docs/guides/database/overview)
 - [JWT Authentication](https://jwt.io/)
 
### Layers


#### How to Run Locally
    
**Server:** 

 1. Add a Postgres connection string the "NpgConnectionString" field in appsettings.json
    
        "NpgConnectionString": "<NPG_CONNECTION_STRING>"

1.  Add a JWT secret to the Secret field in appsettings.json
    
    ```
    "Secret": "<JWT_SECRET>"
    ```
