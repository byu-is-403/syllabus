<h1>Java Compared to C#</h1>

## Program Structure

<table>
  <thead>
    <tr>
      <th>Java</th>
      <th>C#</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td>
        <pre lang="java">
package hello;

public class HelloWorld {
  public static void main(String[] args) {
    String name =  "Java";

    System.out.println("Hello, " + name + "!");
  }
}
        </pre>
      </td>
      <td>
        <pre lang="csharp">
using System;

namespace Hello {
  public class HelloWorld {
    public static void Main(string[] args) {
      string name = "C#";

      Console.WriteLine("Hello, " + name + "!");
    }
  }
}
        </pre>
      </td>
    </tr>
  </tbody>
</table>

## Comments

<table>
  <thead>
    <tr>
      <th>Java</th>
      <th>C#</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td>
        <pre lang="java">
// Single line
/* Multiple
    line */
/** Javadoc documentation comments */
        </pre>
      </td>
      <td>
        <pre lang="csharp">
// Single line
/* Multiple
    line */
/// XML comments on a single line
/** XML comments on
      multiple lines */
        </pre>
      </td>
    </tr>
  </tbody>
</table>

## Data Types

<table>
  <thead>
    <tr>
      <th>Java</th>
      <th>C#</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td>
        <pre lang="java">
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
        </pre>
      </td>
      <td>
        <pre lang="csharp">
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
        </pre>
      </td>
    </tr>
  </tbody>
</table>


## Constants

<table>
  <thead>
    <tr>
      <th>Java</th>
      <th>C#</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td>
        <pre lang="java">
// May be initialized in a constructor
final double PI = 3.14;
        </pre>
      </td>
      <td>
        <pre lang="csharp">
const double PI = 3.14;
        </pre>
      </td>
    </tr>
  </tbody>
</table>

## Operators

<table>
  <thead>
    <tr>
      <th>Java</th>
      <th>C#</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td>
        <pre lang="java">
// Comparison
==  <  >  <=  >=  !=

// Arithmetic
+  -  *  /
%  // mod
/  // integer division if both operands are ints
Math.Pow(x, y)

// Assignment
=  +=  -=  *=  /=  %=  ^=  ++  --

// Logical
&&  ||  &  |  ^  !  // Note: && and || perform short-circuit evaluations

// String Concatenation
+
        </pre>
      </td>
      <td>
        <pre lang="csharp">
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
&&  ||  &  |   ^   !  //Note: && and || perform short-circuit logical evaluations

// String Concatenation
+
        </pre>
      </td>
    </tr>
  </tbody>
</table>


## Choices

<table>
  <thead>
    <tr>
      <th>Java</th>
      <th>C#</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td>
        <pre lang="java">
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
        </pre>
      </td>
      <td>
        <pre lang="csharp">
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
        </pre>
      </td>
    </tr>
  </tbody>
</table>


## Loops

<table>
  <thead>
    <tr>
      <th>Java</th>
      <th>C#</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td>
        <pre lang="java">
while (i < 10)
  i++;

for (i = 2; i <= 10; i + 2)
  System.out.println(i);

int i = 0;
do
  i++
while (i < 10);

for (int i : numArray) // foreach construct
  sum += 1;

// for loop can be used to iterate through any collection
import java.util.ArrayList;

ArrayList<Object> list = new ArrayList<Object>();
list.add(10);
list.add("Bisons");
list.add(2.3);

for (Object o : list) {
  System.out.println(o);
}
        </pre>
      </td>
      <td>
        <pre lang="csharp">
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
        </pre>
      </td>
    </tr>
  </tbody>
</table>

## Arrays

<table>
  <thead>
    <tr>
      <th>Java</th>
      <th>C#</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td>
        <pre lang="java">
int nums[] = {1, 2, 3} // or int[] nums = {1, 2, 3};

for (int i = 0; i < nums.length; i++) {
  System.out.println(nums[i]);
}

String names[] = new String[5];
names[0] = "David";

int rows = 10;
int cols = 10;
float twoD[][] = new float[rows][cols];
twoD[2][0] = 4.5;
        </pre>
      </td>
      <td>
        <pre lang="csharp">
int[] nums = {1, 2, 3};

for (int i = 0; i < nums.Length; i++) {
  Console.WriteLine(nums[i]);
}

string[] names = new string[5];
names[0] = "David";

int rows = 10;
int cols = 10;
float[,] twoD = new float[rows, cols];
twoD[2,0] = 4.5f;
        </pre>
      </td>
    </tr>
  </tbody>
</table>

## Functions

<table>
  <thead>
    <tr>
      <th>Java</th>
      <th>C#</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td>
        <pre lang="java">
// Return single value
int add(int x, int y) {
   return x + y;
}
int sum = add(2, 3);

// Return no value
void printSum(int x, int y) {
   System.out.println(x + y);
}
printSum(2, 3);

