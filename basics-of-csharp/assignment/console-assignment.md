# MLS Soccer League

This program represents one of the conferences of the MLS Soccer League. You will need a Team parent class and a child soccer class. You will create an ASP.NET Web Application (.NET Framework). Choose Empty and MVC. You will be required to create models, a controller called IndexController, and a view called Index.

## Requirements 

- [ ] Program uses a `List` object to store the list of soccer teams
- [ ] Program uses another `List` object to store the sorted list of soccer teams
- [ ] Soccer teams are sorted by the team's points in descending order
- [ ] Result table has table headers for `Ranking`, `Ream Name`, and `Points`
- [ ] Result table displays each team's ranking (generated in a loop starting at 1), team name, and points as a table row
- [ ] Properly implements Team and SoccerTeam classes with inheritance
- [ ] Adds comments to make code easier to understand
- [ ] Improving the layout of the html output is worth up to 10 points (otherwise if all works you receive a 90%). This will be subjective in grading so I would hope you will make it look professional
- [ ] Upload the zipped project (entire solution) to the Learning Suite assignment (one per team) and then schedule a time with the TAs for them to grade this assignment


### Create Team and SoccerTeam Classes As Models

You need to create a parent class model called `Team` that has the following properties:

``` csharp
public string name { get; set; }
public int wins { get; set; }
public int loss { get; set; }
```


You need to create a subclass model called `SoccerTeam` that inherits from the `Team` class and that has the following properties:

```csharp
//empty constructor
public SoccerTeam()
{

}
//constructor with name and points
public SoccerTeam(string teamName, int teamPoints)
{
    base.name = teamName;
    this.points = teamPoints;
}

public int draw { get; set; }
public int goalsFor { get; set; }
public int goalsAgainst { get; set; }
public int differential { get; set; }
public int points { get; set; }
```

The SoccerTeam class should have a constructor that receives the `name` and `points` values as parameters and assigns them to the properties.


### Creating the lists in the controller


Create a new controller called IndexController. In this controller you will create a list of SoccerTeam objects. Use a List of SoccerTeam objects instead of an array. 


```csharp
//declare variables
List<SoccerTeam> lstTeams = new List<SoccerTeam>();
List<SoccerTeam> lstSorted;
```


### Loading the data in the controller


Use a newly created List of SoccerTeam objects and add the following data: 

| Team Name | Points |
| --- | --- |
| RSL | 35 |
| Colorado | 24 |
| FC Dallas | 42 |
| Sporting KC | 39 |
| San Jose | 16 |
| Houston | 27 |
| Seattle | 32 |
| Vancouver | 33 |
| Minnesota | 29 |
| Portland | 37 |
| LA Galaxy | 37 |
| LAFC | 39 |


Here is how you could add the data using the Add method for the list object


```csharp
//Load the data
lstTeams.Add(new SoccerTeam("RSL", 35));
```

### Sorting the data in the controller


Using the list of Soccer Teams you created, sort the data in DESCENDING order and store it to a new list thus preserving the original.

You use a linq expression (to de discussed in class at a later point but the code is provided) to sort the list in descending order based upon the number of points the soccer team has earned. For example, the statement below says to use a list of soccer teams called lstTeams and order it in descending order by passing each item in the list of lstTeams to the x variable. Then it says to use THAT object and look at the name attribute for the sorting. When completed it returns the results as a new list to lstSorted. It seems magical ;) and that is why we love to use it!

```csharp
//Sort the list
List<SoccerTeam> lstSorted = lstTeams.OrderByDescending(x => x.name).ToList();
```

*NOTE: This is a linq statement that can be interpretted to say "Using the list called `lstTeams`, which is like an array of team names, sort it in descending order by grabbing each element one at a time and looking at the `name` attribute of that element/object. Sort it in descending order if needed and when the sorting is done, return the sorted list to the new list variable called `lstSorted`.*



### Create the dynamic HTML in the controller


Use the MVC ViewBag dictionary data structure in the controller to store dynamically generated HTML statements. Use a table that consists of headers for the Ranking, Team Name, and Points. Then use a `foreach` statement on the list of SoccerTeam objects to display the team ranking (after the sort - this will just be a counter that starts at 1), the team name, and the team points.

You might want to look at the `PadRight()` method to help format the data in each row:

```csharp
ViewBag.Output += "<table>";
ViewBag.Output += "<tr>";
ViewBag.Output += "<th>Ranking</th>";
ViewBag.Output += "<th>Team Name</th>";
ViewBag.Output += "<th>Points</th>";
ViewBag.Output += "</tr>";
```


### Create the View and display the results


Right mouse click in the controller and choose Add View. Make sure it has the name Index. 

```csharp
@{
    ViewBag.Title = "Index";
}

<h2>MLS Standings</h2>
@Html.Raw((String)ViewBag.Output)
```


### Output


Have fun with this and make it look professional. Sloppy output will result in 0 out of 10 points. The grading will be subjective for the output but the TAs will be able to tell whether or not your team put in necessary effort to receive more points.







