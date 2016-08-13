# Creating Threads in a Console Application

This application will demonstrate how to create 2 threads in a console application. The threads will run concurrently and display values to the console window.

The use of threads can improve performance when you “offload” computation to threads and allow the end user to continue to work on other processes.


## Getting Started

Create a new console application called `ConsoleThreads` as follows:

* Create a new project by Clicking on the `File > New > New Project` menu item
* Select `Visual C# > Windows Desktop > Console Application`
  - make sure the .NET Framework 4.5.1 is selected along with the Create directory for solution checkbox
* Enter the Name of `ConsoleThreads` and click on the OK Button

![create-console-threads](https://cloud.githubusercontent.com/assets/8953261/16710772/0f2c2cae-45f8-11e6-99a9-4ff9ee05a8a3.png)

* Finally, make sure your project has the following `usings` at the top of the file you are working in:

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
```


## Creating Methods

Threads are used to split work between multiple processes. First, let's make some methods that we want to run simultaneously. Please the following code inside the `Program` class but above the `Main` method:

```csharp
static void methodA()
{
  for (int i = 0; i < 100; i++)
  {
    Console.WriteLine("A " + Convert.ToString(i));
  }
}

static void methodB()
{
  for (int i = 0; i < 100; i++)
  {
    Console.WriteLine("B " + Convert.ToString(i));
  }
}
```


## Creating Threads

Finally, we will create `ThreadStart` and `Thread` objects and use the `Start` and `Join` methods. Within your `Main` function, create 2 `ThreadStart` objects:

```csharp
ThreadStart threadStart1 = new ThreadStart(methodA);
ThreadStart threadStart2 = new ThreadStart(methodB);
```

Notice we passed the names of our "time-consuming" methods to these objects. This way, our methods will be executed when we start the threads.

Next, create 2 actual `Thread` objects:

```csharp
Thread thread1 = new Thread(threadStart1);
Thread thread2 = new Thread(threadStart2);
```

We pass our `ThreadStart` objects to our new `Thread`s. All that's left is to `Start` and `Join` our threads.


## `Start`ing and `Join`ing

Use the `Start` and `Join` methods to run your threads:

```csharp
// Tell the system to start the threads
thread1.Start();
thread2.Start();

// Tell the system to execute the thread until it completes
thread1.Join();
thread2.Join();
```

## Finishing up

Finally, add `Console.ReadLine()` to the end of your `Main` method to pause the window before exiting.

If all went according to plan, you will see a console window displayed showing the calls from your methods. Notice that the threads are not given the same amount of processing time. That is determined by the operating system.

Something not working? Feel free to compare with the provided source file to find your mistake!
