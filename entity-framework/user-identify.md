# User Identity

How to extract email and password in the Login Controller


```csharp
[HttpPost]
public ActionResult Login(FormCollection form, bool rememberMe = false)
{
    String email = form["Email address"].ToString();
    String password = form["Password"].ToString();

    var currentUser =
        db.Database.SqlQuery<Users>(
    "Select * " +
    "FROM Users " +
    "WHERE UserID = '" + email + "' AND " +
    "UserPassword = '" + password + "'");

    if (currentUser.Count() > 0)
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


Then in the Get for an Index method to display all of the records from a model/table I access the User.Identity.UserName field which is handled by Microsoft due to our authorization that we set up on that action:

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

    ViewBag.UserName = User.Identity.Name;

    return View(player);
}
```

- When the Index action method is executed, the first thing that happens is that Microsoft sends a request to see if the user has already been authenticated. If not, it will go to the Login action method (as done in CheckPoint #5). 
- The login view is displayed and the user types in the email address and the password and clicks on the Login button. Control is sent to the Post method for the view and SQL query is used to find the record. Without getting into a ton of details you will not need to finish Project 2 or the Final exam, Microsoft has set up an identity model in your program when you create an MVC project. If you look under the Models you will actually see an Identity model. The system uses this model to store information from the login view through the account controller that was also created for you.
- In the action method above, I access the Microsoft set up User field and grab the Identity.Name and store it to the Viewbag. This way I can have access to the user name on every view through the use of the User.Identify.Name
- In the view you could do the following:

```html
@model IEnumerable<PlayBall.Models.NewPlayer>
@{
    ViewBag.Title = "Home Page";
}

<div class="jumbotron">
    <h1>NBA Players</h1>
</div>
<p>
    Hello @ViewBag.UserName
</p>
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
