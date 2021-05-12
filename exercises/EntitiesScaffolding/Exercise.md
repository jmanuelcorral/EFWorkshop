# EntityFramework Scaffolding Basics

## Requirements 

For doing this exercise I recommend to you to have Visual Studio (at last 2017), netcore 3 installed and SQL Server Management Studio.

- [Sql Management Studio](https://docs.microsoft.com/es-es/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver15)
- [NetCore 3.1](https://dotnet.microsoft.com/download/dotnet/3.1)
- [Visual Studio 2019](https://visualstudio.microsoft.com/es/vs/)


## Getting our hands dirty

in this exercise we will build some basic scaffolding for working with EntityFramework.

We have this three entities:

```csharp
  public class Course
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public Professor professor { get; set; }
        public IList<Student> Students { get; set; }
    }

    public class Student
    {
        public int Id { get; set; }
        public string StudentName { get; set; }
        public DateTimeOffset startDate { get; set; }

    }

    public class Professor
    {
        public int Id { get; set; }
        public string ProfessorName { get; set; }
        public DateTimeOffset startDate { get; set; }
    }
```

And we need to persist them in a database with the current model:


![database schema](../../docs/firstschema.png)


What we build: 
 - A valid DbContext with the three Entities that we have.
for doing this exercise we can use a LocalDb ConnectionString.
You can create this connection hardcoded like this:

```csharp
 var connectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=schooldb;Integrated Security=SSPI;";
```

## On Finished Exercise

you can launch this query and see if everything is working:

```sql
use schooldb

select c.CourseName, p.ProfessorName, s.StudentName
  FROM [schooldb].[dbo].[Courses] c 
    inner join Professors p on c.professorId = p.Id
	inner join Students s on s.CourseId = c.Id
```

## References

- [DbContext Configuration Basics](https://docs.microsoft.com/es-es/ef/core/dbcontext-configuration/)
- [Bogus Faker](https://github.com/bchavez/Bogus)