// Primitive types and references are always passed by value
void testFunc(int x, Point p) {
   x++;
   p.x++;       // Modifying property of the object
   p = null;    // Remove local reference to object
}
        </pre>
      </td>
      <td>
        <pre lang="csharp">
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
void TestFunc(int x, ref int y, ref Point p1) {
   x++;
   p1.x++;       // Modifying property of the object      
   p1 = null;    // Remove local reference to object
}
        </pre>
      </td>
    </tr>
  </tbody>
</table>

## Strings

<table>
  <thead>
    <tr>
      <th>Java</th>
      <th>C#</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td>
        <pre lang="java">
// String concatenation
String school = "Harding ";
school = school + "University";   // school is "Harding University"

// String comparison
String mascot = "Bisons";
if (mascot == "Bisons")                      // Not the correct comparison
if (mascot.equals("Bisons"))                 // true
if (mascot.equalsIgnoreCase("BISONS"))       // true
if (mascot.compareTo("Bisons") == 0)         // true
System.out.println(mascot.substring(2, 5));  // Prints "son"

// My birthday: Oct 12, 1973
java.util.Calendar c = new java.util.GregorianCalendar(1973, 10, 12);
String s = String.format("My birthday: %1$tb %1$te, %1$tY", c);

// Mutable string
StringBuffer buffer = new StringBuffer("two ");
buffer.append("three ");
buffer.insert(0, "one ");
buffer.replace(4, 7, "TWO");
System.out.println(buffer);     // Prints "one TWO three"
        </pre>
      </td>
      <td>
        <pre lang="csharp">
// String concatenation
string school = "Harding ";
school = school + "University";   // school is "Harding University"

// String comparison
string mascot = "Bisons";
if (mascot == "Bisons")                     // true
if (mascot.Equals("Bisons"))                // true
if (mascot.ToUpper().Equals("BISONS"))      // true
if (mascot.CompareTo("Bisons") == 0)        // true
Console.WriteLine(mascot.Substring(2, 3));  // Prints "son"

// My birthday: Oct 12, 1973
DateTime dt = new DateTime(1973, 10, 12);
string s = "My birthday: " + dt.ToString("MMM dd, yyyy");

// Mutable string
System.Text.StringBuilder buffer = new System.Text.StringBuilder("two ");
buffer.Append("three ");
buffer.Insert(0, "one ");
buffer.Replace("two", "TWO");
Console.WriteLine(buffer);     // Prints "one TWO three"
        </pre>
      </td>
    </tr>
  </tbody>
</table>


## Exception Handling

<table>
  <thead>
    <tr>
      <th>Java</th>
      <th>C#</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td>
        <pre lang="java">
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
        </pre>
      </td>
      <td>
        <pre lang="csharp">
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
        </pre>
      </td>
    </tr>
  </tbody>
</table>


## Namespaces

<table>
  <thead>
    <tr>
      <th>Java</th>
      <th>C#</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td>
        <pre lang="java">
package harding.compsci.graphics;


// Import single class
import harding.compsci.graphics.Rectangle;
// Import all classes
import harding.compsci.graphics.*;
        </pre>
      </td>
      <td>
        <pre lang="csharp">
namespace Harding.Compsci.Graphics {
  ...
}
// Import single class
using Rectangle = Harding.CompSci.Graphics.Rectangle;
// Import all class
using Harding.Compsci.Graphics;
        </pre>
      </td>
    </tr>
  </tbody>
</table>

## Classes

<table>
  <thead>
    <tr>
      <th>Java</th>
      <th>C#</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td>
        <pre lang="java">
// Accessibility keywords
public
private
protected
static

// Inheritance
class FootballGame extends Competition {
  ...
}
        </pre>
      </td>
      <td>
        <pre lang="csharp">
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
        </pre>
      </td>
    </tr>
  </tbody>
</table>

## Constructors

<table>
  <thead>
    <tr>
      <th>Java</th>
      <th>C#</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td>
        <pre lang="java">
class SuperHero {
  private int mPowerLevel;
  public SuperHero() {
    mPowerLevel = 0;
  }
  public SuperHero(int powerLevel) {
    this.mPowerLevel= powerLevel;
  }
}
        </pre>
      </td>
      <td>
        <pre lang="csharp">
class SuperHero {
  private int mPowerLevel;

  public SuperHero() {
     mPowerLevel = 0;
  }

  public SuperHero(int powerLevel) {
    this.mPowerLevel= powerLevel;
  }
}
        </pre>
      </td>
    </tr>
  </tbody>
</table>

## Objects

<table>
  <thead>
    <tr>
      <th>Java</th>
      <th>C#</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td>
        <pre lang="java">
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
        </pre>
      </td>
      <td>
        <pre lang="csharp">
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
        </pre>
      </td>
    </tr>
  </tbody>
</table>

## Properties

<table>
  <thead>
    <tr>
      <th>Java</th>
      <th>C#</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td>
        <pre lang="java">
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
        </pre>
      </td>
      <td>
        <pre lang="csharp">
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
        </pre>
      </td>
    </tr>
  </tbody>
</table>
