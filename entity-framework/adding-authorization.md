# Adding Authorization

- Using the PlayBall project you created in a previous tutorial, we will now add authorization.
- We are going to hardcode a username of an email address greg@test.com and the password of greg (case-sensitive)
- However, as discussed in class, in a real world application you would instead want to use a database table that would hold user information. You could also use OAuth authentication and log in using credentials for another site like Google.
- Adding authorization to a project can be done via a controller, an action method, or by specifying a role
- This tutorial will show you the basics of attaching authorization to an action method


### Modify the web.config

REMOVE
```xml
    <authentication mode="None" />
   
AND ADD

```xml
<system.web>
  <compilation debug="true" targetFramework="4.5.1" />
  <httpRuntime targetFramework="4.5.1" />
  <authentication mode="Forms">
    <forms loginUrl="~/Home/Login" timeout="2880" />
  </authentication>
</system.web>
```

- This states that authentication will be set up to use the authentication element in the system.web section and that the mode will be forms based authentication (works with local user credentials). An alternative to forms based is Windows authentication where the operating system’s credentials are used or Organizational authentication using cloud services like Azure.
- The loginUrl tells ASP.net where to redirect users when they need to authenticate and in this case the system sends them to the Login action method in the Account controller
- The 2880 timeout is specified in minutes (48 hours)
- Now you need to set a filter for an action method or controller class which allows you to use additional logic to change the behavior of the framework.
- There are different types of filters but we are going to focus on the Authorize filter


#### Also modify the system.webServer section in the Web.config

```xml
<system.webServer>
  <modules>

  </modules>
</system.webServer>
```

### Comment out all of the code in the Startup.Auth.cs file after the:

```csharp
public void ConfigureAuth(IAppBuilder app)
{  /*

And to the:
            //app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()
            //{
            //    ClientId = "",
            //    ClientSecret = ""
            //});*/
        }
    }
}
```

### Create a new view called Login in the Home Views folder for your personalized Login

```html
@{
    ViewBag.Title = "Login";
}

<h2>Login</h2>

@using (Html.BeginForm("Login", "Home", FormMethod.Post))
{
    <label for="inputEmail">Email address</label>
    @Html.TextBox("Email address")
    <label for="inputPassword">Password</label>
    @Html.Password("Password")
    <button type="submit">Login</button>
}
```


### Save and build the project


### Open the HomeController


### Create the HttpGet Login Action method

```csharp
// GET: Home
public ActionResult Login()
{
    return View();
}
```

### Create the HttpPost Login Action method
```csharp
[HttpPost]
public ActionResult Login(FormCollection form, bool rememberMe = false)
{
    String email = form["Email address"].ToString();
    String password = form["Password"].ToString();

    if (string.Equals(email, "greg@test.com") && (string.Equals(password, "greg")))
    {
       FormsAuthentication.SetAuthCookie(email, rememberMe);

        return RedirectToAction("Index", "Home");

    }
    else
    {
        return View();
    }
}
```

### Add the using clause to access the System.Web.Security module

```csharp
using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using PlayBall.Models;
using System.Web.Security; // add this line
```

### Add the [Authorize] filter to the Index action method in the HomeController
```csharp
// GET: Players
[Authorize]
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

### Save and build the project


### Run the project by trying to access the Index action method for the Home Controller
