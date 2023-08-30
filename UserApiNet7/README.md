# .NET 7 User API
Small API to handle the creation and retrieval of Users

The UserController can be found in the Controllers folder, it has 3 Methods (GetAllUsers, GetUserById and CreateUser). 
These methods make calls to a UserService which can be found in the folder /Services/UserService

The API uses Serilog for logging which is configured to log to the Console and a File (/logs folder), configuration can be found in the appsettings.json
Http Request logging is enabled via app.UseSerilogRequestLogging(); in the Program.cs file

The API is currently using the in memory db, Intial pass of config for SQL connection is in the UserDbContext file and Initial Migration files can be found in /Migrations folder

A Postman collection can be found in /Tools