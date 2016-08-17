# Pass User Login to View

## Create a Post for the Login Action method

```csharp
[HttpPost]
public ActionResult Login(FormCollection form, bool rememberMe = false)
{
  String email = form["Email address"].ToString();
  String password = form["Password"].ToString();

  var currentUser =  db.Database.SqlQuery<Users>(
  "Select * " +
  "FROM Users " +
  "WHERE UserID = '" + email + "' AND " +
  "UserPassword = '" + password + "'");

  if (currentUser.Count() > 0)
  {
      FormsAuthentication.SetAuthCookie(email, rememberMe);
      return RedirectToAction("Index", "Home", new { userlogin = email });
  }
  else
  {
      return View();
  }
}
```

##  Modify the Home controller’s Index action method to receive a parameter

```csharp
// GET: Players
[Authorize]
public ActionResult Index(String whatever)
{
    IEnumerable<NewPlayer> player = db.Database.SqlQuery<NewPlayer>(
    "Select Team.teamID, Team.teamName, Player.playerID, " +
    "Player.playerLastName, Player.playerFirstName, " +
    "Position.positionCode,  Position.positionDesc " +
    "FROM Team, Player, Position " +
    "WHERE Team.teamID = Player.teamID AND " +
    "Player.positionCode = Position.positionCode " +
    "Order by Team.teamName, Player.playerLastName, " +
    "Player.playerFirstName");

    ViewBag.Parm = userLogin;

    return View(player);
}
```
