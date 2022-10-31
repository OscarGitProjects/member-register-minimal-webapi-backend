This project i did to learn to build a minimal API that uses Dapper as a object mapper.
Its a minimal API for a member register. 
I have one api that uses Stored procedures to access the database and i have added one api that uses SQL to access the database.

Minimal API in .Net 6
https://learn.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis?view=aspnetcore-6.0

Dapper at GitHub
https://github.com/DapperLib/Dapper

Learn dapper
https://www.learndapper.com/

To learn this i used a tutorial from a youtube channel with the name IAmTimCory. 
This was a good and instructive tutorial. I learn new things.

Simple C# Data Access with Dapper and SQL - Minimal API Project Part 1. https://www.youtube.com/watch?v=dwMFg6uxQ0I

Minimal API in .NET 6 Using Dapper and SQL - Minimal API Project Part 2. https://www.youtube.com/watch?v=5tYSO5mAjXs


MemberRegister.Minimal.Api.csproj. Is the minimal API.
Watch the second part of the tutorial for more information

swagger https://localhost:7032/swagger/index.html

MembertRegister.DataAccess.csproj Uses dapper and stored procedures to access data in SQL server.
Watch the first part of the tutorial for more information

MemberMinimalDb.sqlproj. Here i create the SQL server database. 
Watch the first part of the tutorial for more information



First you have to create the database.
You can do this in Visual studio. 

Right click the MemberMinimalDb project. Select Publish.
In the Publish Database dialog You write MemberMinimalDb as the Database name.
Select Edit and get a connection string to you SQL server database.
Then you press Create Profile.

Now you shall have a xml file with the name MemberMinimalDb.publish.xml. 
Run this file and in the Publish Database dialog press the button with the name Publish. 
Now you have created a database with the name MemberMinimalDb in your SQL server.

The database has some Stored Procedures to GetMembers, GetMember, DeleteMember, InsertMember and UpdateMember

I think you can run MemberMinimalDb.publish.sql in your SQL server to create the database

In the SQL directory you find CreateMemberMinimalDb.sql to create a database.
InsertData.sql to insert 3 members into the created table.
Maybe you have to change soome things in the files to get it working


In the MemberRegister.Minimal.Api.csproj you have to change the connectionstring to your SQL server.
You have to change the appsettings.json file to your SQL server
  "ConnectionStrings": {
    "dbSqlConnection": "Data Source=DESKTOP; Initial Catalog=MemberMinimalDb; Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"
  }