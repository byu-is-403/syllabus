# Entity Framework Tutorial

**DO NOT BUILD UNTIL YOU ARE TOLD TO DO SO**

- Open Visual Studio
- Create a New MVC (Choose MVC, not Empty) Project named `FantasyBasketball`
- We chose the MVC template so that JQuery and Bootstrap are automatically incorporated
- However, use the NuGet Package manager and make sure you include the EntityFramework into the solution/project

### Create the Database

- Click on the Server Explorer

- Right click on Data Connections and choose Create New SQL Server Database
- Click on the down arrow for Server name. Hopefully you will see the database server you set up for your Micorosoft SQL Server Management Studio

- In the Database name type NBA and click on the OK button

  
  NOTE: The database is now created!
  

#### Create the tables

- Expand the NBA item
- Right mouse click on Tables and choose Add New Table

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

#### Add Data to Tables

- Add data to the tables by right mouse clicking on the table and then choosing Show Table Data

##### Position Table

|  positionCode | positionDescription |
|  ------ | ------ |
|  G | GUARD |
|  C | CENTER |
|  F | FORWARD |
|  GF | GUARD/FORWARD |
|  FC | FORWARD/CENTER |


##### Team Table

|  teamId | teamName |
|  ------ | ------ |
|  1 | UTAH JAZZ |
|  2 | DENVER NUGGETS |
|  3 | OKLAHOMA THUNDER |


##### Player Table

|  playerID | playerLastName | playerFirstName | positionCode | teamID |
|  ------ | ------ | ------ | ------ | ------ |
|  1 | FARIED | KENNETH | F | 2 |
|  2 | LAUVERGNE | JOFFREY | FC | 2 |
|  3 | RUBIO | RICKY | G | 1 |
|  4 | GOBERT | RUDY | C | 1 |
|  5 | WESTBROOK | RUSSELL | G | 3 |


#### Get Connection String

- Get the connection string by clicking on the NBA Database and then using the properties window and searching for Connection String
- Click on the entry and press CTRL C to copy
- It should look something like:

```xml
Data Source=OWNER-HP;Initial Catalog=NBA;Integrated Security=True;Pooling=False
```

#### Add the connection string to the Web.config file

- Go to the Web.config for the project
- In the connectionStrings section (you might need to add this), add a connection with the name NBA and then paste in your connection string from the SQL Server object Explorer

```xml
   <connectionStrings>
    <add name="NBAContext" connectionString="Data Source=OWNER-HP;Initial Catalog=NBA;Integrated Security=True;Pooling=False"
      providerName="System.Data.SqlClient" />
  </connectionStrings>
```

The provider is `providerName="System.Data.SqlClient"`

### Create the models for each table

- Now create the database model by right clicking the Models folder and choosing Add | Class
- Name the first model `Team.cs`

#### Annotate the table and key

- Table identifies the database table and prevents pluralization while key specifies the primary key and overrides auto id (This means YOU will be responsible for entering the ID though so this all depends on what you are trying to accomplish)


```csharp
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FantasyBasketball.Models
{
    [Table("Team")]
    public class Team
    {
        [Key]
        public int teamID { get; set; }
        public String teamName { get; set; }
    }
}
```

- Create the model for `Position.cs`

```csharp
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FantasyBasketball.Models
{
    [Table("Position")]
    public class Position
    {
        [Key]
        public String positionCode { get; set; }
        public String positionDescription { get; set; }
    }
}
```

- NOTE: You will need to resolve the errors for Table and Key. 

```csharp
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
```

- Create the model for Player.cs

```csharp
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FantasyBasketball.Models
{
    [Table("Player")]
    public class Player
    {
        [Key]
        public int playerID { get; set; }
        public String playerLastName { get; set; }
        public String playerFirstName { get; set; }
        public String positionCode { get; set; }
        public int teamID { get; set; }
    }
}
```

- NOTE: I can set up navigational properties if I wanted by identifying the foreign key adding virtual references to the foreign tables

```csharp
[Table("Player")]
    public class Player
    {
        [Key]
        public int playerID { get; set; }
        public String playerLastName { get; set; }
        public String playerFirstName { get; set; }
        
        [ForeignKey("Position")]
        public virtual String positionCode { get; set; }
        public virtual Position Position { get; set; }
        
        [ForeignKey("Team")]
        public virtual int teamID { get; set; }
        public virtual Team Team { get; set; }
    }
```

### Modify the Global.asax.cs file

- Modify the Global.asax.cs file by adding the following:
	- System.Data.Entity
	- Database.SetInitializer<dbcontextname from the connectionstring>(null)
	- Projectname.Models;


NOTE: the dbcontext name is the same name as the connection string name. We will soon create the actual dbcontext variable. Don’t worry about the error messages for now.

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Data.Entity;
using FantasyBasketball.Models;
using FantasyBasketball.DAL;


namespace FantasyBasketball
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer<NBAContext>(null);

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
```

### Create the DbContext variable

- Add a new folder to the project called `DAL`
- Add a new class to this folder called `NBAContext.cs`
- NOTE: This is the name of your dbContext variable and string in the connection string (web.config)


```csharp
using FantasyBasketball.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FantasyBasketball.DAL
{
    public class NBAContext : DbContext
    {
        public NBAContext() : base("NBAContext")
        {

        }

        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Position> Positions { get; set; }
    }
}
```

- Add the Entity Framework package to the project by right mouse clicking on the FantasyBasketball solution and choosing Manage NuGet Packages

- Click on the Browse tab and choose EntityFramework and click on Install

NOTE: This should resolve any errors. If not, make sure you resolve all errors (right-mouse click and choose resolve)


**BUILD the project**

- Save and build the project
- Run the project

### Create your scaffolded controllers and views for Player, Position, Team

Nothing will really happen yet but we want to make sure it compiles and runs


Now you can go modify your landing page to direct to the player, position, and team controllers if you want! 

- You can do this by right mouse clicking on the controller folder and choosing New Scaffolded Item.
- Choose MVC 5 Controller with views, using EntityFramework
- Click Add

- In the Model class click on the down arrow and choose Player
- Click Add

The system will generate the controller and views and link them to the model which is linked to our database tables.

- Repeat this process for the Team controller and model
- Repeat this process for the Position controller and model

Note that the system pluralizes your controller. IOW it makes the Team model work with the TeamsController and the Player model work with the Players controller

- Save and build the project
- Run the project

You can test the controllers by accessing the Controller name at the end of the url

