# Model Within Model 


## Getting Started

- Create an MVC Project 
- Create a database called CarOwners
- Within that database I created 2 tables: Cars and Owners


The Cars table looked like:

```sql
CREATE TABLE [dbo].[Cars] (
    [carID]   INT          IDENTITY (1, 1) NOT NULL,
    [carName] VARCHAR (30) NOT NULL,
    [ownerID] INT          NULL,
    PRIMARY KEY CLUSTERED ([carID] ASC)
);
```


The Owners table looked like:
```sql
CREATE TABLE [dbo].[Owner] (
    [ownerID]        INT          IDENTITY (1, 1) NOT NULL,
    [ownerLastName]  VARCHAR (30) NOT NULL,
    [ownerFirstName] VARCHAR (30) NOT NULL,
    PRIMARY KEY CLUSTERED ([ownerID] ASC)
);
```


Meaning that each car could only have 1 owner but 1 owner could be attached to multiple cars. Be aware that one could also create a joining table made up of the primary keys from the Cars and Owner table.


Note that I set the carID and the ownerID as identity fields


- Add some data to the Cars table (maybe 3 records or so for now)
- Copy the connection string and add it to the Web.config in the connectionStrings section (If this section is not present you can just create it – see other examples posted)

```xml
<add name="CarOwnersContext" connectionString="Data Source=(localDB)\v11.0;Initial Catalog=CarOwners;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False"
      providerName="System.Data.SqlClient" />
```


- Create the models for the Cars

```csharp
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CarsRUs.Models
{
    [Table("Cars")]
    public class Cars
    {
        [Key]
        public int carID { get; set; }

        [Required(ErrorMessage = "The Car name is required")]
        [DisplayName("Car Name")]
        [StringLength(30)]
        public String carName { get; set; }

        public int? ownerID { get; set; }
    }
}
```


NOTE: I used the ? on the ownerID to allow it to be null. This is the foreign key in the Cars table that can link you to an owner if the car record has one.


- Create the model for the Owner

```csharp
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarsRUs.Models
{
    [Table("Owner")]
    public class Owner
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int? ownerID { get; set; }

        [Required(ErrorMessage = "The Owner Last name is required")]
        [DisplayName("Owner Last Name")]
        [StringLength(30)]
        public String ownerLastName { get; set; }

        [Required(ErrorMessage = "The Owner First name is required")]
        [DisplayName("Owner First name")]
        [StringLength(30)]
        public String ownerFirstName { get; set; }
    }
}
```


NOTE: the HiddenInput(DisplayValue = false) attribute allows me to now worry about having a value for the primary key ownerID since it will be auto generated as an identify field. I also use the ? to allow it to be nullable. I have to do this since I am going to build a new model based upon the cars and owner models and when I want to add a new owner record and attach the ownerID to the cars ownerID field, the system will tell me that the ModelState is invalid. This allows me to get around that to add the owner record which will generate the ownerID value


-Create a model that consists of the cars and owner models

```csharp
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CarsRUs.Models
{
    public class CarsOwner
    {
        public Cars cars { get; set; }
        public Owner owner { get; set; }
    }
}
```


NOTE: You will NOT be able to create a scaffolded controller and view based upon this model. Even if you try to create a key, the system will not be happy. We will need to create empty controllers and views and then make them strong ourselves by adding the model.


- Modify the Global.asax file

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using CarsRUs.Models;
using CarsRUs.DAL;
using System.Data.Entity;

namespace CarsRUs
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer<CarOwnersContext>(null);

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
```


- Add a new folder called DAL and create a new class for the DbContext variable

```csharp
using CarsRUs.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CarsRUs.DAL
{
    public class CarOwnersContext : DbContext
    {
        public CarOwnersContext() : base("CarOwnersContext")
        {
        }

        public DbSet<Cars> car { get; set; }
        public DbSet<Owner> owner { get; set; }
    }
}
```

- Build the project (NOTE: I would build each time you add a model – just to be safe)
- Modify the landing page to look however you want it to look. 
- I added a link to take the user to the Index action method in the CarsController to be created

```html
@{
    ViewBag.Title = "Home Page";
}

