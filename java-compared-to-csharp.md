<h1>Java Compared to C#</h1>

## Program Structure

##### Java

```java
package hello;


public class HelloWorld {
  public static void main(String[] args) {
    String name =  "Java";
    
    System.out.println("Hello, " + name + "!");
  }
}
```

<h4>C#</h4>

```csharp
using System;


namespace Hello {
  public class HelloWorld {
    public static void Main(string[] args) {
      string name = "C#";
    
      Console.WriteLine("Hello, " + name + "!");
    }
  }
}
```

## Comments

#### Java
```java
// Single line
/* Multiple
   line */
/** Javadoc documentation comments */

```

<h4>C#</h4>
```csharp
// Single line
/* Multiple
   line */
/// XML comments on a single line
/** XML comments on multiple lines */
```

## Data Types

#### Java

```java
// Primitive Types
boolean
byte
char
short, int, long
float, double

// Reference Types
Object // (superclass of all other classes)
String
arrays, classes

// int to String
int x = 123;
String y = Integer.toString(x); // y is "123"

// String to int
y = "456";
x = Integer.parseInt(y); // x is 456

// double to int
double z = 3.5;
x = (int)z; // x is 3 (truncates decimal)
```

<h4>C#</h4>

```csharp

// Value Types
bool
byte, sbyte
char
short, ushort, int, uint, long, ulong
float, double, decimal

// Reference Types
object // (superclass of all other classes)
string
arrays, classes

// Conversions

// int to string 
int x = 123; 
String y = x.ToString();  // y is "123"

// string to int
y = "456"; 
x = int.Parse(y);   // or x = Convert.ToInt32(y);

// double to int
double z = 3.5; 
x = (int) z;   // x is 3  (truncates decimal)
```

## Constants

#### Java

```java
// May be initialized in a constructor 
final double PI = 3.14;
```

<h4>C#</h4>

```csharp
const double PI = 3.14;

```

## Operators

#### Java

```java
// Comparison
==  <  >  <=  >=  !=

// Arithmetic
+  -  *  /
%  // (mod)
/  // (integer division if both operands are ints)
Math.Pow(x, y)

// Assignment
=  +=  -=  *=  /=   %=   ^=   ++  --

// Logical
&&  ||  &  |   ^   !

// Note: && and || perform short-circuit logical evaluations

// String Concatenation
+
```

<h4>C#</h4>

```csharp
// Comparison
==  <  >  <=  >=  !=

// Arithmetic
+  -  *  /
%  // (mod)
/  // (integer division if both operands are ints)
Math.Pow(x, y)

// Assignment
=  +=  -=  *=  /=   %=  ^=  ++  --

// Logical
&&  ||  &  |   ^   !

//Note: && and || perform short-circuit logical evaluations
// String Concatenation
+
```

## Choices

#### Java

```java
greeting = age < 20 ? "What's up?" : "Hello";

if (x < y) 
  System.out.println("greater");
  
if (x != 100) {    
  x *= 5; 
  y *= 2; 
} else 
  z *= 6;
  
int selection = 2;
switch (selection) {      
  case 1: x++;   // Falls through to next case if no break
  case 2: y++;   break; 
  case 3: z++;   break; 
  default: other++;
}
```

<h4>C#</h4>

```csharp
greeting = age < 20 ? "What's up?" : "Hello";

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

## Loops

#### Java

```java
while (i < 10) 
  i++;

for (i = 2; i <= 10; i += 2) 
  System.out.println(i);
  
do 
  i++; 
while (i < 10);

for (int i : numArray)  // foreach construct  
  sum += i;
  
// for loop can be used to iterate through any Collection
import java.util.ArrayList;

ArrayList<Object> list = new ArrayList<Object>();
list.add(10);    // boxing converts to instance of Integer
list.add("Bisons");
list.add(2.3);   // boxing converts to instance of Double

for (Object o : list)
  System.out.println(o);
```

<h4>C#</h4>

```csharp
while (i < 10) 
  i++;

for (i = 2; i <= 10; i += 2) 
  Console.WriteLine(i);
  
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

## Arrays

#### Java
```java
int nums[] = {1, 2, 3}; // or   int[] nums = {1, 2, 3};

for (int i = 0; i < nums.length; i++)
  System.out.println(nums[i]);

String names[] = new String[5];
names[0] = "David";

float twoD[][] = new float[rows][cols];
twoD[2][0] = 4.5;
```

<h4>C#</h4>
```csharp
int[] nums = {1, 2, 3};

for (int i = 0; i < nums.Length; i++)
  Console.WriteLine(nums[i]);

string[] names = new string[5];
names[0] = "David";

float[,] twoD = new float[rows, cols];
twoD[2,0] = 4.5f;
```

## Functions

#### Java
```java
// Return single value
int Add(int x, int y) { 
   return x + y; 
}
int sum = Add(2, 3);

// Return no value
void PrintSum(int x, int y) { 
   System.out.println(x + y); 
}
PrintSum(2, 3);

// Primitive types and references are always passed by value
void TestFunc(int x, Point p) {
   x++; 
   p.x++;       // Modifying property of the object
   p = null;    // Remove local reference to object 
}
```

<h4>C#</h4>

```csharp
// Return single value
int Add(int x, int y) { 
   return x + y; 
}
int sum = Add(2, 3);

// Return no value
void PrintSum(int x, int y) { 
   Console.WriteLine(x + y); 
}
PrintSum(2, 3); 

// Pass by value (default), in/out-reference (ref)                
void TestFunc(int x, ref int y,  ref Point p2) { 
   x++; 
   p1.x++;       // Modifying property of the object      
   p1 = null;    // Remove local reference to object 
}
```

## Strings

#### Java

