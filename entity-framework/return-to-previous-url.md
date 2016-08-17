# Return to Previous URL

## Write the Get (route map handles the parameter)

```csharp
// GET: Home
public ActionResult Login(string ReturnUrl)
{
    ViewBag.ReturnUrl = ReturnUrl;
    return View();
}
```

## Write the Post
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
        return Redirect(form["ReturnURL"].ToString());

    }
    else
    {
        return View();
    }
}
```

##  Modify the View hiding the URL from the ViewBag

```html
@{
    ViewBag.Title = "Login";
}

<h2>Login</h2>

@using (Html.BeginForm("Login", "Home", FormMethod.Post))
{
    @Html.Hidden("ReturnURL", new { String = ViewBag.ReturnURL })
    
    <label for="inputEmail">Email address</label>
    @Html.TextBox("Email address")
    <label for="inputPassword">Password</label>
    @Html.Password("Password")
    <button type="submit">Login</button>
}
```

