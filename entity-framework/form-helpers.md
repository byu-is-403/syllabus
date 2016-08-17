# Forms and Helpers


## Overview

- HTML Helpers "help" you work with HTML
- Forms are containers that allows a user to enter information and SUBMIT it to a server
- The action attribute tells where to send the information
- The method attribute tells where to HTTP POST or HTTP GET when sending the information
- The default method is HTTP GET
- Basically, when a user sees a view it is the HTTP GET and when a user submits, it is usually an HTTP POST
- The Get method requests a representation of a resource. IOW, they retrieve data
- The Post method requests that the server receive something that is being sent (i.e. data)


## Forms

```html
<form action="http://www.google.com/search" method="get">
	<input name="first" type="text" />
	<input type="submit" value="Search" />
</form>
```

- If you entered "greg" in the input box on the form and click on the submit button, it would result in the following url being created and sent to the browser
  
  
  `http://www.google.com/search?first=greg`
- So the HTTP Get request takes the information (values) inside of the form and builds a query string using names and values as a pair
- Use GET to read and POST to write

## Helpers

- An HTML Helper is a method that makes views easier to create
- The helper assists in correctly encoding attributes, building URLs, and simplifying model binding

```html
@using (Html.BeginForm("Search", "Home", FormMethod.Get))
{
	<input type="text" name="first" />
	<input type="submit" value="Search" />
}
```

- This BeginForm helper can be interpreted as being "How can I get to the Search Action for the Home controller?"
- This creates the necessary routes for you thus saving you a lot of time in handling all of that code that will generate the correct URL
- The Helper outputs HTML markup
- Most HTML Helpers include an html attribute parameter
- Some of the following HTML helpers that are built into the ASP.NET MVC framework are:
  - Html.BeginForm 
  - Html.TextBox
  - Html.TextArea
  - Html.Password
  - Html.Hidden
  - Html.CheckBox
  - Html.RadioButton
  - Html.DropDownList and Html.ListBox (all items are displayed without drop down)
  - Html.ValidationSummary and Html.ValidationMessage


### Html.BeginForm

- The BeginForm helper writes an opening form tag
- The form uses a POST method and the request is processed by the action method for the view

```html
@using (Html.BeginForm())
{
    @Html.TextBox("Name");
    @Html.Password("Password");
    <input type="submit" value="Sign In">
}
```

- This code produces the following form element:


  ```html
  <form action="/Original Controller/Original Action" action="post">
  ```
  
- There are a number of overloaded BeginForm methods which you can see here:


  https://msdn.microsoft.com/en-us/library/system.web.mvc.html.formextensions.beginform(v=vs.100).aspx 


### Html.TextBox

- Html.TextBox is a plain text box
```csharp
//Code in the View
@Html.TextBox("First")
```

```csharp
//Code in the Controller
 // GET: Default
public ActionResult Index()
{
    ViewBag.First = "greg";
    return View();
}
```

- By giving the helper the same name as a value in the viewbag, MVC will make a connection between the two. In this case, the token "First" in the viewbag is linked to the @Html.TextBox using the same name


### Html.TextArea

- Html.TextArea is a multi-line text box

```csharp
//Code in the View
@Html.TextArea("First")
```

```csharp
//Code in the Controller
// GET: Default
public ActionResult Index()
{
    ViewBag.First = "greg";
    return View();
}
```

### Html.Password

- Html.Password is a text box that allows for password entries and uses "*" for input

```csharp
//Code in the View
@Html.Password("First")
```

```csharp
//Code in the Controller
// GET: Default
public ActionResult Index()
{
    ViewBag.First = "greg";
    return View();
}
```

### Html.Hidden

- Html.Hidden is a field designed to make it easy to bind to view data or model data and also used for storing a value

```csharp
//Code in the View
@Html.Hidden("First")
```

```csharp
//Code in the Controller
 // GET: Default
public ActionResult Index()
{
    ViewBag.First = "greg";
    return View();
}
```

### Html.CheckBox

- Html.CheckBox returns a check box that allows the user to either select it (true) or un-select it (false) 
- In this example, it grabs the value out of the viewbag for the ReceiveEmail and casts it as a boolean for the checkbox. The words "Click Me" are displayed next to the Checkbox

```csharp
//Code in the View
@Html.CheckBox("ReceiveEmail", (bool)ViewBag.ReceiveEmail) Click Me
```

```csharp
//Code in the Controller
// GET: Default
public ActionResult Index()
{
    ViewBag. ReceiveEmail = true;
    return View();
}
```


### Html.RadioButton

- Html.RadioButton can be used to present the user with a list of mutually exclusive options (you can only check one)
- In this example, the radio buttons are part of a group called Gender. "Male" and "Female" are the different names of the buttons. The label "Male" is selected. Then text as used to be displayed by the buttons.

```csharp
//Code in the View
	@Html.RadioButton("Gender", "Male", true) Male<br />
	@Html.RadioButton("Gender", "Female", false) Female<br />
```


You could also do this to provide a default value dynamically:

