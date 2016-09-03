# Olympic Soccer Tournament

Draw a class diagram that represents a Soccer Tournament. You will need a Team parent class, a child soccer class, and a game class. Write a program that prompts the user to enter in the number of teams competing in an olympic soccer tournament. Then for the number of teams entered, prompt the user to enter the name of the team and the number of points the team has scored. Finally, display the results of the tournament.  Make sure your console output matches the sample screenshot in the requirements below exactly.

## Requirements 

- [ ] Console output matches sample output completely (see screenshot below)
- [ ] First letter of each teams's name is capitalized
- [ ] Program uses a `List` object to store the list of teams
- [ ] Teams are sorted by the team's points in descending order
- [ ] Result table has column headers and separators for `Position`, `Name`, and `Points`
- [ ] Result table displays each team's position, name, and points
- [ ] Properly implements [Team and SoccerTeam classes](#create-team-and-soccerteam-classes) but you do NOT need to implement the Game class
- [ ] Use exception handling to make sure that the number of teams they enter is a valid integer (try/catch within a while loop).
- [ ] Adds comments to make code easier to understand
- [ ] Upload the project here and also upload the zipped project to the Learning Suite assignment (include the class diagram in your upload in the main root directory for your project so TAs can easily find it) and then schedule a time with the TAs for them to grade this assignment

![console-output](https://cloud.githubusercontent.com/assets/8953261/17834223/07e10282-66f3-11e6-8e1b-30ec4c018968.jpg)


### Create Team and SoccerTeam Classes

You need to create a parent class called `Team` that has the following properties:

``` csharp
public string name
public int wins
public in loss
```


You need to create a subclass called `SoccerTeam` that inherits from the `Team` class and that has the following properties:

```csharp
public int draw
public int goalsFor
public int goalsAgainst
public int differential
public int points
```

Each class should have a constructor that receives the `name` and `points` values as parameters and assigns them to the properties.

## Project Tips


### Capitalizing the Team's Name

When the user enters the team name, we want to capitalize the first character.

To do this, create a method like the following in your main class:

```csharp
static string UppercaseFirst(string s)
{
  // Check for empty string.
  if (string.IsNullOrEmpty(s))
  {
    return string.Empty;
  }
  // Return char and concat substring.
  return char.ToUpper(s[0]) + s.Substring(1);
}
```

You will captitalize the team name by calling the UppercaseFirst method on the user's input like this:

```csharp
string userInput = Console.ReadLine(); // reads in "united states"
string teamName = UppercaseFirst(userInput); // teamName = "United states"
```


### Storing and Sorting the User's Input 


Use a List of SoccerTeam objects instead of an array. Use the Add method to add the objects to the list.

Then using a linq expression (to de discussed in class), sort the list in descending order based upon the number of points the team has earned. For example, the statement below says to use a list of teams and order it in descending order by the name property within the list (assuming the list was a list of objects):

```csharp
List<Team> sortedTeams = teams.OrderByDescending(team => team.name).ToList();
```

*NOTE: This is a linq statement that can be interpretted to say "Using the list called `teams`, which is like an array of team names, sort it in descending order by grabbing each element one at a time and looking at the `name` attribute of that element/object. Sort it in descending order if needed and when the sorting is done, return the sorted list to the variable called `sortedTeams`.*


### Displaying Tournament Results

To create the table rows, use a `foreach` statement on the list of SoccerTeam objects to display the team position (after the sort), the team name, and the team points.

You might want to look at the `PadRight()` method to help format the data in each row:

```csharp
Convert.ToString(name).PadRight(25, ' ');
```

This statement says to use the variable called 'name' and convert it to a string and then pad it to the right with spaces until the length including the data and spaces equals 25.

### More methods you might use:

```csharp
Convert.ToInt32(stringValue)
PadRight(totalLength, chartoInsert)
Convert.ToString(intValue)
```






