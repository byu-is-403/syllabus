# Data Structures Assignment

Write a program in C# using a console application that demonstrates the use of a Stack, Queue, and Dictionary (Map). I want you to start trying to use GitHub for this assignment.

Make sure you document your code. This might seem like a big program but it really isn't since a lot of the code is copied and reused. In fact, it might be a good idea as a group to divide up the work and then try to bring it all together into one project.

When completed, everyone needs to zip the project and upload to Learning Suite and make sure code is committed to GitHub.

As a group, schedule a time with the TAs for grading

## Menu Structure

Your application will be based around a simple menu. The functionality of each menu item is described in more detail below. The first menu prompt should be the following:

```
1. Stack
2. Queue
3. Dictionary
4. Exit
```

If the user chooses #1, display:

```
1. Add one time to Stack
2. Add Huge List of Items to Stack
3. Display Stack
4. Delete from Stack
5. Clear Stack
6. Search Stack
7. Return to Main Menu
```

If the user chooses #2, display:

```
1. Add one time to Queue
2. Add Huge List of Items to Queue
3. Display Queue
4. Delete from Queue
5. Clear Queue
6. Search Queue
7. Return to Main Menu
```

If the user chooses #3, display:

```
1. Add one item to Dictionary
2. Add Huge List of Items to Dictionary
3. Display Dictionary
4. Delete from Dictionary
5. Clear Dictionary
6. Search Dictionary
7. Return to Main Menu
```

## Functionality

**Add one item to ...** - prompts the user to enter a string and then inserts the input into the data structure.


**Add Huge List of Items to ...** – first clears the data structure and then generate 2,000 items in the data structure with the value of “New Entry” concatenated with the number. For example, New Entry 1, New Entry 2, New Entry 3. For the dictionary, the key will be the generated string ("New Entry 2") and the value will be the current number (`2`).


**Display ...** - display the contents of the data structure. You must use the foreach loop when displaying the data. Handle any errors and inform the user.


**Delete from ...** - prompt for which item to delete from the structure. Handle any errors and inform the user.


**Clear ...** - wipe out the contents of the data structure


**Search ...** - Search for an item in the data structure and return if it was found or not found and how long it took to search. You can create a StopWatch object using code like so:

```csharp
System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
```

Google how to start and stop the StopWatch and how to get the elapsed time.

**Return ...** - Return back to the main menu
