<h1>Data Structures C#</h1>

## Contents
1. What are Data Structures?
2. C# Data Strucures
  - Array
  - ArrayList
  - List
  - LinkedList
  - Dictionary
  - Hashtable
  - HashSet
  - Stack
  - Queue
3. Other Resources

## What are Data Structures?

- A data structure is a format for organizing and storing data
- If used properly it can make your programs more efficient
- Some of the most commonly used structures include array, list, file, record, table, and tree
- The concept of data structures often arises in job interviews so it is wise to understand at least some of the basic structures
- A data structure not only allows us to organized data but it also considers the relationship of each of the items in the structure
- C# implements many structures through its visual components. However, you can also implement your own structures
- It is important to understand what each structure can do and when it is best used since choosing and implementing the correct structure helps define whether or not a program has been efficiently written

<h2>C# Data Structures</h2>

- Array
- ArrayList
- List <>
- LinkedList <>
- Dictionary <>
- Hashtable <>
- HashSet
- Stack
- Queue

### Arrays

- An array contains a list of objects or values
- The objects/values need to be of the same data time
- Used for storing data of the same type

  ```csharp
  // create new array
  int[] aiNums = new int[3];
  
  // assign array values
  aiNums[0] = 14;
  aiNums[1] = 20;
  aiNums[2] = 5;
  ```
- Array elements are fast to access
- However, you must declare the size of the array and if the size ever needs to change, you must copy all of the elements from the old array to the newly sized array

### ArrayList

- An arraylist is a dynamic array
- It can contain a list of objects or values of any data type (mixed)
- However, each time you add an element, the size of the arraylist is doubled
- Since the arraylist can hold any data type you have to cast the value when it is retrieved (do not use – instead use list or other data structure)

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

- A list is a collection and is like the ArrayList but you must specify the data type
- It is cleaner code and faster in execution
- You should use a List over an ArrayList
- Lists are powerful and performs well
- They provide flexible allocation and growth, making it easier to use than arrays.

  ```csharp
  // create new List
  List<string> alNames = new List<string>();
  
  // add items to List
  alNames.Add("Bugs");
  alNames.Add("Daffy");
  ```

### LinkedList

- A LinkedList is a collection like a list but each of the elements are linked together like nodes (not used as much)
- Each element basically stores 3 different pieces of information: value, next node, previous node
- The benefit it manipulating the size of the linked list. If you add an element in the middle of a list, the system has to "make room" for it with the extra space it has been creating
- The linked list simply puts the item at the end and changes the values for the next and previous nodes (like a point to where did it come from and where should it go next)
- Allows fast inserts and deletions
- LinkedList seems a little slower than lists in processing within loops but difference was very small
- The primary advantage of linked lists over arrays is that the links provide us with the capability to rearrange the items efficiently.

  ```csharp
  // create new LinkedList
  LinkedList<string> lnklstNames = new LinkedList<string>();
  
  // add items to LinkedList
  lnklstNames.AddFirst("Goofy");
  lnklstNames.AddFirst("Daffy");
  ```

### Dictionary

- A Dictionary is similar to an ArrayList but it allows the developer to create and handle its own keys for indexing.
- ArrayLists uses indexes that go up by 1 each time
- Dictionary can be assigned by the programmer
- Optimized for speed
- Fast for lookups

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

### Hashtable

- A Hashtable is like a dictionary data structure in that it has a key/value pair
- However, the order in which they are added is not preserved like a dictionary
- This means that a Hashtable can store items quicker than a dictionary since the dictionary keeps things in order as they are added
- Optimizes lookups but Hashtable is slower than the Dictionary data structure and is now Obsolete

  ```csharp
  Hashtable myHashTable = new Hashtable();
  
  myHashTable.Add("bugs", 25);
  myHashTable.Add("Daffy", 35);
  
  Console.WriteLine("Bugs Bunny is " + myHashTable["bugs"] + " years old")
  ```

### HashSet

- A Hashset is a special form of the List data structure where in there cannot be any duplicate values within the list
- When an element is added the data structure makes sure the value is not already present
- Eliminates duplicate elements in the array
- The Dictionary has a slightly better performance than Hashset and should probably be used instead

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

### Stack
- A Stack resembles a list and has an add (Push) and get (Pop) method
- However, the difference is the Pop method actually retrieves AND removes the element from the list
- The Peek method allows you to check the top value in the stack
- Stacks are called LIFO (Last in, First out) meaning that the last element you push onto the stack will be the first element when you retrieve the data
- Think of a stack like the "springy" plate stacker at Hometown Buffet. When they bring out a new stack of plates to add, the last one added is the first one a customer will grab
- Stacks are commonly used within languages/operating systems. For example, method calls are stored in a stack. The last method called will return to the previous method and so forth, popping completed methods off the stack	

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

- A Queue is similar to a stack but instead of LIFO, it uses FIFO (First in, First out)
- Think of a queue like a line to buy something. The first in line is the first one to purchase and get out of the line
- The add or push method in a queue is called Enqueue
- the get or pop method in a queue is called Dequeue
- The Peek method allows you to view the top value and like the Stack does NOT remove it
- Queues are used within languages/operating systems. The first task started should be the first task executed
- Commonly used to hold tasks that need to be executed on a first-come, first-served basis

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

## Other Resources

- [Arrays](http://www.dotnetperls.com/array)
- [ArrayLists](http://www.dotnetperls.com/arraylist)
- [List](http://www.dotnetperls.com/list)
- [LinkedList](http://www.dotnetperls.com/linkedlist)
- [Dictionary](http://www.dotnetperls.com/dictionary)
- [Hashtable](http://www.dotnetperls.com/hashtable)
- [HashSet](http://www.dotnetperls.com/hashset)
- [Stack](http://www.dotnetperls.com/stack)
- [Queue](http://www.dotnetperls.com/queue)




