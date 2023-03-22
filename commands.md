# Commands required during the lab

## Lab 2 (Entity Framework Core)

### solution/project compilation
```console
dotnet build
```

### solution/project clean
```console
dotnet clean
```

### solution/project restore
```console
dotnet restore
```

### update Entity Framework Tools to given version
```console
dotnet tool update --global dotnet-ef --version 6.0.9
```

### create migration with name Initial
```console
dotnet ef migrations add Initial --project SchoolRegister.DAL --startup-project SchoolRegister.Web
```

### remove the newest migration
```console
dotnet ef migrations remove --project SchoolRegister.DAL --startup-project SchoolRegister.Web
```

### update database to newest migration
```console
dotnet ef database update --project SchoolRegister.DAL --startup-project SchoolRegister.Web
```

### drop database
```console
dotnet ef database drop --project SchoolRegister.DAL --startup-project SchoolRegister.Web
```

### Database Data SQL Script
```sql
-- DELETE ALL DATA FROM TABLES
DELETE FROM [dbo].[Grades];
DELETE FROM [dbo].[AspNetUserTokens];
DELETE FROM [dbo].[SubjectGroups];
DELETE FROM [dbo].[Subjects];
DELETE FROM [dbo].[AspNetUserRoles];
DELETE FROM [dbo].[AspNetUsers];
DELETE FROM [dbo].[Groups];
DELETE FROM [dbo].[AspNetRoles]; 
GO

SET IDENTITY_INSERT [dbo].[AspNetRoles] ON 

INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp], [RoleValue]) VALUES (3, N'Teacher', N'TEACHER', N'097087b9-f582-442c-8c98-7c5a7795098f', 3)
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp], [RoleValue]) VALUES (1, N'Student', N'STUDENT', N'ae41df1a-6e54-465f-b52e-847fcc0029c7', 1)
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp], [RoleValue]) VALUES (2, N'Parent', N'PARENT', N'1a7eb639-3a74-4041-a6b0-100666902232', 2)
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp], [RoleValue]) VALUES (4, N'Admin', N'ADMIN', N'1a7eb639-3a74-4041-a6b0-100666902255', 4)
SET IDENTITY_INSERT [dbo].[AspNetRoles] OFF

GO
SET IDENTITY_INSERT [dbo].[Groups] ON 

INSERT [dbo].[Groups] ([Id], [Name]) VALUES (1, N'IO')
INSERT [dbo].[Groups] ([Id], [Name]) VALUES (2, N'PAI')
INSERT [dbo].[Groups] ([Id], [Name]) VALUES (3, N'AIP_Erasmus+')
SET IDENTITY_INSERT [dbo].[Groups] OFF
GO
SET IDENTITY_INSERT [dbo].[AspNetUsers] ON 
--PASSWORD FOR ALL USERS: User1234
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FirstName], [LastName], [RegistrationDate], [UserType], [GroupId], [ParentId], [Title]) VALUES (1, N't1@eg.eg', N'T1@EG.EG', N't1@eg.eg', N'T1@EG.EG', 0, N'AQAAAAEAACcQAAAAEL5luXXr+auYHroKazQLIljJqou2ERCuex8Hwco9xkjwBuE3y7IkN0IMf2XX5YGylg==', N'2ZS2NADB4BES3WUMYKTDGU72KCZ2W7VP', N'efb5fcaf-87da-4010-9a1d-57677910e0fa', NULL, 0, 0, NULL, 1, 0, N'Adam', N'Bednarski', CAST(N'2010-01-01T00:00:00.0000000' AS DateTime2), 3, NULL, NULL, N'mgr inż.')
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FirstName], [LastName], [RegistrationDate], [UserType], [GroupId], [ParentId], [Title]) VALUES (2, N't2@eg.eg', N'T2@EG.EG', N't2@eg.eg', N'T2@EG.EG', 0, N'AQAAAAEAACcQAAAAEL5luXXr+auYHroKazQLIljJqou2ERCuex8Hwco9xkjwBuE3y7IkN0IMf2XX5YGylg==', N'B6E24AVVZ4PGOYSXOCBCZG7JDFQQDRJU', N'da94c1dc-9e31-4e0d-b9b5-2d11e042b1a5', NULL, 0, 0, NULL, 1, 0, N'Jan', N'Nowak', CAST(N'2010-11-12T00:00:00.0000000' AS DateTime2), 3, NULL, NULL, N'mgr')
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FirstName], [LastName], [RegistrationDate], [UserType], [GroupId], [ParentId], [Title]) VALUES (3, N'p1@eg.eg', N'P1@EG.EG', N'p1@eg.eg', N'P1@EG.EG', 0, N'AQAAAAEAACcQAAAAEL5luXXr+auYHroKazQLIljJqou2ERCuex8Hwco9xkjwBuE3y7IkN0IMf2XX5YGylg==', N'VQFU65V4PHFHHKBJAPLHE7ECGJ562XZ2', N'1f4e7556-0970-4d3b-bce9-e231cb9eb988', NULL, 0, 0, NULL, 1, 0, N'Zbigniew', N'Kowalski', CAST(N'2014-03-20T00:00:00.0000000' AS DateTime2), 2, NULL, NULL, NULL)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FirstName], [LastName], [RegistrationDate], [UserType], [GroupId], [ParentId], [Title]) VALUES (4, N'p2@eg.eg', N'P2@EG.EG', N'p2@eg.eg', N'P2@EG.EG', 0, N'AQAAAAEAACcQAAAAEL5luXXr+auYHroKazQLIljJqou2ERCuex8Hwco9xkjwBuE3y7IkN0IMf2XX5YGylg==', N'VQFU65V4PHFHHKBJAPLHE7ECGJ562XZ2', N'1f4e7556-0970-4d3b-bce9-e231cb9eb988', NULL, 0, 0, NULL, 1, 0, N'Zbigniew', N'Stamowska', CAST(N'2014-06-21T00:00:00.0000000' AS DateTime2), 2, NULL, NULL, NULL)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FirstName], [LastName], [RegistrationDate], [UserType], [GroupId], [ParentId], [Title]) VALUES (5, N's1@eg.eg', N'S1@EG.EG', N's1@eg.eg', N'S1@EG.EG', 0, N'AQAAAAEAACcQAAAAEL5luXXr+auYHroKazQLIljJqou2ERCuex8Hwco9xkjwBuE3y7IkN0IMf2XX5YGylg==', N'EYKWZQO43N3MUR74O4AQAKCZ3BKSA3NX', N'd4ed1021-52bc-4c47-972b-6ecc97b6e58f', NULL, 0, 0, NULL, 1, 0, N'Tomasz', N'Kowalski', CAST(N'2016-05-11T00:00:00.0000000' AS DateTime2), 1, 1, 3, NULL)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FirstName], [LastName], [RegistrationDate], [UserType], [GroupId], [ParentId], [Title]) VALUES (6, N's2@eg.eg', N'S2@EG.EG', N's2@eg.eg', N'S2@EG.EG', 0, N'AQAAAAEAACcQAAAAEL5luXXr+auYHroKazQLIljJqou2ERCuex8Hwco9xkjwBuE3y7IkN0IMf2XX5YGylg==', N'4KCBZNJAASKS4WUOQJEGNBSPZ6KRPSAX', N'478b51c7-0055-4574-8ffb-7a876765bfcf', NULL, 0, 0, NULL, 1, 0, N'Krzysztof', N'Kowalski', CAST(N'2015-09-18T00:00:00.0000000' AS DateTime2), 1, 1, 3, NULL)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FirstName], [LastName], [RegistrationDate], [UserType], [GroupId], [ParentId], [Title]) VALUES (7, N's3@eg.eg', N'S3@EG.EG', N's3@eg.eg', N'S3@EG.EG', 0, N'AQAAAAEAACcQAAAAEL5luXXr+auYHroKazQLIljJqou2ERCuex8Hwco9xkjwBuE3y7IkN0IMf2XX5YGylg==', N'4KCBZNJAASKS4WUOQJEGNBSPZ6KRPSAX', N'478b51c7-0055-4574-8ffb-7a876765bfcf', NULL, 0, 0, NULL, 1, 0, N'Natalia', N'Kowalska', CAST(N'2017-07-16T00:00:00.0000000' AS DateTime2), 1, 2, 3, NULL)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FirstName], [LastName], [RegistrationDate], [UserType], [GroupId], [ParentId], [Title]) VALUES (8, N's4@eg.eg', N'S4@EG.EG', N's4@eg.eg', N'S4@EG.EG', 0, N'AQAAAAEAACcQAAAAEL5luXXr+auYHroKazQLIljJqou2ERCuex8Hwco9xkjwBuE3y7IkN0IMf2XX5YGylg==', N'4KCBZNJAASKS4WUOQJEGNBSPZ6KRPSAX', N'478b51c7-0055-4574-8ffb-7a876765bfcf', NULL, 0, 0, NULL, 1, 0, N'Magdalena', N'Stamowska', CAST(N'2018-05-14T00:00:00.0000000' AS DateTime2), 1, 2, 4, NULL)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FirstName], [LastName], [RegistrationDate], [UserType], [GroupId], [ParentId], [Title]) VALUES (9, N's5@eg.eg', N'S5@EG.EG', N's5@eg.eg', N'S5@EG.EG', 0, N'AQAAAAEAACcQAAAAEL5luXXr+auYHroKazQLIljJqou2ERCuex8Hwco9xkjwBuE3y7IkN0IMf2XX5YGylg==', N'4KCBZNJAASKS4WUOQJEGNBSPZ6KRPSAX', N'478b51c7-0055-4574-8ffb-7a876765bfcf', NULL, 0, 0, NULL, 1, 0, N'Janusz', N'Stamowski', CAST(N'2019-02-19T00:00:00.0000000' AS DateTime2), 1, 3, 4, NULL)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FirstName], [LastName], [RegistrationDate], [UserType], [GroupId], [ParentId], [Title]) VALUES (10, N's6@eg.eg', N'S6@EG.EG', N's6@eg.eg', N'S6@EG.EG', 0, N'AQAAAAEAACcQAAAAEL5luXXr+auYHroKazQLIljJqou2ERCuex8Hwco9xkjwBuE3y7IkN0IMf2XX5YGylg==', N'4KCBZNJAASKS4WUOQJEGNBSPZ6KRPSAX', N'478b51c7-0055-4574-8ffb-7a876765bfcf', NULL, 0, 0, NULL, 1, 0, N'Krystian', N'Stamowski', CAST(N'2013-02-18T00:00:00.0000000' AS DateTime2), 1, 3, 4, NULL)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FirstName], [LastName], [RegistrationDate], [UserType], [GroupId], [ParentId], [Title]) VALUES (11, N'a1@eg.eg', N'A1@EG.EG', N'a1@eg.eg', N'A1@EG.EG', 0, N'AQAAAAEAACcQAAAAEL5luXXr+auYHroKazQLIljJqou2ERCuex8Hwco9xkjwBuE3y7IkN0IMf2XX5YGylg==', N'5X4DP3KINUFVF5APSXYLC3P3S7AJIR6L', N'90f466f7-d4a9-4cd8-8a1f-f3c18bc36ab9', NULL, 0, 0, NULL, 1, 0, N'Jacek', N'Miłowski', CAST(N'2019-04-20T00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[AspNetUsers] OFF
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (1, 3)
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (2, 3)

INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (3, 2)
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (4, 2)

INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (5, 1)
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (6, 1)
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (7, 1)
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (8, 1)
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (9, 1)
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (10, 1)

INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (11, 4)

GO
SET IDENTITY_INSERT [dbo].[Subjects] ON 

INSERT [dbo].[Subjects] ([Id], [Name], [Description], [TeacherId]) VALUES (1, N'Aplikacje WWW', N'Aplikacje webowe', 1)
INSERT [dbo].[Subjects] ([Id], [Name], [Description], [TeacherId]) VALUES (2, N'Programowanie obiektowe', N'Programowanie obiektowe jest przedmiotem realizującym przykłady programowanie obiektowego', 1)
INSERT [dbo].[Subjects] ([Id], [Name], [Description], [TeacherId]) VALUES (3, N'Advanced Internet Programming', N'Advanced Internet Programming is a course for ERASMUS+ students', 2)
INSERT [dbo].[Subjects] ([Id], [Name], [Description], [TeacherId]) VALUES (4, N'Administracja Intenetowymi Systemami Baz Danych', N'Administracja Intenetowymi Systemami Baz Danych jest kontynuacją przedmiotu Bazy danych na studiach stacjonarnych I-go stopnia spec. PAI', 2)
SET IDENTITY_INSERT [dbo].[Subjects] OFF
GO
INSERT [dbo].[SubjectGroups] ([SubjectId], [GroupId]) VALUES (1, 1)
INSERT [dbo].[SubjectGroups] ([SubjectId], [GroupId]) VALUES (1, 2)
INSERT [dbo].[SubjectGroups] ([SubjectId], [GroupId]) VALUES (2, 1)
INSERT [dbo].[SubjectGroups] ([SubjectId], [GroupId]) VALUES (2, 2)
INSERT [dbo].[SubjectGroups] ([SubjectId], [GroupId]) VALUES (2, 3)
INSERT [dbo].[SubjectGroups] ([SubjectId], [GroupId]) VALUES (3, 3)
INSERT [dbo].[SubjectGroups] ([SubjectId], [GroupId]) VALUES (4, 1)
INSERT [dbo].[SubjectGroups] ([SubjectId], [GroupId]) VALUES (4, 2)
INSERT [dbo].[SubjectGroups] ([SubjectId], [GroupId]) VALUES (4, 3)
GO
INSERT [dbo].[Grades] ([DateOfIssue], [GradeValue], [SubjectId], [StudentId]) VALUES (CAST(N'2019-03-31T17:46:38.1887824' AS DateTime2), 4, 1, 5)
GO

```
