<h1>ASP.NET MVC C# Tutorial</h1>

## Getting Started

- Open Visual Studio
- Click on File, New Project
- Select ASP.NET MVC4 Web Application located under Templates/Visual C#/Web
- Enter `FirstMVCSite` in the name edit area

  ![mvctutorial](https://cloud.githubusercontent.com/assets/6514931/19099172/122ff62a-8a71-11e6-897a-afcd29baa9c1.png)
  
- Click on the OK button
- Select Empty Template and leave everything else as is

  ![2ndimage](https://cloud.githubusercontent.com/assets/6514931/19099226/9d0ccd54-8a71-11e6-9a38-4449dde0b9f5.png)
  
- Click on the OK button
  
  
  **NOTE:** ASP.NET will create the new framework for your web site. `RAZOR` is a view engine option that allows you to quickly integrate server code in your html through the use of blocks (uses @)
  
  ![solution-explorer](https://cloud.githubusercontent.com/assets/8953261/16710847/cc3d694a-45fb-11e6-93db-cdf16f4915ca.png)
  
  
  **NOTE:** Incoming requests are handled by controllers (usually inherited from System.Web.Mvc.Controller). Each public method in the controller is the action method and can be invoked from the web via a URL
  
- Right click the Controllers folder and choose Add, Controller
- Select MVC 5 Controller Empty and click Add

  ![mvccontroller](https://cloud.githubusercontent.com/assets/6514931/19099857/62ed9a1c-8a77-11e6-8b82-dd926ff489e5.png)
  
- Set the name to be `HomeController` and click Add
  
  
  **NOTE:** All controllers should have the word Controller in their name
  
  ![homecontroller](https://cloud.githubusercontent.com/assets/6514931/19099897/c3ebca64-8a77-11e6-8014-42a4813a5725.png)
  
  
  **NOTE:** The scaffolding options allows you to select templates with built-in common functionality. The default contents of the controller will be displayed
  
  ```csharp
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Web;
  using System.Web.Mvc;
  
  
  namespace FirstMVCSite.Controllers {
    public class HomeController : Controller {
      // GET: /Home/
      
      public ActionResult Index() {
        return View();
      }
    }
  }
  ```
  
  
  **NOTE:** The MVC Framework maps URLs to method which are in Controller classes
  
- Modify the `Index` method to look like the following:
  
  ```csharp
  public String Index() {
    return "Cougars beat Gonzaga for tournament title";
  }
  ```

- Run the program by clicking on the Green triangle

  ![run-btn](https://cloud.githubusercontent.com/assets/8953261/16710864/cc70ce7e-45fc-11e6-8118-d5c5b3517ec9.png)
  
  
  **NOTE:**  You can click on the down arrow to select your preferred browser
  
- Click on the red square to stop running the application

  ![stop-btn](https://cloud.githubusercontent.com/assets/8953261/16710869/e1e80e7a-45fc-11e6-9ea7-9d60d0266187.png)
  
  
  **NOTE:** The index action is the default method that gets executed for /, /Home, and /Home/Index meaning that if a browser requests http://yoursite/ or http://yoursite/Home the Index method will be executed
  
  
  **NOTE:** In order to generate an HTML response to a browser request, you must create a view. The Index method needs to be modified to return a ViewResult object which contains the HTML response.
 
  
- Modify the Index method to look like the following:

  ```csharp
  public class HomeController : Controller {
    
    // GET: /Home/
    
    public ViewResult Index() {
      return View();
    }
  }
  ```
  
- Right-click on the View Folder and choose Add, New Folder
- Name it `Home`


  ![view-folder](https://cloud.githubusercontent.com/assets/8953261/16710875/2e259302-45fd-11e6-9ad7-f5eae93a727a.png)

- Right-click on the Home Folder and choose Add, View
- Enter the name of `Index` and make sure to uncheck the Use a layout page

  ![addview](https://cloud.githubusercontent.com/assets/6514931/19100014/8e8108e8-8a78-11e6-95de-e67cd770483c.png)
  
- Click on the Add button


  **NOTE:** A new file will be generated called Index.cshtml (C# HTML) in the Home, View Folder
  
- Double-Click on the Index.cshtml file


  **NOTE:** the `@{ layout` code tells the Razor view engine that there is NOT a master page which is a common template that can be used through the entire web project
  

- Add the text within the `<Div>` tags

  ```html
  @{
    Layout = null;
  }
  
  <!DOCTYPE html>
  <html>
  <head>
    <meta name="viewport" content="width=device-width" />
    <title>Index</title>
  </head>
  <body>
    <div>
      Cougars beat Gonzaga in the tournament
    </div>
  </body>
  </html>
  ```

- Run the application


  **NOTE:** the ViewResult tells MVC to render a view and return HTML. There are different action methods we can use besides the ViewResult. For example, we could use the RedirectResult to have the browser redirect to another URL. The controller’s job is to provide input for the view who in turn renders it to HTML.
  
  
  The controller uses a ViewBag object to pass data to a view. It allows you to dynamically create “properties” for the object
  
- Modify the HomeController to look like the following:

  ```csharp
  public ViewResult Index() {
    String sTeamName = "Gonzaga";
    
    ViewBag.Opponent = sTeamName.Equals("Gonzaga") ? "Beat Gonzaga" : "Beat anyone else";
    
    return View();
  }
  ```
  
- Now modify the Index.cshtml file to look like:

  ```html
    <body>
      <div>
        @ViewBag.Opponent in the tournament
      </div>
    </body>
  ```
  
- Run the applcation
- Modify the HomeController file’s Index method to look like:

  ```csharp
    public ViewResult Index() {
      int hour = DateTime.Now.Hour;
      
      ViewBag.Greeting = hour < 12 ? "Good morning" : "Good afternoon";
      
      return View();
    }
  ```
  
- Now modify the div in the Index.cshtml file to be:

  ```html
  <div>
    @ViewBag.Greeting World
    <p>We are having a cool pool party</p>
  </div>
  ```
  
  
  **NOTE:** A model contains the processes and rules representing the real-world objects (called the domain class)
  
- Right-click the Models folder
- Select Add, Class

  ![add-new-item](https://cloud.githubusercontent.com/assets/8953261/16710907/d410ca38-45fe-11e6-9962-cdc7d3286b84.png)
  
- Enter the file name of `GuestResponse.cs` and click the Add button
- Modify the file to look like the following:

  ```csharp
  public class GuestResponse {
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public bool? WillAttend { get; set; }
  }
  ```
  
  
  NOTE: the bool? Data type represents true, false, and null

- Modify the Index.cshtml view to be:

  ```html
  <div>
    @ViewBag.Greeting World
    <p>We are having a cool pool party!</p>
    @Html.ActionLink("RSVP Now", "RsvpForm")
  </div>
  ```

  
  NOTE: The Html.ActionLink request is called a helper method and is a convenient way to render HTML links, text inputs, checkboxes, and selections. It takes two parameters (text to display in the link, action to perform when the user clicks the link)

- Now we need to create the action that corresponds to RsvpForm. Add a method to the HomeController class called RsvpForm so that when it is called, it returns a ViewResult object representing the RsvpForm.

  ```csharp
  public class HomeController : Controller {
    
    // GET: /Home/
    
    public ViewResult Index() {
      int hour = DateTime.Now.Hour;
      
      ViewBag.Greeting = hour < 12 ? "Good morning" : "Good afternoon";
      
      return View();
    }
    
    
    public ViewResult RsvpForm() {
      return View();
    }
  }
  ```
  
- Build the project by selecting Build, Build FirstMVCSite
- Create a strongly typed view for the RsvpForm by Right-Clicking inside the RsvpForm action method and choosing Add View


  **NOTE: A strongly typed view represents a view that renders a specific type rather than a generic type. This allows you to build the HTML form for editing objects specifically tied to a model so that we can pass information from a controller to a view.**
  
  
  There are 3 ways to pass information from a controller to a view:
  1. Strongly typed model
  2. Dynamic (we haven’t talked about yet)
  3. Using a ViewBag
  
  ![rsvpform](https://cloud.githubusercontent.com/assets/6514931/19100322/143de63e-8a7b-11e6-82c8-ce8f1216d7fd.png)

    
    **NOTE: A new View will be created called RsvpForm and placed in the Views, Home folder**
    
    ![rsvp-form](https://cloud.githubusercontent.com/assets/8953261/16710944/697113a2-4600-11e6-9299-9f238bbb5208.png)


    **NOTE: The cshtml file contains the following Razor model line that strongly typed this view making it possible to edit the FirstMVCSite objects.**
    
    ```csharp
    @model FirstMVCSite.Models.GuestResponse
    
    @{
      Layout = null;
    }
    ```
  
- Modify the RsvpForm.cshtml to look like the following:

  ```html
  <body>
    @using (Html.BeginForm()) {
      <p>Name:    @Html.TextBoxFor( x => x.Name)</p>
      <p>Email:   @Html.TextBoxFor( x => x.Email)</p>
      <p>Phone:   @Html.TextBoxFor( x => x.Phone)</p>
      <p>Will you attend:    
                  @Html.DropDownListFor( x => x.WillAttend, new[] 
                    {
                      new SelectListItem()
                      {
                        Text = "Yes", Value = bool.TrueString
                      },
                      new SelectListItem()
                      {
                        Text = "No", Value = bool.FalseString
                      }
                    },
                    "Please choose one")</p>
      <input type="submit" value="Submit RSVP">
    }
  </body>
  ```
  
  
  **NOTE: The TextBoxFor allows you to generate an HTML input element and works because we created a strongly typed view so that the helper methods can infer which data type we are reading from the @model expression and is similar to:**
  
  
  `<input id=”Name” name=”Name” type=”text” value=”” />`
  
  
  **The Html.BeginForm generates a form element configured to postback to the action method. Since no parameters are passed it assumes to postback to the same URL. By wrapping this statement in a C# “using” statement the helper closes the HTML form element when it goes out of scope an internally creates:**
  
  
  ```html
  <form action=”/Home/RsvpForm” method=”post”>
    …all of the content we included
  </form>
  ```

- Save the project
- Run the project

  
  **NOTE: We have not told MVC what to do when the form is posted so instead, it just clears the data entered into the form. The form posts back to the RsvpForm action method in the Home controller which says to render the view through the statement “return View()”**
  
- In the HomeController, add the following to tell MVC which action method in the RsvpForm represents the HTTP GET requests

  ```csharp
  public class HomeController : Controller {

    // GET: /Home/
  
    public ViewResult Index() {
      int hour = DateTime.Now.Hour;
  
      ViewBag.Greeting = hour < 12 ? "Good morning" : "Good afternoon";
  
      return View();
    }
  
    [HttpGet]
    public ViewResult RsvpForm() {
      return View();
    }
  }
  ```
  
  
  **NOTE: Adding the [HttpGet] tells MVC that the method will be responsible for displaying the initial blank form when someone first visits the RsvpForm and the method is only used for GET requests**
  
- Now add an import to the FirstMVCSite Models so that you can reference the model without having to qualify the class name

    ```csharp
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using FirstMVCSite.Models;


    public class HomeController : Controller {
  
      // GET: /Home/
    
      public ViewResult Index() {
        int hour = DateTime.Now.Hour;
    
        ViewBag.Greeting = hour < 12 ? "Good morning" : "Good afternoon";
    
        return View();
      }
    
      [HttpGet]
      public ViewResult RsvpForm() {
        return View();
      }
          
      [HttpPost]
      public ViewResult RsvpForm(GuestResponse response) {
        return View("ThankYou", response);
      }
    }
  ```
  
  
  **NOTE: This tells MVC that the overloaded RsvpForm method receives a single parameter of type GuestResponse which is in our FirstMVCSite model. It then returns a View object (ThankYou) and GuestResponse object (response) which is passed to the View and is used for Post requests.**
  
- Create the new view ThankYou by Right-Clicking inside the overloaded HomeController ViewResult method and choosing Add View

  

  
  ![thank-you-view](https://cloud.githubusercontent.com/assets/8953261/16711026/41813d0a-4604-11e6-9a9f-db5eabd899d1.png)

  
  **NOTE: The ThankYou.cshtml file for the view will be created in the Home Controllers folder**
  
  ![thank-you-file](https://cloud.githubusercontent.com/assets/8953261/16711030/7b68752e-4604-11e6-8064-a0ea0ef84198.png)
  
- Modify the ThankYou.cshtml file to be as follows:

  ```html
  <body>
    <div>
      <h1>Thank you @Model.Name</h1>
      @if (Model.WillAttend == true)
      {
        @:We look forward to seeing you
      }
      else
      {
        @:Hopefully you can come next time
      }
    </div>
  </body>
  ```
  
  
  **NOTE: Using the Model we can bind data to keys and values we can now interface with the C# objects rather than trying to deal with the Request.Form[] and Request.QueryString[] elements. The GuestResponse object is automatically populated with the data from the form fields.**
  
- Save and run the project


  **NOTE: ASP.NET MVC supports validation rules through the use of the System.ComponentModel.DataAnnotations namespace**  
  
- Open the GuestResponse.cs Model
- Enter the following information for each of the get/sets:


  **NOTE: MVC automatically detects the attributes within the [ ] and uses them to validate the data in the model-binding process.**
  
  
  Also, take note of the bool? Value. It represents a 3 state Boolean of null, true, and false. 

  
  Remember, the Model defines the rules but the Controller enforces them.
  
  ```csharp
  public class GuestResponse {
    [Required(ErrorMessage = "Please enter a name")]
    public string Name { get; set; }
    
    [Required(ErrorMessage = "Please enter an email")]
    public string Email { get; set; }
    
    [Required(ErrorMessage = "Please enter a phone")]
    public string Phone { get; set; }
    
    [Required(ErrorMessage = "Please indicate if you will attend")]
    public bool? WillAttend { get; set; }
  }
  ```
  
- Open the HomeController.cs Controller
- Add the following code to the HttpPost attribute

  ```csharp
  [HttpPost]
  public ViewResult RsvpForm(GuestResponse response) {
    if(ModelState.IsValid) {
      return View("ThankYou", response);
    } else {
      return View();
    }
  }
  ```
  
  
  **NOTE: This code tells MVC that if the validations passed then display the View using the ThankYou.cshtml view object and GuestResponse object response. Otherwise, just render the RsvpForm view without any parameters**
  
- Now we need to provide some way of telling the user there was a problem if a validation rule was broken. Open the RsvpForm.cshtml View
- Add the following code:

  ```html
  @using (Html.BeginForm()) {
  
    @Html.ValidationSummary();
  
    <p>Name:    @Html.TextBoxFor( x => x.Name)</p>
    <p>Email:   @Html.TextBoxFor( x => x.Email)</p>
    <p>Phone:   @Html.TextBoxFor( x => x.Phone)</p>
    <p>Will you attend:    
                @Html.DropDownListFor( x => x.WillAttend, new[] 
                  {
                    new SelectListItem()
                    {
                      Text = "Yes", Value = bool.TrueString
                    },
                    new SelectListItem()
                    {
                      Text = "No", Value = bool.FalseString
                    }
                  },
                  "Please choose one")</p>
    <input type="submit" value="Submit RSVP">
  }
  ```

  
  **NOTE: The Html.ValidationSummary method creates a holding list of items that failed validation. This list is hidden on the form so the end user does not see it. MVC add the error messages to this list for every broken validation rule. **
  
  
  **Notice that the data entered into the form is not cleared. This is a benefit of model binding.**
  
- Save and run the program

  
  **NOTE: HTML Helper methods simply return a string and are used insert HTML tag within your code. For example, the Html.BeginForm() Helper method is used to create the opening and closing HTML <form> tags.  The Html.TextBox() Helper method is used to create input tags.**
  
  
  Previously in the RsvpForm.cshtml View, we placed the code:
  `@Html.TextBoxFor( x => x.Name)`
  
  
  This Html helper method generates code that looks like:
  `<input data-val=”true” data-val-required=”Please enter your name” id=”Name” name=”Name” type=”text” value=”” />`
  
  
  When a validation rule is broken for this tag, the following code automatically is generated:
  `<input class=”input-validation-error” data-val=”true” data-val-required=”Please enter your name” id=”Name” name=”Name” type=”text” value=”” />`
  
  
  The HTML Helper method added a class to the tag called input-validation-error.
  
  
  We can add a CSS style for this class and others that HTML Helper methods invoke
  
- Right-click on the FirstMVCSite and select Add, New Folder
- Type in the name `Content`

  ![content](https://cloud.githubusercontent.com/assets/8953261/16711102/b6464e3e-4607-11e6-92c0-cf0942d02ee4.png)
  
- Right-click on the Content folder and choose Add, New Item
- Scroll down and select Style Sheet and click on the Add button

  ![style-sheet](https://cloud.githubusercontent.com/assets/8953261/16711109/e78c0e84-4607-11e6-8c1b-bfe59c32ab11.png)

- Right-click on the newly added Style Sheet and choose Rename
- Change the name to Site.css
  
  ![site-css](https://cloud.githubusercontent.com/assets/8953261/16711118/18dccafa-4608-11e6-9243-12f1f950ec5c.png)

- Modify the Site.css to be the following (NOTE: Remove the .body tag)

  ```css
  .field-validation-error {
    color: #f00;
  }
  .field-validation-valid {
    display: none;
  }
  .input-validation-error {
    border: 1px solid #f00;
    background-color: #fee;
  }
  .validation-summary-errors {
    font-weight: bold;
    color: #f00;
  }
  .validation-summary-valid {
    display: none;
  }
  ```
  
- Open the RsvpForm.cshtml View
- Add the following code:

  ```html
   <head>
    <meta name="viewport" content="width=device-width" />
    <link rel="stylesheet" type="text/css" href="~/Content/Site.css" />
    <title>RsvpForm</title>
  </head>
  ```
  
- Save and run the project




  



