# Data Structures

## Contents
1. What are Data Structures?
2. C# Data Structures
  - Array
  - `ArrayList`
  - List
  - Linked list
  - Stack
  - Queue
  - Dictionary
  - Hash table
  - Hash set
3. Other Resources

## What are Data Structures?

A [data structure](https://en.wikipedia.org/wiki/Data_structure) is a format for organizing and storing data. Choosing the right data structures in your program can make it much more efficient. Some of the most common data structures include `array`, `list`, `table`, and `tree`. Data structures not only allow us to organize data but also helps us form logical relationships between each of the items in the structure.

C# implements many common data structures by default; it also gives you the option of implementing your own when necessary. It is important to understand what each structure can do and when it is best used since choosing and implementing the correct structure is a core part of whether or not a program is written effectively.

Questions about data structures often arise in job interviews, so it is wise to understand at least some of the basics of each structure.

<h2>C# Data Structures</h2>

### Arrays

An array is an ordered list of values. In C#, all elements in the array must be of the same data type.

**Pros**
* Very fast access
* Simple to use

**Cons**
* Size must be declared ahead of time and it is very expensive to copy all items to a new array if a larger size is needed.

```csharp
// create new array
int[] aiNums = new int[3];

// assign array values
aiNums[0] = 14;
aiNums[1] = 20;
aiNums[2] = 5;
```

### ArrayList

An `ArrayList` is a dynamic array, meaning it resizes itself as it fills up to make more room for new elements. It can contain values of any combination of data types.

**Pros**
* Easier to use than `Array`

**Cons**
* You must case values when they are retrieved which is expensive and dangerous. Generally it is better to use a different structure like `List`.
* Although it is nice that it grows dynamically, it does so by doubling in size each time it fills up, so you risk wasting a lot of memory.

```csharp
// create new ArrayList
ArrayList alNames = new ArrayList();

// add items to ArrayList
alNames.Add("Bugs");
alNames.Add("Daffy");

// access ArrayList values
string sName = alNames[0].ToString();
```

### List

A list is a collection like `ArrayList` except it can only hold only 1 data type. It is much cleaner and faster in execution that `ArrayList` and should generally be preferred.

**Pros**
* Powerful and have excellent performance
* Flexible allocation and allows for growth, making it easier to use than an array

**Cons**
* The ordered nature of lists makes them unsuitable for some applications

```csharp
// create new List
List<string> alNames = new List<string>();

// add items to List
alNames.Add("Bugs");
alNames.Add("Daffy");
```

### Linked list

A linked list is a collection like a list except that each of the elements are linked together in both directions instead of just one. Each element in a linked list stores 3 pieces of information: a value, a pointer to the next item (`node`) in the list, and a pointer to the previous item (`node`) in the list.

**Pros**
* Much faster insertion and deletion than `List`.
* Can efficiently re-organize items in the list

**Cons**
* Slightly slower to iterate over

```csharp
// create new LinkedList
LinkedList<string> lnklstNames = new LinkedList<string>();

// add items to LinkedList
lnklstNames.AddFirst("Goofy");
lnklstNames.AddFirst("Daffy");
```

### Stack

A stack resembles a list but has special characteristics to control the flow of and relationship between the data. Stacks are commonly used internally in programming languages and operating systems. For example, method calls are stored in a stack.

Stacks are LIFO (last in, first out) structure, meaning the last element you push onto the stack will be the first element when you retrieve the data. Stacks have two main functions: `Push` for adding items and `Pop` for getting items. The `Pop` method will _retrieve and remove_ the element from the list. C# also provides a `Peek` method that allows to you preview the next item without popping it off the stack.

To understand a stack better, think of it like a springy plate stacker at Hometown Buffet. When they bring out new plates and push them on top of the others, the last one added is the first one a customer will grab.

**Pros**
* Can be useful for controlling the flow of data
* Very lightweight data structure

**Cons**
* Its characteristics limit access to data which can be inconvenient

```csharp
Stack<string> myStack = new Stack<string>();

myStack.Push("1");
myStack.Push("2");
myStack.Push("3");

while (myStack.Count > 0) {
  Console.WriteLine(myStack.Pop());
}

/*
Prints:
3
2
1
*/
```

### Queue

A queue is similar to a stack but is FIFO (first in, first out). Think of a queue like a line to buy something at a store - the first in line is the first on to purchase and get out of line.

In C#, the method to add to the queue is called `Enqueue`; the method to get the next item is `Dequeue`. Like `Stack`, it has a `Peek` method that allows you to preview the next value.

Queues are also used within programming languages and operating systems in cases where tasks should be executed in a first come, first serve basis.

**Pros**
* Simple data access management, like `Stack`,
* Very lightweight

**Cons**
* Can introduce unnecessary limitations

```csharp
Queue<string> myQueue = new Queue<string>();

myQueue.Enqueue("1");
myQueue.Enqueue("2");
myQueue.Enqueue("3");

while (myQueue.Count > 0) {
Console.WriteLine(myQueue.Dequeue());
}
/*
Prints:
1
2
3
*/
```

### Dictionary

A dictionary is a set of key-value pairs that help the developer organize data. Dictionaries are optimized for speed and are very fast for looking up stored items.

The concept of key-value pairs may seem confusing at first, but we often use a similar pattern in the real world. Take for example a home address: we assign a key (e.g. 500 E 500 N Provo, UT 84604) to the house and it helps quickly find the property.

```csharp
// key: string, value: int

// create new Dictionary
Dictionary<string, int> myDictionary = new Dictionary<string, int>();

// add entries to Dictionary
myDictionary.Add("bugs", 25);
myDictionary.Add("Daffy", 35);

// access Dictionary values
Console.WriteLine("Bugs Bunny is " + myDictionary["bugs"] + " years old"); // prints 25

// key: int, value: string

Dictionary<int, string> myOtherDictionary = new Dictionary<int, string>();

myOtherDictionary.Add(25, "bugs");
myOtherDictionary.Add(35, "Daffy");

Console.WriteLine("The character that is 35 years old is " + myOtherDictionary[35]); //Prints Daffy
```

### Hash table

A hash table is like a dictionary in that it has a key/value pair; however, the key is managed by the computer. Hash tables are optimized for lookups.

In C#, hash tables are slower than the `Dictionary` class in and are generally considered obsolete.

```csharp
Hashtable myHashTable = new Hashtable();

myHashTable.Add("bugs", 25);
myHashTable.Add("Daffy", 35);

Console.WriteLine("Bugs Bunny is " + myHashTable["bugs"] + " years old")
```

### HashSet

A hash set is a special form of list where there cannot be any duplicate values. When an element is added to the data structure, the computer checks to make sure the value isn't already present. It performs slightly slower than a dictionary, but can be useful for some applications.

**Pros**
* Prevents duplicate values

**Cons**
* Slightly slower than a dictionary

```csharp
HashSet<int> mySet = new HashSet<int>();

mySet.Add(3);
mySet.Add(5);
mySet.Add(3);
mySet.Add(10);

List<int> myListFromSet = mySet.ToList<int>();
int myInt = myListFromSet[2];   

//Prints of the value of 10 since the 2nd insertion of the value of 3 was ignored
Console.WriteLine(myInt);
```

## Other Resources

* [Itsy Bitsy Data Structures](https://github.com/thejameskyle/itsy-bitsy-data-structures) - an excellent explanation and demo of what various data structures look like, implemented in JavaScript.
* [Swift Algorithm Club](https://github.com/raywenderlich/swift-algorithm-club) - Implementations of dozens of data structures in the Swift programming language
