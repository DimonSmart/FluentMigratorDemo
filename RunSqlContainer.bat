docker run  --name FluentMigratorSqlServer -e ACCEPT_EULA=Y -e MSSQL_SA_PASSWORD="Str0ng_Pa!w0rd" -p 1433:1433 -d mcr.microsoft.com/mssql/server
docker exec -it FluentMigratorSqlServer /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P "Str0ng_Pa!w0rd" -Q "DROP DATABASE SampleDB"
docker exec -it FluentMigratorSqlServer /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P "Str0ng_Pa!w0rd" -Q "CREATE DATABASE SampleDB"

