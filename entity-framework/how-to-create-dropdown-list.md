# How to Create a Dropdown List

- The first thing to do is to take care of all of the database stuff (i.e. connectionString, dbContext, Models, [Table””], etc.
- Once those are in place, creating a drop down list is easy!
- In this sample we will just use the ViewBag. Why? Because there are not many records to worry about. The positions table only has 4 -6 records and the teams table probably only has 20-30 records.
- If there are a lot of records then you might instead want to use something call a ViewModel which could make a strongly typed view and make your code cleaner and easier to maintain.
- If you are working with data that doesn’t really change much (i.e. positions, teams, cities, states, titles, etc.) then a ViewBag is acceptable.

## 1. In your controller, add the records you want to use as the look up to the ViewBag

```csharp
ViewBag.positions = db.Positions.ToList();
```

## 2. In your view, add the code necessary to display a drop down list showing the description and returning the code.

- The code returned will be the code from the look up table that you wish to store in the main table. In our case, we will use the Positions table for the look up. We will display the Position Description but return the Position Code. The returned value (Position Code) will be the value that gets back to the main table (Players.PositionCode).

```html
<div class="form-group">
    @Html.LabelFor(model => model.positionCode, htmlAttributes: new { @class = "control-label col-md-2" })
    <div class="col-md-10">
        @Html.DropDownListFor(model => model.positionCode, new SelectList(ViewBag.positions, "positionCode", "positionDesc"))
        @Html.ValidationMessageFor(model => model.positionCode, "", new { @class = "text-danger" })
    </div>
</div> 
```


NOTE: Make sure you are using the DropDownListFor since it works with a model.