```csharp
//In the controller:
	ViewBag.Male = false;
	ViewBag.Female = true;
	
//In the view:
 	@Html.RadioButton("Gender", "Male", (bool)ViewBag.Male) Male<br />
	@Html.RadioButton("Gender", "Female", (bool)ViewBag.Female) Female<br />
```

### Html.DropDownList

- Html.DropDownList can be used to present the user with a drop down list of values (accessed as strings)

```csharp
//Controller
public ActionResult Index()
{
    List<SelectListItem> states = new List<SelectListItem>();
    states.Add(new SelectListItem { Text = "Colorado", Value = "0" });
    states.Add(new SelectListItem { Text = "Texas", Value = "1" });
    states.Add(new SelectListItem { Text = "Utah", Value = "2", Selected = true });
    ViewBag.StateNames = states;
    return View();
}
```

- This creates a variable called states of type list and adds 3 items to the list using the text and the value when selected. The state of Utah is selected initially

```html
//View
@using (Html.BeginForm("CategoryChosen", “Home", FormMethod.Get))
{
  <fieldset>
      US States
      @Html.DropDownList("StateNames")
      <p>
          <input type="submit" value="Submit" />
      </p>
  </fieldset>
} 
```

```csharp
// CategoryChosen Controller
 public ViewResult CategoryChosen(string StateNames)
{
  if (StateNames.Equals("0"))
    ViewBag.messageString = "Colorado";
  else if (StateNames.Equals("1"))
    ViewBag.messageString = "Texas";
  else if (StateNames.Equals("2"))
    ViewBag.messageString = "Utah";

  return View("CategoryChosen");
}
```

```html
@{
    ViewBag.Title = "CategoryChosen";
 }

<h2>CategoryChosen</h2>
```
- You selected @ViewBag.messageString

- Another Example: 

```csharp
// GET: Default
public ActionResult Index()
{
  List<string> states = new List<string>();
  states.Add("CO");
  states.Add("TX");
  states.Add("UT");
  ViewBag.StateNames = new SelectList(states);
  return View();
}

public ViewResult CategoryChosen(string StateNames)
{
  ViewBag.state = StateNames;
  return View("CategoryChosen");
}
```

```html
//Index View
@{
    ViewBag.Title = "Category Select";
}

@using (Html.BeginForm("CategoryChosen", "Default", FormMethod.Get))
{
  <fieldset>
   US States
    @Html.DropDownList("StateNames")
    <p>
        <input type="submit" value="Submit" />
    </p>
  </fieldset>
} 

//CategoryChosen View
@{
    ViewBag.Title = "CategoryChosen";
}

<h2>CategoryChosen</h2>
```

- You selected @ViewBag.state


### Html.ValidationSummary and Html.ValidationMessage

- Html.ValidationSummary returns an HTML div element that contains an unordered list of validation error messages from the model-state dictionary while the Html.ValidationMessage works with a specific field in the ModelState dictionary. You can tie a model error directly to a field

```csharp
//View
@Html.ValidationMessage("FirstName")
@Html.ValidationSummary(false)
```

- In this case, the ValidationMessage works with a specific field called FirstName.  The ValidationSummary(false) invalidates the model so any errors are displayed (NOTE: This is done simply to show you how the messages work. Usually you will check the modelstate in the post)

```csharp
//Controller
[HttpGet]
public ActionResult Index()
{
  if (!ModelState.IsValid)
  {
    ModelState.AddModelError("FirstName", "First Name is not valid");
  }
  
  return View();
}
```

## ViewBag vs. ViewData

- The ViewBag and ViewData help you maintain data when you move from a controller to a view and can be used to actually pass the data from the controller to the view
- ViewData is a dictionary of objects accessible via strings (which are keys)
- ViewBag is a dynamic property and allows you to dynamically add values to the ViewBag
- ViewData requires typecasting while ViewBag does not


  `ViewData["FirstName"]`


  is the same as


  `ViewBag.FirstName`

```csharp
//Controller
public ActionResult Index()
{
	ViewBag.Name = "Buck Wheat";
	return View();
}

public ActionResult Index()
{
	ViewData["Name"] = "Buck Wheat";
	return View();
}

//View
@ViewBag.Name
@ViewData["Name"]
```

```csharp
//Controller
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HelpersSampleReal.Models;

namespace HelpersSampleReal.Controllers
{
    public class DefaultController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Person = new Person { FirstName = "Greg" };
            return View();
        }

    }
} 


//View
@Html.TextBox("Person.FirstName")
```


**NOTE: The Model reference was included in the controller**


## Strongly Typed Helpers

- Strongly typed helpers allow you to work directly with a model to retrieve data
- You must first include the model in the controller


  `@model HelpersSampleReal.Models.Person`

- Once the model is in place, the VIEW can now work with the fields in the model. You can explicity type the model.field or use a lambda expression


  `@Html.TextBoxFor(m => m.FirstName)`


  OR


  `@Html.TextBox("FirstName", Model.FirstName);`
  
- Strongly typed helpers can also take advantage of meta data for the model


  `@Html.Label("FirstName")`