<div class="jumbotron">
    <h1>Car Database Tracker</h1>
</div>

<div class="row">
    <div class="col-md-4">
        <h2>Cars</h2>
        <p>@Html.ActionLink("List Cars", "Index", "Cars")</p>
    </div>
</div>
```

- Create a scaffolded MVC Controller – EMPTY controller called CarsController
- Make the newly created controller Strongly typed and return the list of cars to the view
- Also add the DbContext variable to the controller

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarsRUs.Models;
using CarsRUs.DAL;
using System.Net;
using System.Data.Entity;

namespace CarsRUs.Controllers
{
    public class CarsController : Controller
    {
        CarOwnersContext db = new CarOwnersContext();

        // GET: lists
        public ActionResult Index()
        {
            return View(db.car.ToList());
        }
    }
}
```


NOTE: This method will be used to display the list of cars


- Right mouse click within the newly created controller and choose Add View
- Leave the name as Index and Empty (without model) and click Add
- Modify the view to display the list of cars by making it strongly typed (@model) and adding a link that will take the user to the AddOwner action method (that we will soon create) passing the carID as a parameter

```html
@model IEnumerable<CarsRUs.Models.Cars>

@{
    ViewBag.Title = "Index";
}

<h2>Attach Owner to Car</h2>

<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(model => model.carName)
        </th>
        <th></th>
    </tr>

    @foreach (var item in Model)
    {
        <tr>
            <td>
                @Html.DisplayFor(modelItem => item.carName)
            </td>
            <td>
                @Html.ActionLink("Add Owner", "AddOwner", new { id = item.carID})
            </td>
        </tr>
    }

</table>
```

- Go back to the CarsController and add a new action method for the AddOwner action by typing in the following code:

```csharp
// GET: Owners/AddOwner/5
public ActionResult AddOwner(int? id)
{
    if (id == null)
    {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
    }
    CarsOwner carowner = new CarsOwner();

    carowner.cars = db.car.Find(id);

    if (carowner.cars == null)
    {
        return HttpNotFound();
    }

    if (carowner.cars.ownerID != null)
    {
        return RedirectToAction("CarOwned", "Cars");
    }

    return View(carowner);
}
```

NOTE: This method will receive the car id as a parameter from the Cars Index view ActionLink and name it “id” in this controller. It will find a car record from the car table in the dbcontext and add it to the cars model within the carowner model

```csharp
Carowner.cars = db.car.Find(id);
```


Notice that you need to first create an object for the model carowner

```csharp
CarsOwner carowner = new CarsOwner();
```


If the cars ownerID field already has a value, we will redirect control to a controller we will create later called CarOwner in the CarsController (You will also create the view for CarOwner that will display a message that the car already has an owner and allow the user to go back to the list of cars in the Cars | Index)


- Right mouse click within the AddOwner controller and choose Add | View
- Leave the name as AddOwner with the Empty (without model) and click Add


NOTE: This newly created view for AddOwner will display the car information and then allow the user to type in a new car owner

- Type in the following source code for the AddOwner view:

```html
@model CarsRUs.Models.CarsOwner

@{
    ViewBag.Title = "Add Car";
}

<h2>Add Car</h2>

<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(model => model.cars.carName)
        </th>
        <th></th>
    </tr>
    <tr>
        <td>
            @Html.DisplayFor(model => model.cars.carName)
        </td>
    </tr>
</table>

@using (Html.BeginForm())
{
    @Html.AntiForgeryToken()

    <div class="form-horizontal">
        <h4>Owner for the Car</h4>
        <hr />
        @Html.ValidationSummary(true, "", new { @class = "text-danger" })
        @Html.HiddenFor(model => model.cars.carID)
        @Html.HiddenFor(model => model.cars.carName)
        @Html.HiddenFor(model => model.cars.ownerID)

        <div class="form-group">
            @Html.LabelFor(model => model.owner.ownerFirstName, htmlAttributes: new { @class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(model => model.owner.ownerFirstName, new { htmlAttributes = new { @class = "form-control" } })
                @Html.ValidationMessageFor(model => model.owner.ownerFirstName, "", new { @class = "text-danger" })
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(model => model.owner.ownerLastName, htmlAttributes: new { @class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(model => model.owner.ownerLastName, new { htmlAttributes = new { @class = "form-control" } })
                @Html.ValidationMessageFor(model => model.owner.ownerLastName, "", new { @class = "text-danger" })
            </div>
        </div>

        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <input type="submit" value="Add Owner" class="btn btn-default" />
            </div>
        </div>
    </div>
}

<div>
    @Html.ActionLink("Back to List", "Index")
</div>

@section Scripts {
    @Scripts.Render("~/bundles/jqueryval")
}
```


