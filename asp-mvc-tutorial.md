<h1>ASP.NET MVC C# Tutorial</h1>

## Getting Started

- Open Visual Studio
- Click on File, New Project
- Select ASP.NET MVC4 Web Application located under Templates/Visual C#/Web
- Enter `FirstMVCSite` in the name edit area


  ![new-project](https://cloud.githubusercontent.com/assets/8953261/16710838/88fd9dbc-45fb-11e6-9cd4-d2e16efa623d.png)
  
- Click on the OK button
- Select Empty Template and leave everything else as is

  ![project-template](https://cloud.githubusercontent.com/assets/8953261/16710842/a168e88e-45fb-11e6-91c0-3e5606eeef35.png)
  
- Click on the OK button
  
  
  **NOTE:** ASP.NET will create the new framework for your web site. `RAZOR` is a view engine option that allows you to quickly integrate server code in your html through the use of blocks (uses @)
  
  ![solution-explorer](https://cloud.githubusercontent.com/assets/8953261/16710847/cc3d694a-45fb-11e6-93db-cdf16f4915ca.png)
  
  
  **NOTE:** Incoming requests are handled by controllers (usually inherited from System.Web.Mvc.Controller). Each public method in the controller is the action method and can be invoked from the web via a URL
  
- Right click the Controllers folder and choose Add, Controller
- Set the name to be `HomeController`
  
  
  **NOTE:** All controllers should have the word Controller in their name
  
  ![add-controller](https://cloud.githubusercontent.com/assets/8953261/16710852/f9e41e66-45fb-11e6-9c81-a7b2043d8d8c.png)
  
  
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
- Enter the name of `Index` and make sure to uncheck the Use a layout or master page

  ![add-view](https://cloud.githubusercontent.com/assets/8953261/16710878/4376ebe8-45fd-11e6-8d8d-2238e81419bb.png)
  
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
  
    ![add-view](https://cloud.githubusercontent.com/assets/8953261/16710926/9dd83a4a-45ff-11e6-9a53-46add5989238.png)


  

