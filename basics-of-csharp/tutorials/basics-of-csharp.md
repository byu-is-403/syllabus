<h1>Basics of C#</h1>

Also see [Java compared to C#](https://github.com/byu-is-403/syllabus/blob/danmo91/basics-of-csharp/basics-of-csharp/java-compared-to-csharp.md) or [C++ compared to C#](https://github.com/byu-is-403/syllabus/blob/danmo91/basics-of-csharp/basics-of-csharp/csharp-console-app.md)


## Contents

- [Program Architecture](#program-architecture)
- [Comments](#comments)
- [Data Types and Variables](#data-types-and-variables)
- [operators](#operators)
- [If and Switch](#if-and-switch)
- [Loops](#loops)
- [Classes](#classes)
- [Exception Handling](#exception-handling)
- [LINQ/Lambda](#linqlambda)


### Program Architecture

When you build a new project you get something like this:

```csharp
using System;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
```

Let's break down what each piece of code means.


#### The `using` Directive

This sample project begins with:

```csharp
using System;
```

This tells the compiler that we are **using** the `System` namespace and gives us access to all of the functions that belong to [System](https://msdn.microsoft.com/en-us/library/system(v=vs.110).aspx) within our program.  This is what allows us to use `Console.WriteLine()`, the alternative would be specifying that we are using `System`'s `Console.WriteLine()` like this:  `System.Console.WriteLine()`


There are three uses for the `using` directive:

1. To allow the use of types in a namespace so that you do not have to qualify the use of a type in that namespace:

  ```csharp
  using System.Console;

  ...

  // Console belongs to the System namespace
  Console.WriteLine();
  ```

2. To allow you to access static members of a type without having to qualify the access with the type name:

  ```csharp
  using static System.Math;

  ...

  // Abs belongs to the System.Math namespace
  Abs(-3.14);
  ```

3. To create an alias for a namespace or a type. This is called a *using alias directive*.

  ```csharp
  using Project = PC.MyCompany.Project;
  ```


#### namespace

The namespace keyword is used to declare a `scope` that contains a set of related objects. You can use a namespace to organize code elements and to create globally unique types.

You can declare the following types within a namespace:
- another namespace
- class
- interface
- struct
- enum
- delegate

If you do not declare a namespace the compiler will assign one for you.

In the context of our SampleConsoleApp, the class `Program` is available under the `ConsoleApplication` namespace.

```csharp
namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
```

You could create instances of `ConsoleApplication.Program` by importing it with `using ConsoleApplication.Program`

### Main Class

The next part of our program is the class with the `Main` method

```csharp
...

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Hello World!");
    }
}

```

Classes let you create your own objects by grouping together variables and methods.

Every C# application must contain a single `Main` method specifying where program execution is to begin. In C#, `Main` is capitalized, while Java uses lowercase main.


```csharp
public static void Main(string[] args)
{
    ...
}
```


Main can only return int or void, and has an optional string array argument to represent command-line parameters

I could pass my friend's name "Andy" as a command-line parameter like this:

```sh
dotnet run Andy
```

```csharp
public static void Main(string[] args)
{
    string name;
    try {
      name = args[0]; // Andy
    } catch (Exception e) {
      // if the user fails to pass a name just use 'World'
      name = "World";
    }
    Console.WriteLine("Hello " + name); // Hello Andy
}
```


### Comments

You may want to leave a comment for yourself or other developers to remember important things.

```chsarp
// this is a helpful single-line comment

/*
  This is a
  helpful comment
  on multiple
  lines ...
 */
```

### Data Types and Variables

Data types help you define what kind of value a variable can contain.


#### Primitive Types

- `bool` (true/false)
- `byte` (unsigned 8-bit integer range 0 to 255)
- `char` ('a')
- `short`, `int`, `long`
- `float`, `double`, `decimal`


#### Reference Types

##### `string`

```csharp
string name = "Dan";
```

##### Arrays

```csharp
string[] seaAnimals = new string[] {"jellyfish", "turtle", "penguin"};
string[] zooAnimals = {"zebra", "giraff", "monkey"};
```

##### Classes

C# has a class called `Object` which is a superclass of all other classes. In other words, every class automatically inherits from `Object`.

```csharp
public class Person {
  public string Name;
  public string FavoritePlace;
}

class Program {
  static void Main() {
    // create a new Person object
    Person dan = new Person();

    // set Name and FavoritePlace
    dan.Name = "Dan Morain";
    dan.FavoritePlace = "Chamber of Secrets";
  }
}
```


#### Nullable

Variables can contain no value at all. We call this `null`.

```csharp
string name = "Dan";
name = null;
Console.WriteLine("Hello " + name); // will throw null pointer exception
```


#### Conversions

Here are some common ways for converting a value of one data type to another:

```csharp
// int to string
int x = 123;
string y = x.toString();


// string to int
y = "456";
x = int.Parse(y); // or x = Convert.ToInt32(y);

// double to int
double z = 3.5;
x = (int) x; // x is 3 (truncates decimal)
```


#### Escape Sequences

Strings can contain special characters called `Escape Sequences`

|  **Escape sequence** | **Character name** | **Unicode encoding** |
|  :------ | :------ | :------ |
|  \' | Single quote | 0x0027 |
|  \" | Double quote | 0x0022 |
|  \\ | Backslash | 0x005C |
|  \n | New line | 0x000A |
|  \r | Carriage return | 0x000D |
|  \t | Horizontal tab | 0x0009 |


#### Constants

You can declare variables that have values that cannot be changed.  We call these `constants`.

```csharp
const string message = "this is an unchangeable message";
```

### Operators

Operators are symbols that specify which operations to perform in an expression. You can overload many operators to change their meaning.

```csharp
// Comparison
==  <  >  <=  >=  !=

// Arithmetic
+  -  *  /
%  // mod
/  // integer division if both operands are ints
Math.Pow(x, y)

// Assignment
=  +=  -=  *=  /=   %=  ^=  ++  --

// Logical
&&  ||  &  |   ^   !

// String Concatenation
+
```

### If and Switch

Some statements help execute different code based on certain logical conditions.

Here are some examples using the Ternary operator (`? :`), If statement, and Switch statement:

```csharp
string greeting = age < 20 ? "What's up?" : "Hello";

if (x < y)  
  Console.WriteLine("greater");

if (x != 100) {    
  x *= 5;
  y *= 2;
} else
  z *= 6;

string color = "red";
switch (color) {                        
  case "red":    r++;     break; // break is mandatory; no fall-through
  case "blue":   b++;     break;
  case "green":  g++;     break;
  default:       other++; break; // break necessary on default
}
```

###  Loops

Loops repeat a specified block of code until a given condition is met.  This can be helpful if you need to perform an operation on each item in a list or something similar.

Here are some examples of `while`, `for`, `do/while`, and `foreach` loops:

```csharp
while (i < 10)
  i++;

for (i = 2; i <= 10; i + 2)
  Console.WriteLine(i);

int i = 0;
do
  i++;
while (i < 10);

foreach (int i in numArray)  
  sum += i;

// foreach can be used to iterate through any collection
using System.Collections;

ArrayList list = new ArrayList();
list.Add(10);
list.Add("Bisons");
list.Add(2.3);

foreach (Object o in list)
  Console.WriteLine(o);
```


### Classes

A class is an construct that lets you to create your own custom objects by grouping together variables of other types, methods and events. A class is like a blueprint. It defines the data and behavior of a type. If the class is not declared as static, developers can create class objects or instances which are assigned to a variable.


#### Constructors

Whenever a class is created, its constructor is called. A class may have multiple constructors that take different arguments. Constructors enable the developer to set default values

This `Person` class has three different constructors:

```csharp
public class Person {
  public string Name;
  public string Fact;

  public Person() {
    this.Name = "Default Name";
    this.Fact = "Default Fact";
  }

  public Person(string name) {
    this.Name = name;
    this.Fact = "Default Fact";
  }

  public Person(string name, string, fact) {
    this.Name = name;
    this.Fact = fact;
  }
}
```

To initialize a class you use the `new` keyword and call the class' constructor:

```csharp
Person dan = new Person("Dan", "Likes to dance");
```

#### Methods

Methods are functions that belong to a class.  You can determine who can use and access your methods by providing a scope (public, private, protected).

Here is an example of the `talk()` method on the `Animal` class:

```csharp
public class Animal {
  public string Sound;

  public Animal(string sound) {
    this.Sound = sound;
  }

  public void talk() {
    Console.WriteLine(this.Sound);
  }
}

...

Animal cow = new Animal("moo!");
cow.talk(); // prints "moo!"
```

#### Scope

Our talk method scoped at public which allowed us to access `cow.talk()`.  

Here are other options for scope:

|  **Term** | **Used With…** | **Visibility** |
|  :------ | :------ | :------ |
|  Public | Variables/Properties/Methods/Types | Anywhere in or outside of a project |
|  Private | Variables/Properties/Methods/Types | Only in the block where defined |
|  Protected | Variables/Properties/Methods | Can be used in the class where defined. Can be used within any inherited class. |


#### Static

A static method or class is basically the same as non-static, except you cannot create an instance (with the `new` keyword) of a static class.

My favorite example of static is the `System.Math` libary:

```csharp
using System.Math;

int positiveNumber = Math.Abs(-8);
```

We never created an instance of the `Math` class by calling:

```csharp
Math math = new Math();
```

because the `System.Math` class is static.  


#### Inheritance

Inheritance enables you to create new classes that reuse, extend, and modify the behavior that is defined in other classes.

Let's define a Button class that has the following properties:

```csharp

public class Button {
  string Color;
  string Width;
  string Height;
  string Text;

  public Button() {
    this.Color = "orange";
    this.Width = "200px";
    this.Height = "40px";
    this.Text = "Done";
  }
}
```

When you create an instance of the Button class it will be orange, say 'Done', and be 200px wide and 40px tall.


If we wanted another button that looked exactly the same except green, we could extend the Button class and override the color property:


```csharp
public class GreenButton : Button {
  public GreenButton() {
    this.Color = "green";
  }
}
```

The GreenButton is just like the Button except the color is green.


#### Overloading

You can overload methods on a class by creating methods that have the same name, but require different parameters.

```csharp
public class Animal {
  public Sound;

  public void talk() {
    Console.WriteLine(this.Sound);
  }

  // overloaded method
  public void talk(string sound) {
    Console.WriteLine(sound);
  }
}
```

Now you have to options for calling `Animal.talk()`
1. without a sound argument
2. with a sound argument


### Exception Handling

Most programs are very large, very complex and written by multiple people.  This combination of factors almost always leads to some kind of software bug. It's not that developers are malicious, stupid or lazy ... it's just that in the rush to meet a deadline we often don't forsee every possible thing that a user can do to our programs and something is bound to happen.

Exception handling serves two purposes:
1. it let's the user know in a friendly manner, that something has gone wrong
2. it helps the developer debug errors more efficiently by providing helpful information of what went wrong and where


Earlier we said Hello to my friend Andy, we could rewrite that code like this:
```csharp
public static void Main(string[] args) {
  string name;
  try {
    name = args[0];
  } catch (Exception e) {
    Console.WriteLine("No name argument was passed: " + e.Message);
    name = "world"
  } finally {
    Console.WriteLine("Hello " + name);
  }
}
```

in this snippet of code, we created a string variable called `name` and tried setting it to the argument passed by the user to the command-line.  If the user fails to pass the argument, the program will throw an `Exception` which we will catch and inform the user that something went wrong and set the name to 'world'.


The `Finally` block runs if the try statement succeeds or fails, in this case we wanted to print 'Hello' to whoever was listening.


### LINQ/Lambda

A [lambda expression](https://simple.wikipedia.org/wiki/Anonymous_function) is an anonymous function that you can use to write local functions that can be passed as arguments or returned as the value of function calls. Lambda expressions are particularly helpful for writing LINQ query expressions.

To create a lambda expression, you specify input parameters (if any) on the left side of the _lambda operator_ `=>`, and you put the expression or statement block on the other side. For example, `c => c.City == "London"` is a lambda expression that passes a variable `c` into a function that compares `c.City` and a string, `"London"`. In context, this might look like the following:

```csharp
List<Customer> customersInLondon = customers.Where(c => c.City == "London");
```

This line of code says, give me a list of customers where the city is equal to "London".  We pass the lambda expression into `customer.Where()` so the returned list only contains customers where `c.City == "London"` is equal to `true`.
