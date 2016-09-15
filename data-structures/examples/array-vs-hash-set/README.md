# Data Structures Example

This example will help you familiarize yourself with various data structures available in the c# language. We will be loading the entire text of Peter Pan into memory and searching it for a given word to see how different data structures perform.

## Requirements

Create a new C# console application. In the `Main` function, load up the text like so:

```csharp
string text = System.IO.File.ReadAllText("./YOUR_FILE_NAME.txt");
```

Make sure `"./YOUR_FILE_NAME.txt"` is a valid path to your file. The `./` here means "relative to the current code file."

Once you have loaded the text and created your stopwatch object, you can turn it into an array of words with the `Split` function. You will want to use `' '` as your delimiter.

Now that you have an array of words, search the array for `"END"`. Note that it is all caps! If you add `using System.Linq` to the top of your file, you can use the `Contains` method to do this. Make sure you time this operation and print how long it takes to the console. That output might look something like `It took 00:00:00:XXXXs to populate the array`.

Next, let's look at a more efficient data structure: the Hash Set. Make a new HashSet with values of type `string`. Iterate over the array using a `for` or `foreach` loop and add each word to the hashset. Time this operation and print its duration to the console.

Finally, use the Hash Set's built-in `Contains` method to find `"END"`. Take note of how long it takes. Once you have printed all the information to the console, make note of which structure was fastest for doing each of the timed tasks.
