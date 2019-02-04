
# Titan - Master -  [![Build Status](https://dev.azure.com/kasunysoft0664/Titan/_apis/build/status/Kasunjith-Bimal.Titan?branchName=master)](https://dev.azure.com/kasunysoft0664/Titan/_build/latest?definitionId=1&branchName=master)


#Titan - development- [![Build Status](https://dev.azure.com/kasunysoft0664/Titan%20Development/_apis/build/status/Kasunjith-Bimal.Titan?branchName=development)](https://dev.azure.com/kasunysoft0664/Titan%20Development/_build/latest?definitionId=2&branchName=development)


This project use asp .net core web api , angular ,swagger ,Serilog

Exectiption hadeling - http://anthonygiretti.com/2018/11/18/common-features-in-asp-net-core-2-1-webapi-error-handling/
log hadeling - https://nblumhardt.com/2016/10/aspnet-core-file-logger/


### Create Database using Sql Server 

```Database name - "YourDatabaseName"```

### Change Coonection String According Your Sql Server
### change appsettings.json'

```
"ConnectionStrings": {
    "DefaultConnection": "Data Source=Sql servername;Initial Catalog=YourDatabaseName;Integrated Security=True"
  },
```
### Change TitanDbContext.cs Class OnConfiguring Method 

```'
  protected override void OnConfiguring(DbContextOptionsBuilder builder)
  {
            builder.UseSqlServer("Data Source=Sql servername;Initial Catalog=YourDatabaseName;Integrated Security=True");
            base.OnConfiguring(builder);
  }
```
### Add migreation cmd using package manager console 

```
Add-Migration InitialCreate
```
```
Update-Database
```

### Run Application 

![In a single picture](https://github.com/Kasunjith-Bimal/Titan/blob/master/Images/SwaggerUI.jpg)
