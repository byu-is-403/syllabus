# Views


## Purpose

- Responsible for providing the UI
- Views are not directly accessible like other frameworks (i.e. web forms, PHP, etc.)
- You cannot point your browser to a view and render it
- A view is rendered by a controller
- The controller can pass a model to the view order to provide data. The view then transforms the model into a format ready to be presented to the user (HTML)
- Remember that the controller just sends the necessary data back to the view which then renders it to HTML. IOW, you could return `"Hello " + "<strong>Greg</strong>"` and it would Bold the word **Greg**


## ViewBag

- Great for passing little bits of data but DON'T rely upon it for everything!
- ViewBag is a property of ControllerBase which all controllers inherit from up the line
- It is a dynamic object
- When you call return View() from the controller it creates a new instance of ActionResult passing ViewData from the controller to it's constructor which allows it to be used and accessed in the view.
- Each view will end up with its own ViewBag since it is not static (that is on purpose so that you don't have two concurrent users accessing the same ViewBag
- Its lifetime is the same as the controller which is the lifetime of the HTTP request
- The best times to use it are:
  - Incorporating dropdown lists of lookup data into an entity
  - Components like a shopping cart
  - Small amounts of aggregate data
- The ViewBaginfo is passed from the controller to the view via a ViewDataDictionary (think of your data structures)


## How do views work?

- Each controller contains a view file for each action method
- The view file is named the same as the action method
- Assume that you had a controller called HomeController
- You would also want a View folder called Home
- ASP.NET MVC knows that if you have a controller called HomeController then it should be linked to a view in the Home folder
  `public ActionResult Index()` – means that there should be a view with that name if you do the return View()
0 IOW, the view selection logic looks for a view with the same name as the action with the ControllerName directory (without the controller suffix)
- When you type in a URL you are not specifying a view. Instead you are specifying a controller. 
  - www.flaxom.com/Test/Index would look for a controller called IndexController and then map to the View folder called Test looking for an Action called Index. In this action (method) you could return View() which means that it would then look for a view called Index.cshmtl in the Test View folder. However, you do NOT have to return View() but could instead return View("Myfile"); which would still look in the Test View folder. You could even specify a view that is NOT in the Test view folder: return View("~Views/NewTest/Index.cshtml");
- Views are attached to an action (method in the controller)


## Routes

- ASP.NET Routing system decides how URLs map to controllers and actions
- Default routes are added when a project is created to get you started
- Look in the RouteConfig.cs file for the routes


### Adding a Controller

- Create a new, Empty, MVC project (check box) and click OK
- Right click on Controllers, Add
- Empty Controller named Home
- Run and look at the errors
- It shows the search path, the View for Index was not found in the Home directory
- Right mouse click within the controller action method and choose Add View
- Uncheck Partial and Layout and click Add
- You can return a view or even redirect to another page (known as Action Result Objects)

```csharp
public ActionResult Index() {
  return new RedirectResult("http://www.ksl.com");
}
```

- Add the following

```csharp
// GET: /HOME/

public ActionResult Index() {
  int hour = DateTime.Now.Hour;
  
  ViewBag.Greeting = hour < 12 ? "Good Morning" : "Good Afternoon";
  
  return View();
}

```

### Modify View

- Modify the Index view and add the following code:

  ```html
  <body>
    <div>
      @ViewBag.Greeting World
      
      <p>Having a party!!!</p>
      
      @Html.ActionLink("RSVP Now", "RsvpForm")
    </div>
  </body>
  ```

- `Html.ActionLink` is a helper method
- They include methods for: 
  - links
  - text inputs
  - checkboxes
  - selections
  - and more
- ActionLink takes 2 parameters:
  1. Text to display in the link
  2. Action method to perform when the text is clicked
  
- Run and test the program


  NOTE: if you click the link it will try to call the RsvpForm action method which does not exist
  
### Write another Controller

- Go to the Controllers folder and modify the HomeController file
- Write the following action method:

  ```csharp
  public ViewResult RsvpForm() {
    return View();
  }
  ```
  
- You can use either the ViewResult or the ActionResult return type

### Strongly Typed View

- A strongly typed view renders a specific type
- Make sure you have compile your project first in case you added your model but have never compiled
- The system will need to know about the model for a strongly typed view since it is tied TO the view

### Creating a Model

- In order to make a view a Strongly Typed View we need to work with a model
- Right mouse click on the Models folder and choose Add|Class
- Name the class GuestResponse.cs and click on the Add button
- A model is simply a C# class that mimics the structure of the data you want to save


### GuestResponse Model

- Type in the following code in the newly created model:

```csharp
public class GuestResponse {
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public bool? WillAttend { get; set;}
}
```

- The ? On the bool allows the system to store a null, true, and a false
- TRICK: If you type prop and press tab twice it will generate a lot of the code for you
- Save the project and then BUILD (you have to build to let the system know about the model and be able to integrate it within the controllers and views)
- TRICK: In the C# Source code editors can you start to type a letter and a list will be displayed. Some of these items will autogenerate source code if you press tab twice (i.e. p tab tab, prop tab tab, mvcaction4 tab tab, etc.) – found in Tools | Code Snippets Manager


### RsvpForm View

- With the model now in place, go back to the Home controller and Right click in the RsvpForm action method and choose Add View
- Set template to Empty
- Choose the GuestResponse model and click on the Add button
- Notice the model included in the view (Change the NameOfProject to match your project name)
- @model NameOfProject.Models.GuestResponse
- NOTE: You can change to a strongly typed view by including the model in the view


### Adding Bootstrap and JQuery using NuGet Package Manager

- You can add bootstrap and jquery to an empty view/project by using NuGet
- Click on Tools | NuGet Package Manager | Manage NuGet Packages for Solution
- If it is not already installed in this project, click on Online and Search for Bootstrap (upper right corner)
- Click on Bootstrap CSS and click on Install
- You can also install Jquery by clicking on it and clicking Install
- The Content folder will automatically be created and the necessary CSS files will be placed in it along with the necessary script files in the Scripts folder


### HTML Head

- Make sure you add the necessary tags for Bootstrap and Jquery to work within your project
- Just because added the necessary references and files to the project it does not automatically incorporate it within your view
- Add the following code to the RsvpForm View:

```html
<head>
    <meta name="viewport" content="width=device-width" />
    <title>RsvpForm</title>
    <link href="~/Content/bootstrap.min.css" rel="stylesheet" />
    <script src="~/Scripts/jquery-2.1.4.min.js"></script>
    <script src="~/Scripts/bootstrap.min.js"></script>
</head>
<body>
  <div class="jumbotron">
    <div class="container">
      @using (Html.BeginForm())
      {
        <p>Name: @Html.TextBoxFor(x => x.Name)</p>
        <p>Email: @Html.TextBoxFor(x => x.Email)</p>
        <p>Phone: @Html.TextBoxFor(x => x.Phone)</p>
        <p>
          Will you attend? @Html.DropDownListFor(x => x.WillAttend, new[] {
                                      new SelectListItem()
                                      {Text = "Yes, I will be there", Value = bool.TrueString},
                                      new SelectListItem()
                                      {Text = "Nope", Value = bool.FalseString} }, "Choose an option")
        </p>
        <input type="submit" value="Submit RSVP" />
      }
    </div>
  </div>
</body>
```

### HTML Helpers Explained

`@using (Html.BeginForm())`

- The Razor using statement allows you to specify an HTML helper. In this case you are having Razor generate the necessary HTML code for a form to get input
- The @Html.TextBoxFor helper is used when you want to associate a property of a model to the textbox.  The text box then takes on the name of the property, which makes it convenient to gather all form elements as properties of a model in your post-action. 
  
  
  `<p>Name: @Html.TextBoxFor(x => x.Name)</p>`
- The @Html.DropDownList helper is used to create a drop down list. However, you are responsible for creating the items in the list by calling the new SelectListItem() and passing it the text and value
  
  
  ```csharp
  @Html.DropDownListFor(x => x.WillAttend, new[] {
                                                  new SelectListItem()
                                                  {Text = "Yes, I will be there", Value = bool.TrueString},
                                                  new SelectListItem()
                                                  {Text = "Nope", Value = bool.FalseString} }, "Choose an option")
  ```


### Lambda Expression

- A lambda expression is away to write an anonymous function, i.e. a function without a name. What you have on the left side of the "arrow" are the function parameters, and what you have on the right side are the function body. Thus, (x => x.Name) logically translates to something like string Function(Data x) { return x.Name } the types string and Data will obviously vary and be derived from the context.
- The model => item.FirstName means logically it would translate to string

  ```csharp
  Function(Model model) {
    return item.FirstName;
  }
  ```
- Basically this is a function with a parameter, but this parameter is not used.


### HTML Forms

- The Html Helper BeginForm indicates the beginning of an html form that will be used to gather input
- An EndForm is not needed since the BeginForm helper automatically closes out the form element
- The `<input>` element is the most important form element
- `<input type="submit">` defines a button for submitting a form to a form-handler

  
  `<input type="submit" value="Submit RSVP" />`
- This states that there will be a button with the text Submit RSVP and will be used to submit the form to the server once clicked


### Controllers for HttpGet and HttpPost

- The HttpGet request attribute is what the browser issues each time someone clicks on a link and will be responsible for display the initial blank form
- The HttpPost request attribute is responsible for receiving submitted data and deciding what to do with it
- Both of the action methods will have the same name but MVC will make sure the correct action method is selected based upon whether the system is getting the data or the user clicked on the submit button
- In order to use the model in the controller you need to make sure it is imported


  `using EmptyView.Models;` (where EmptyView is the name of the project)
  
### HttpGet

```csharp
[HttpGet]
public ViewResult RsvpForm() {
  return View();
}
```

- This action method is used to render the view RsvpForm.cshtml and generate the form
- The square brackets indicate it is an attribute and the HttpGet is a reserved word to MVC
- NOTE: Make sure you have added the proper using statement to make sure you have access to the model in your controller

  ```csharp
  using WebApplication4.Models; //where WebApplication4 is the name of your project
  ```
  
### HttpPost

```csharp
[HttpPost]
public ViewResult RsvpForm(GuestResponse guestResponse) {
  return View("Thanks", guestResponse);
}
```

- The post action method is using Model Binding where the incoming data (guestResponse of type GuestResponse) is parsed and the key/value pairs in the Http request are used to populate the properties of the domain model type
- The names of the input elements are used to set the values of the properties in the instance of the model class which is then passed to the Post-enabled action method (the form fields values are automatically passed to the guestResponse object model properties)


### Modify the HomeController

```csharp
// GET: /Home/

public ActionResult Index()
{
  int hour = DateTime.Now.Hour;
  ViewBag.Greeting = hour < 12 ? "Good Morning" : "Good Afternoon";
  return View();
}

[HttpGet]
public ViewResult RsvpForm()
{
  return View();
}

[HttpPost]
public ViewResult RsvpForm(GuestResponse guestResponse)
{
  return View("Thanks", guestResponse);
}
```

  
**NOTE: Don't forget to add the using for the models" using EmptyView.Models;“ where EmptyView is the name of the project**


### Thank You View using the Model

- Let's create another view that uses the model that was populated by the RsvpForm view
- Right mouse click in any of the HomeController methods and choose Add View
- Call the view Thanks and choose the Empty Template
- Then choose the GuestResponse model


**NOTE: Visual Studio will create the Thanks.cshtml view. Notice the @model statement?**


- Write the following html for the Thanks View

  ```html
  <body>
    <div> 
      <h1>Thank you @Model.Name</h1>
      @if (Model.WillAttend == true)
      {
          <p>We look forward to seeing you</p>
      }
      else
      {
          <p>Hopefully next time you can make it</p>
      }
    </div>
  </body>
  ```
  
### Validation in the model

- ASP.Net MVC supports declarative validation rules define with attirbutes
- Let's modify the model to require input using the [Required] validation attribute

  ```csharp
  public class GuestResponse {
    [Required(ErrorMessage = "Please enter your name")]
    public string Name { get; set; }
  
    [Required(ErrorMessage = "Please enter your email")]
    public string Email { get; set; }
  
    [Required(ErrorMessage = "Please enter your phone number")]
    public string Phone { get; set; }
  
    [Required(ErrorMessage = "Please specify if you will attend")]
    public bool? WillAttend { get; set; }
  }
  ```


  NOTE: Notice that the Required usage generates an error? That is because you need to use the data annotations class. Right mouse click on one of the errors and choose Resolve | using System.ComponentModel.DataAnnotations;
  
  
  If the WillAttend is null then it will generate an error message
  
  
### Validation in the Controller
  
- Now that the model is set up, let's add the code to the controller
- The ModelState.IsValid property checks to see if all items pass validation
- You will add this C# statement in your controller and if the model does not validate then you will return the view for the user to fix the problems

  ```csharp
   [HttpPost]
    public ViewResult RsvpForm(GuestResponse guestResponse) {
      if (ModelState.IsValid) {
        return View("Thanks", guestResponse);
      } else {
        //Validation Error
        return View();
      }
    }
  ```




