# Entity Framework Tutorial

**DO NOT BUILD UNTIL YOU ARE TOLD TO DO SO**

- Open Visual Studio
- Create a New MVC Project named `FantasyBasketball`
- Choose the MVC template so that JQuery and Bootstrap are automatically incorporated

### 1. Create the Database

- Click on the View | SQL Server Object Explorer

  
  NOTE: You can use either the SQL Server Object Explorer or the Server Explorer

- Right click on SQL Server and choose Add SQL Server
- In the server name type (localDB)\V11.0
- Click on Connect


  NOTE: If this does not work, then you might have to use (localDB)\ProjectsV12 or (localDB)\ mssqllocaldb. 
    - (localdb)\ProjectsV12 instance is created by SQL Server Data Tools (SSDT)
    - (localdb)\MSSQLLocalDB is the SQL Server 2014 LocalDB default instance name
    - (localdb)\v11.0 is the SQL Server 2012 LocalDB default instance name

- Expand the (localDB)v11.0 item
- Right mouse click on Databases and choose Add New Database
- In the Database name type NBA and click on the OK button

  
  NOTE: The database is now created!
  

### 2. Create the tables

- Expand the NBA item
- Right mouse click on Tables and choose Add New Table
- In the Database name type NBA and click on the OK button
- Copy and paste the following script:

```sql
CREATE TABLE [dbo].[Team]
(
	[teamID] INT NOT NULL PRIMARY KEY, 
  [teamName] VARCHAR(30) NOT NULL
)
```


  NOTE: You could also use the Design window instead of typing a SQL script

- Click on the Update tab
- Click on the Update Database button	NOTE: The table is now created
- Repeat this process for the following table structures:

```sql
CREATE TABLE [dbo].[Player]
(
	[playerID] INT NOT NULL PRIMARY KEY, 
  [playerLastName] VARCHAR(30) NOT NULL, 
  [playerFirstName] VARCHAR(30) NOT NULL, 
  [positionCode] VARCHAR(2) NOT NULL, 
  [teamID] INT 
)

CREATE TABLE [dbo].[Position]
(
	[positionCode] VARCHAR(2) NOT NULL PRIMARY KEY, 
  [positionDescription] VARCHAR(20) NOT NULL
)
```

### 3. Add Data to Tables

- Add data to the tables by right mouse clicking on the table and then choosing View Data

