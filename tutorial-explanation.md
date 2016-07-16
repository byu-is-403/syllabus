# Tutorial Explanation

## Teams, Index View

- `@Html.DisplayNameFor` (extracts the column name out of the table i.e. teamName)
- `@Html.DisplayFor` (extracts the column text out of the table i.e. Utah Jazz)
- `@Html.ActionLink` (text to display as a link, controller to call (Edit in the Teams controller), what data to pass the controller (teamID)

```html
@model IEnumerable<FantasyBasketball.Models.Team>

@{
  ViewBag.Title = "Index";
}

<h2>Index</h2>

<p>
  @Html.ActionLink("Create New", "Create")
</p>

<table class="table">
  <tr>
    <th>
      @Html.DisplayNameFor(model => model.teamName)
    </th>
    <th></th>
  </tr>
  
  @foreach (var item in Model) {
    <tr>
      <td>
        @Html.DisplayFor(modelItem => item.teamName)
      <td>
      <td>
        @Html.ActionLink("Edit Team", "Edit", new { id=item.teamID }) | 
        @Html.ActionLink("Details", "Details", new { id=item.teamID }) | 
        @Html.ActionLink("Delete", "Delete", new { id=item.teamID })
      </td>
    </tr>
  }
  
</table>

```


### Explanation of helpers

```html
@model IEnumerable<FantasyBasketball.Models.Team>
```

Includes the Team model which links back to the Team table through the DbSet in our NBAContext class.  The IEnumerable says to return a list of objects/rows

```html
@Html.ActionLink("Create New", "Create")
```

This HTML Helper creates a link on the page with the text of Create New.  When clicked it will call the Create action method in the Team controller

```html
@Html.DisplayNameFor(model => model.teamName)
```

This HTML Helper extracts the column name from the model/table.  For example, the teamName column name in the table is "teamName" so that will be displayed.  You will see later that you can set up other column display names using attributes in the model

```html
@foreach (var item in Model) {
  ...
}
```

The foreach uses razor and it creates a for loop that is used for ever record in the model.  For each record in the model being used, Team, get the row and store it to the variable called item.  You could have used any variable name instead of item (i.e. i, row, etc.)

```html
@Html.DisplayFor(modelItem => item.teamName)
```

- The `DisplayFor` extracts the data from the model item record for the teamName column
- `modelItem => ` is a lambda expression delegate / function pointer.  The word modelItem is pretty much ignored and you could have used any word

```html
@Html.ActionLink("Delete", "Delete", new { id=item.teamID })
```

- This HTML helper creates a link similar to what was described earlier.  The link underlined text would be "Delete" and the action would be Delete in the Teams controller.  Notice that another parameter is passed which is a new object holding the value of the teamID and the parameter name is id.  This should match your paramter coming into the controller


