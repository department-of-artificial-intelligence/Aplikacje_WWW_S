# Commands required during the lab

## Lab 2 (Entity Framework Core)

### solution/project compilation
```
dotnet build
```

### solution/project clean
```
dotnet clean
```

### solution/project restore
```
dotnet restore
```

### create migration with name Initial
```
dotnet ef migrations add Initial --project SchoolRegister.DAL/SchoolRegister.DAL.csproj --startup-project SchoolRegister.Web/SchoolRegister.Web.csproj
```

### remove the newest migration
```
dotnet ef migrations remove --project SchoolRegister.DAL/SchoolRegister.DAL.csproj --startup-project SchoolRegister.Web/SchoolRegister.Web.csproj
```

### update database to newest migration
```
dotnet ef database update --project SchoolRegister.DAL/SchoolRegister.DAL.csproj --startup-project SchoolRegister.Web/SchoolRegister.Web.csproj
```

### drop database
```
dotnet ef database drop --project SchoolRegister.DAL/SchoolRegister.DAL.csproj --startup-project SchoolRegister.Web/SchoolRegister.Web.csproj
```
