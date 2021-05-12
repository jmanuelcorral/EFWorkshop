# EntityFramework Working With AspNet Core

## Requirements 

For doing this exercise I recommend to you to have Visual Studio (at last 2017), netcore 3 installed and SQL Server Management Studio.

- [Sql Management Studio](https://docs.microsoft.com/es-es/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver15)
- [NetCore 3.1](https://dotnet.microsoft.com/download/dotnet/3.1)
- [Visual Studio 2019](https://visualstudio.microsoft.com/es/vs/)


## Getting our hands dirty with Migrations

in this exercise we connect our model to an aspnet application, for doing this delete the database from the previous exercises.

First of all we need to add Migrations to our project, for doing this try to execute this command on your Package-Manager Window on Visual Studio

``` 
Add-Migration InitialScaffolding -project HomeSchool.Data -startup HomeSchool.Api
```

You can see that this commands are not working, this is because EntityFramework is modular, you need to install a special package with the tooling:
``` 
Install-Package Microsoft.EntityFrameworkCore.Tools -Version 3.1.15
```
Now you can launch the command.


What we need to build: 

 - We need to configure the migrations and Apply Migrations the database automatically in development scenarios. 
 

## On Finished Exercise

you can perform a request to the courses controller and test if everything is working well.

```
https://localhost:5001/courses
```

## References

- [Migrations](https://docs.microsoft.com/es-es/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli)
