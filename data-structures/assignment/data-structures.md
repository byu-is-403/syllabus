# Data Structures Assignment

Write an ASP.NET Web Aplication (.NET Framework) in C# that demonstrates the use of a Stack, Queue, and Dictionary (Map). I want you to start trying to use GitHub for this assignment with your group.

Make sure you document your code. This might seem like a big program but it really isn't since a lot of the code is copied and reused. In fact, it might be a good idea as a group to divide up the work and then try to bring it all together into one project.

When completed, one team member needs to zip the project and upload to Learning Suite and make sure code is committed to GitHub.

As a group, schedule a time with the TAs for grading

## Menu Structure

Use the NuGet package manager and add Bootstrap (by The Bootstrap Authors) to your project. 

You will need to create a controller called Index and a view called Index.Stack

Your application will be based around a basic navigation menu. 

https://www.w3schools.com/w3css/w3css_navigation.asp

The functionality of each menu item is described in more detail below. The first menu prompt should be the following:

```
1. Stack
2. Queue
3. Dictionary
4. Exit
```

Each menu item should redirect to another controller action method:

```
<a href="@Url.Action("Index", "Stack")" class="w3-bar-item w3-button">Stack</a>
```

This says to redirection to the Stack controller and find the Index action method if they click on the Stack menu item.


If the user chooses Stack, display another view with a different type of menu. Maybe like a sidebar nav:

https://www.w3schools.com/w3css/tryit.asp?filename=tryw3css_sidebar



```
1. Add one time to Stack
2. Add Huge List of Items to Stack
3. Display Stack
4. Delete from Stack
5. Clear Stack
6. Search Stack
7. Return to Main Menu
```

If the user chooses Queue, display:

```
1. Add one time to Queue
2. Add Huge List of Items to Queue
3. Display Queue
4. Delete from Queue
5. Clear Queue
6. Search Queue
7. Return to Main Menu
```

If the user chooses Dictionary, display:

```
1. Add one item to Dictionary
2. Add Huge List of Items to Dictionary
3. Display Dictionary
4. Delete from Dictionary
5. Clear Dictionary
6. Search Dictionary
7. Return to Main Menu
```

If the user chooses Exit, then redirect back to the https://www.byu.edu site


## Functionality

For each menu item you will create a variable that will be used within the controller (i.e. stack, queue, dictionary)

**Add one item to ...** - prompts the user to enter a string and then inserts the input into the data structure.


**Add Huge List of Items to ...** – first clears the data structure and then generate 2,000 items in the data structure with the value of “New Entry” concatenated with the number. For example, New Entry 1, New Entry 2, New Entry 3. For the dictionary, the key will be the generated string ("New Entry 2") and the value will be the current number (`2`).


**Display ...** - display the contents of the data structure. You must use the foreach loop when displaying the data. Handle any errors and inform the user.


**Delete from ...** - prompt for which item to delete from the structure. Handle any errors and inform the user.


**Clear ...** - wipe out the contents of the data structure


**Search ...** - Search for an item in the data structure and return if it was found or not found and how long it took to search. You can create a StopWatch object using code like so (just a simple example). Then display the information in the view.

```csharp
System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

sw.Start();

//loop to do all the work

sw.Stop();

TimeSpan ts = sw.Elapsed;

ViewBag.StopWatch = ts;
```

Google how to start and stop the StopWatch and how to get the elapsed time.

**Return ...** - Return back to the main menu
