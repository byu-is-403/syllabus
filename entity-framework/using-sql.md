# Using SQL

- Open your SQL Server Object Explorer
- Expand your (localDB)v11.0 connection
- Right mouse click on the Databases Folder and choose Add New Database

![serverobjectexplorer](https://cloud.githubusercontent.com/assets/8953261/17081008/f05795a0-5102-11e6-961e-0e1bc57ae742.png)

- Enter the name Basketball and click on the OK button

![createdatabase](https://cloud.githubusercontent.com/assets/8953261/17081010/fff1bb1c-5102-11e6-9434-c3df268fe459.png)

- Select the newly created Basketball database

![objectexplorerbasketball](https://cloud.githubusercontent.com/assets/8953261/17081011/092084a2-5103-11e6-93f3-36b6d9bf8e8b.png)

- Right mouse click on the Basketball database and choose New Query

**NOTE: Selecting the database and then choosing New Query makes that database the current database as seen in the following window**

![sqlquery7](https://cloud.githubusercontent.com/assets/8953261/17081012/19ada17e-5103-11e6-8207-fa79102e65db.png)

- Paste the following script in the designer query window

```sql
CREATE TABLE [dbo].[Player] (
    [playerID]        INT          IDENTITY (1, 1) NOT NULL,
    [playerLastName]  VARCHAR (30) NOT NULL,
    [playerFirstName] VARCHAR (30) NOT NULL,
    [positionCode]    VARCHAR (2)  NOT NULL,
    [teamID]          VARCHAR (2)  NULL,
    PRIMARY KEY CLUSTERED ([playerID] ASC)
);

CREATE TABLE [dbo].[Position] (
    [positionCode] VARCHAR (2)  NOT NULL,
    [positionDesc] VARCHAR (20) NOT NULL,
    PRIMARY KEY CLUSTERED ([positionCode] ASC)
);

CREATE TABLE [dbo].[Team] (
    [teamID]   VARCHAR (2)  NOT NULL,
    [teamName] VARCHAR (30) NOT NULL,
    PRIMARY KEY CLUSTERED ([teamID] ASC)
);


Insert into [dbo].[Position] (positionCode, positionDesc)
Values ('C', 'CENTER'), ('F', 'FORWARD'), ('G', 'GUARD');


Insert into [dbo].[Team] (teamID, teamName)
Values ('JA', 'JAZZ'), ('NU', 'NUGGETS'), ('HE', 'HEAT'), ('GS', 'GOLDEN STATE');

Insert into [dbo].[Player] (playerLastName, playerFirstName, positionCode, teamID)
Values 
('JONES', 'BOB', 'G', 'JA'),
('SMITH', 'JOHN', 'F', 'JA'),
('WHITE', 'MACK', 'C', 'NU'),
('HOWARD', 'DERRICK', 'G', 'NU'),
('DURRANT', 'KEVIN', 'F', 'NU'),
('CURRY', 'STEPHEN', 'G', 'GS');

Select Team.teamID, Team.teamName, Player.playerID, Player.playerLastName, Player.playerFirstName, Position.positionCode, Position.positionDesc
FROM Team, Player, Position
WHERE Team.teamID = Player.teamID AND
Player.positionCode = Position.positionCode
Order by Team.teamName, Player.playerLastName, Player.playerFirstName;
```

- Click on the Execute button to run the script

![runbutton](https://cloud.githubusercontent.com/assets/8953261/17081014/2f76434e-5103-11e6-9880-862f64e4fa33.png)


**NOTE: If you expand the Tables folder you should see the 3 newly created tables Player, Position, and Team**

- Close the new query and do NOT save the changes
- Click on the Basketball database and then select and copy the connection string in the properties window

![properties](https://cloud.githubusercontent.com/assets/8953261/17081019/40d2f18c-5103-11e6-986a-8dcc8b143345.png)

- Create a new MVC project and call it PlayBall


**NOTE: Make sure you choose MVC and leave the Authentication as Individual user Accounts**

- Go to the Solution Explorer and open the Web.config file
- Modify the connectionStrings section to reference the Basketball database by pasting in the connectionString attribute

```xml
  <configSections>
    <section name="entityFramework" type="System.Data.Entity.Internal.ConfigFile.EntityFrameworkSection, EntityFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" requirePermission="false" />
  </configSections>

  <connectionStrings>
    <add name="BasketballContext" connectionString="Data Source=(localDB)\v11.0;Initial Catalog=Basketball;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False"
      providerName="System.Data.SqlClient" />
  </connectionStrings>
```

- Create the model for the Player.cs

```csharp
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PlayBall.Models
{
    [Table("Player")]
    public class Player
    {
        [Key]
        public int playerID { get; set; }
        public String playerLastName { get; set; }
        public String playerFirstName { get; set; }
        public String positionCode { get; set; }
        public String teamID { get; set; }
    }
}
```

- Create the model for the Position.cs

```csharp
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PlayBall.Models
{
    [Table("Position")]
    public class Position
    {
        [Key]
        public String positionCode { get; set; }
        public String positionDesc { get; set; }
    }
}
```

- Create the model for the Team.cs

```csharp
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PlayBall.Models
{
    [Table("Team")]
    public class Team
    {
        [Key]
        public String teamID { get; set; }
        public String teamName { get; set; }
    }
}
```

- Save and Build the project
- Create a new model to represent the results of our SQL query and name it NewPlayer.cs

```csharp
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PlayBall.Models
{
    public class NewPlayer
    {
        [Key]
        public int playerID { get; set; }
        public String playerLastName { get; set; }
        public String playerFirstName { get; set; }
        public String positionCode { get; set; }
        public String positionDesc { get; set; }
        public String teamID { get; set; }
        public String teamName { get; set; }
    }
}
```

- Save and Build the project again
- Create a new folder call DAL
- Create a new class in the DAL folder called BasketballContext.cs
- Paste in the following code:

```csharp
using PlayBall.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PlayBall.DAL
{
    public class BasketballContext : DbContext
    {
        public BasketballContext()
            : base("BasketballContext")
        {

        }

        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<NewPlayer> NewPlayers { get; set; }
        public DbSet<Position> Positions { get; set; }
    }
}
```

- Modify the Global.asax file to refer to the BasketballContext variable and to the System.Data.Entity, and the DAL and Models folder:

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using PlayBall.Models;
using PlayBall.DAL;
using System.Data.Entity;

namespace PlayBall
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer<BasketballContext>(null);
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
```

- Save and Build the project
- Create and Open the HomeController.cs file
- Add the code for the controller as follows and using the clauses for the PlayBall.DAL and the PlayBall.Models
- Add the db context variable for BasketballContext to the HomeController

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PlayBall.DAL;
using PlayBall.Models;

namespace PlayBall.Controllers
{
    public class HomeController : Controller
    {
        private BasketballContext db = new BasketballContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
```

- Modify the Index Action method in the Home Controller to create the SQL query and return the results to the Index view

```csharp
// GET: Players
  public ActionResult Index()
  {
    IEnumerable<NewPlayer> player = 
        db.Database.SqlQuery<NewPlayer>(
    "Select Team.teamID, Team.teamName, Player.playerID, " + 
    "Player.playerLastName, Player.playerFirstName, " +
    "Position.positionCode,  Position.positionDesc " +
    "FROM Team, Player, Position " +
    "WHERE Team.teamID = Player.teamID AND " +
    "Player.positionCode = Position.positionCode " +
    "Order by Team.teamName, Player.playerLastName, " + 
    "Player.playerFirstName");

    return View(player);
}
```

- Create a scaffolded view for the Index action method in the HomeController. Name the View Index, The Template should be List, the Model class should be NewPlayer, and the Data  context  class should be BasketballContext. However, we want our view to look a little different because we want to see the teamName to also show up but we don't want to show the positionCode and the teamID. If you want, you can paste in this code in the Index.cshtml view in the Home Views controller which will add a jumbotron, remove the Create new Action link, Change the title of the view in html, 

```html
@model IEnumerable<PlayBall.Models.NewPlayer>

@{
    ViewBag.Title = "Home Page";
}

<div class="jumbotron">
    <h1>NBA Players</h1>
</div>

<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(model => model.teamName)
        </th>
        <th>
            @Html.DisplayNameFor(model => model.playerLastName)
        </th>
        <th>
            @Html.DisplayNameFor(model => model.playerFirstName)
        </th>
        <th>
            @Html.DisplayNameFor(model => model.positionDesc)
        </th>
        <th></th>
    </tr>

    @foreach (var item in Model)
    {
        <tr>
            <td>
                @Html.DisplayFor(modelItem => item.teamName)
            </td>
            <td>
                @Html.DisplayFor(modelItem => item.playerLastName)
            </td>
            <td>
                @Html.DisplayFor(modelItem => item.playerFirstName)
            </td>
            <td>
                @Html.DisplayFor(modelItem => item.positionDesc)
            </td>
            <td>
                @Html.ActionLink("Edit", "Edit", new { id = item.playerID })
            </td>
        </tr>
    }

</table>
```

- Save and Build the project
- Now you can go create a new controller in the HomeController.cs file for the Edit action which will receive the playerID as a parameter and you can use that value to look up the player in the Player table, store the record to the model, and return it to the Edit View to change the record.

```csharp
public ActionResult Edit(int? id)
{
    var newplayer = new Player();
    newplayer = db.Players.Find(id);

    if (newplayer != null)
    {
        db.Database.ExecuteSqlCommand(
            "Update Player " +
            "Set Player.teamID = 'JA'" +
            "Where Player.playerID = " + id);

        return RedirectToAction("Index", "Home");
    }

    return View();
}
```

- Save and build the project
- Select the Index.cshtml file and run the project

#### Where to go from here

- You can add the ActionURL for the delete and then write the controller and view to delete the record
- You can to modify the Edit to be a begin form helper that allows you to modify the player
- You can add login security (See the next tutorial coming out)