```java
// String concatenation
String school = "Harding "; 
school = school + "University";   // school is "Harding University"

// String comparison
String mascot = "Bisons"; 
if (mascot == "Bisons")    // Not the correct comparison
if (mascot.equals("Bisons"))   // true
if (mascot.equalsIgnoreCase("BISONS"))   // true
if (mascot.compareTo("Bisons") == 0)   // true
System.out.println(mascot.substring(2, 5));   // Prints "son"

// My birthday: Oct 12, 1973
java.util.Calendar c = new java.util.GregorianCalendar(1973, 10, 12);
String s = String.format("My birthday: %1$tb %1$te, %1$tY", c);

// Mutable string 
StringBuffer buffer = new StringBuffer("two "); 
buffer.append("three "); 
buffer.insert(0, "one "); 
buffer.replace(4, 7, "TWO"); 
System.out.println(buffer);     // Prints "one TWO three"
```

<h4>C#</h4>
```csharp
// String concatenation
string school = "Harding "; 
school = school + "University";   // school is "Harding University"

// String comparison
string mascot = "Bisons"; 
if (mascot == "Bisons")    // true
if (mascot.Equals("Bisons"))   // true
if (mascot.ToUpper().Equals("BISONS"))   // true
if (mascot.CompareTo("Bisons") == 0)    // true
Console.WriteLine(mascot.Substring(2, 3));    // Prints "son"

// My birthday: Oct 12, 1973
DateTime dt = new DateTime(1973, 10, 12);
string s = "My birthday: " + dt.ToString("MMM dd, yyyy");

// Mutable string 
System.Text.StringBuilder buffer = new System.Text.StringBuilder("two "); 
buffer.Append("three "); 
buffer.Insert(0, "one "); 
buffer.Replace("two", "TWO"); 
Console.WriteLine(buffer);     // Prints "one TWO three"
```

## Exception Handling

#### Java

```java
// Must be in a method that is declared to throw this exception
Exception ex = new Exception("Something is really wrong."); 
throw ex;  
try {
  y = 0; 
  x = 10 / y;
} catch (Exception ex) {
  System.out.println(ex.getMessage()); 
} finally {
  // Code that always gets executed
}
```

<h4>C#</h4>

```csharp
Exception up = new Exception("Something is really wrong."); 
throw up;  // ha ha

try {
  y = 0; 
  x = 10 / y;
} catch (Exception ex) {      // Variable "ex" is optional
  Console.WriteLine(ex.Message); 
} finally {
  // Code that always gets executed
}
```

## Namespaces

#### Java

```java
package harding.compsci.graphics;


// Import single class
import harding.compsci.graphics.Rectangle;
// Import all classes
import harding.compsci.graphics.*; 
```

<h4>C#</h4>

```csharp
namespace Harding.Compsci.Graphics {
  ...
}
// Import single class
using Rectangle = Harding.CompSci.Graphics.Rectangle;
// Import all class
using Harding.Compsci.Graphics;
```

## Classes

#### Java

```java
// Accessibility keywords 
public
private
protected
static

// Inheritance
class FootballGame extends Competition {
  ...
}
```

<h4>C#</h4>

```csharp
// Accessibility keywords 
public
private
internal
protected
protected internal
static

// Inheritance
class FootballGame : Competition {
  ...
}
```

## Constructors

#### Java

```java
class SuperHero { 
  private int mPowerLevel;
  public SuperHero() { 
    mPowerLevel = 0; 
  }
  public SuperHero(int powerLevel) { 
    this.mPowerLevel= powerLevel; 
  }
}
```

<h4>C#</h4>

```csharp
class SuperHero {
  private int mPowerLevel;

  public SuperHero() {
     mPowerLevel = 0;
  }

  public SuperHero(int powerLevel) {
    this.mPowerLevel= powerLevel; 
  }
}
```

## Objects

#### Java

```java
SuperHero hero = new SuperHero();
hero.setName("SpamMan"); 
hero.setPowerLevel(3); 

hero.Defend("Laura Jones");
SuperHero.Rest();  // Calling static method
SuperHero hero2 = hero;   // Both refer to same object 
hero2.setName("WormWoman"); 
System.out.println(hero.getName());  // Prints WormWoman 

hero = null;   // Free the object

if (hero == null)
  hero = new SuperHero();
Object obj = new SuperHero(); 
System.out.println("object's type: " + obj.getClass().toString()); 
if (obj instanceof SuperHero) 
  System.out.println("Is a SuperHero object.");
```

<h4>C#</h4>

```csharp
SuperHero hero = new SuperHero(); 

hero.Name = "SpamMan"; 
hero.PowerLevel = 3;

hero.Defend("Laura Jones");
SuperHero.Rest();   // Calling static method

SuperHero hero2 = hero;   // Both refer to same object 
hero2.Name = "WormWoman"; 
Console.WriteLine(hero.Name);   // Prints WormWoman

hero = null ;   // Free the object

if (hero == null)
  hero = new SuperHero();
  
Object obj = new SuperHero(); 
Console.WriteLine("object's type: " + obj.GetType().ToString()); 
if (obj is SuperHero) 
  Console.WriteLine("Is a SuperHero object.");
```

## Properties

#### Java
```java
private int mSize;

public int getSize() { return mSize; } 
public void setSize(int value) {
  if (value < 0) 
    mSize = 0; 
  else 
    mSize = value; 
}

int s = shoe.getSize();
shoe.setSize(s+1);
```

<h4>C#</h4>

```csharp
private int mSize;

public int Size { 
  get { return mSize; } 
  set { 
    if (value < 0) 
      mSize = 0; 
    else 
      mSize = value; 
  } 
}

shoe.Size++;
```