Notice that we made the view strongly typed to the CarsOwner model. This now allows us to access the car information and the owner information.


We hid the following fields because we need them to validate our model:

```html
@Html.HiddenFor(model => model.cars.carID)
@Html.HiddenFor(model => model.cars.carName)
@Html.HiddenFor(model => model.cars.ownerID)
```


We did not have to include the ownerID from the owner table since in the owner model we said to make it hidden


When the user clicks on the Post method we want to try and create a new owner and then attach the newly created ownerID field (created by the database since it was an identity field) and attach it to the car.ownerID field

- Go back to the CarsController and add new AddOwner action method for the POST 

```csharp
// POST: Owners/AddOwner
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddOwner( CarsOwner carsowner)
        {
            if (ModelState.IsValid)
            {
                var entity = new Owner() { ownerFirstName = carsowner.owner.ownerFirstName, ownerLastName = carsowner.owner.ownerLastName };

                db.owner.Add(entity);

                db.SaveChanges();
                
                int newOwner = (int)entity.ownerID;

                using (db)
                {
                    // make sure you have the right column/variable used here
                    var cars = db.car.FirstOrDefault(x => x.carID == carsowner.cars.carID);

                    if (cars == null) throw new Exception("Invalid id: " + carsowner.cars.carID);

                    // this variable is tracked by the db context
                    cars.ownerID = newOwner;

                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }

            return View(carsowner);
        }
```

Notice that we said the parameter that was passed by the submit button for the post was a carsowner model


The code checks the model to see if it passed validity checks and then creates a new object referring to the Owner class (from the model)


The code loads up the fields in the owner model except for the ownerID since it will be auto created


It loads the data from the carsowner model and the owner model WITHIN the carsowner model


```csharp
var entity = new Owner() { ownerFirstName = carsowner.owner.ownerFirstName, ownerLastName = carsowner.owner.ownerLastName };
```


Then the code adds a new record to the owner table and saves the changes

``` csharp
db.owner.Add(entity);
db.SaveChanges();
```


The entity was patterned after the Owner model


Then the code stores the newly created value for the ownerID identity field into a variable:

``` csharp
int newOwner = (int)entity.ownerID;
```


And using the dbcontext variable, finds the car record that has the carID we have been working with and stores a reference to it in a variable called cars

```csharp
using (db)
{
// make sure you have the right column/variable used here
       var cars = db.car.FirstOrDefault(x => x.carID == carsowner.cars.carID);

       if (cars == null) throw new Exception("Invalid id: " + carsowner.cars.carID);

       // this variable is tracked by the db context
       cars.ownerID = newOwner;

       db.SaveChanges();
}
```


If the car record is NOT found, the system will throw an exception with an error message


Otherwise, control will continue on and the code stores the value in newOwner (which was the newly created ownerID value) into the ownerID for the referenced car record and save the changes


- All that is left to do is to create the CarOwned controller that will be called if the ownerID has already been assigned to a car and the CarOwned view
- In the CarsController add the action method for CarOwned:

```csharp
// GET: Cars
public ActionResult CarOwned()
{
    return View();
}
```

- Right mouse click in the action method and choose Add View
- Leave the name as CarOwned and Empty (without model)
- This view is very simple but you can make it as nice as you want:

```html
@{
    ViewBag.Title = "CarOwned";
}

<h2>CarOwned</h2>

The car is already owned

@Html.ActionLink("Go back to the Car Listings", "Index");
```

- The actionlink will send the user back to the Car | Index view to list the cars again
- Save the project, Build and Run
