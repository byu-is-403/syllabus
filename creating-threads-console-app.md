# Creating Threads in a Console Application

This application will demonstrate how to create 2 threads in a console application. The threads will run concurrently and display values to the console window.


The use of threads can improve performance when you “offload” computation to threads and allow the end user to continue to work on other processes.

## Getting Started

1. Create a new project by Clicking on the `File | New | New Project` menu item
  - The New Project window will be displayed
2. Select `Visual C# | Windows Desktop | Console Application`
  - make sure the .NET Framework 4.5.1 is selected along with the Create directory for solution checkbox
3. Enter the Name of `ConsoleThreads` and click on the OK Button
  

  ![create-console-threads](https://cloud.githubusercontent.com/assets/8953261/16710772/0f2c2cae-45f8-11e6-99a9-4ff9ee05a8a3.png)
  
4. In the Main method, type in the following code:
  ```csharp
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    
    
    namespace ConsoleThreads {
      class Program {
        static void Main(string[] args) {
          
          // create ThreadStart objects, which allow you to set what method you want executed when the thread starts
          ThreadStart threadStart1 = new ThreadStart(thread1Starter);
          ThreadStart threadStart2 = new ThreadStart(thread2Starter);
          
          // create actual Thread objects
          Thread thread1 = new Thread(thread1Start);
          Thread thread2 = new Thread(thread2Start);
          
          // tell the system to start the threads
          thread1.Start();
          thread2.Start();
          
          // tell the system to execute the thread until it completes
          thread1.Join();
          thread2.Join();
          
          // pause console window
          Console.ReadLine();
        }
      }
    }
  ```

5. Define methods to be executed by threads

  ```csharp
  static void thread1Starter() {
    int iCount;
    
    for (iCount = 0; iCount < 100; iCount++) {
      Console.WriteLine("A " + Convert.ToString(iCount));
    }
  }
  
  static void thread2Starter() {
    int iCount;
  
    for (iCount = 0; iCount < 100; iCount++) {
      Console.WriteLine("B " + Convert.ToString(iCount));
    }
  }
  ```

  You can name these methods anything you want but just make sure they match the name of the method parameter used in the ThreadStart object
  
6. Save the project and press F5 to execute


  You will see a console window displayed showing the calls from either the thread1Starter method or the thread2Starter method. Notice that the threads are not given the same amount of processing time. That is determined by the operating system