produces:


  `<label for="FirstName">First Name</label>`


where the model contains:

```csharp
[DisplayName("First Name")]
public string FirstName  { get; set; }
```


### Templated Helpers

- Using helpers such as Html.LabelFor and Html.TextBoxFor are great for displaying a value within a model. However, you don’t have much control over how the value is displayed
- Templated helpers allows you to customize how the data is presented to the user for displaying and editing
- The Templated helpers are: 
  - Html.DisplayFor
  - Html.EditorFor
  - Html.DisplayForModel
  - Html.EditorForModel
  

### Html.DisplayFor Helper

- Html.DisplayFor  - displays a model property using what is known as a Display 

- For example, if the model had a field called Birthdate that had a value of 08 Dec 1990 and you issued the following statement in the view:
	
  
  `@Html.DisplayFor(model => model.BirthDate)`

- The output would be: o8 Dec 1990


### Html.EditorFor Helper


- Html.EditorFor – displays a user interface for editing a model property

- Using the same example as above with 08 Dec 1948 in the BirthDate value, if you had the following statement in the view:


  `@Html.EditorFor(model => model.BirthDate)`

- The output would be: 

<img width="189" alt="calendar" src="https://cloud.githubusercontent.com/assets/8953261/16826851/3a56753a-493e-11e6-84bf-667fe849a211.png">


### Html.DisplayForModel Helper

- HtmlDisplayForModel - displays the whole model (not just a single property) using a display template
- This helper would display the Name of the property (or display name if set up in the model) and then the value associated with the property
- For example:
	
	`@Html.DisplayForModel()`
	
	![model-complete](https://cloud.githubusercontent.com/assets/8953261/16827004/9fb0abde-493f-11e6-88dd-a38edcdb0158.png)
	
	
- HtmlEditorForModel -displays the whole model for editing using a given editor template 
- This helper would display the Name of the property (or display name if set up in the model) and then the value associated with the property

- For example:

	`@Html.DisplayForModel`
	
	![model](https://cloud.githubusercontent.com/assets/8953261/16826969/307556d4-493f-11e6-9eb9-3d718c9bd2ad.png)
	

### Html.ActionLink Rendering Helper

- Html.ActionLink – renders or creates a hyperlink (anchor tag) to another controller action
- The ActionLink methods have specific knowledge about ASP.NET MVC Controllers and actions


  `@Html.ActionLink("List Students", "Student")`

- When this is rendered it returns:


  `<a href="/Home/Student">List Students</a>`
  
- You can also tell the ActionLink to go to a specific controller and a specific action
	
	
	`@Html.ActionLink("List Students", "ListAllStudents", "Student")`
	
- When this is rendered it tells the system that if the user clicks on "List Students", that go to the ListAllStudents action in the Student controller. 


**NOTICE: You do not specify the "Controller" word on the controller input. The actual controller name is StudentController. You leave off the word "Controller"**


### Html.RouteLink Rendering Helper

- Html.RouteLink – renders or creates a hyperlink (anchor tag) to another controller action
- The Html.ActionLink renders the hyperlink tag to the specified controller action which uses the Routing API internally to generate UR while the Html.RouteLink is similar to the ActionLink but accepts a parameter for route name and does not include the parameters for Controller name and action name 


  `Html.RouteLink("Click Here", new {controller= "Home", action= "Index"})`

- It is similar to as <a> tag in Html:


  `<a href="/Home/Index">Click Here</a>`
  
- The routing system looks up the route by name, and populates the URI with values from the RouteCollection you passed


### URL Helpers

- URL Helpers are similar to the Rendering Helpers except that the URL helpers return the URL as a string while the Rendering Helpers actually BUILD the URL
- There are three types of URL Helpers
  - Action
  - Content
  - RouteURL
- The Action URL helper is exactly like the Rendering Action helper except that it is NOT returned as an anchor tag


  `@Url.Action("Browse", "Store", new { genre = "Jazz" }, null)`

- is rendered as:


  `/Store/Browse?genre=Jazz`

- Html.Partial
- Html.RenderPartial
- Html.Action
- Html.RenderAction


#### Action URL Helper

- The Action URL helper is exactly like the Rendering Action helper except that it is NOT returned as an anchor tag


  `@Url.Action("Browse", "Store", new { genre = "Jazz" }, null)`
  
- is rendered as:


  `/Store/Browse?genre=Jazz`

- Html.Partial
- Html.RenderPartial
- Html.RenderAction


#### Route URL Helper

- The Route URL Helper is like the Action helper but UNLIKE the RouteLink rendering helper in that it only acceps a route name and does not allow for any arguments for a controller and action


`@Url.RouteUrl("Default", new { Action = "About" }, Request.Url.Scheme)`


### Content URL Helpers

- The Content URL Helper converts a relative application path to an absolute application path
- For example:


  `<script src="@Url.Content("~/Scripts/jquery~1.10.2.min.js")" type = "text/javascript"></script>`

- However, ASP.NET MVC 5 automatically resolves the ~ character when it appears the src attribute for Script, Style and Img elements











	
	
















