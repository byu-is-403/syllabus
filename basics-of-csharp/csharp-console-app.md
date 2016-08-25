# My First Console App

The Console in ASP.NET represents a text based computer program (i.e. text terminal) such as a command line text operating system. Console applications still exist but for the most part, graphical user interface (GUI) applications are what users prefer.

Visual Studio .NET has the ability to create console and GUI applications.

This tutorial will show the very basics of a writing data to the console so the end user can see the information. It will also show how to pause the screen since usually in a console application once the program completes the console window is closed.

## Getting Started

- Select File | New | Project
- Select Visual C# | Windows Desktop and choose Console Application (NOTE: Make sure the .NET Framework 4.5.1 is selected)
- Make sure the Create directory for solution checkbox is checked
- Name the Project `MyFirstConsoleApp` and click on the OK Button

  ![create-console-app](https://cloud.githubusercontent.com/assets/8953261/16710334/dd658374-45e7-11e6-8371-90bc7af5962f.png)

- Type in the following code:

  ```csharp
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using System.Threading.Tasks;
  
  namespace MyFirstConsoleApp {
    class Program {
      static void Main(string[] args) {
        // declare a string variable and assign it a value
        String sName = "Greg Anderson";
        
        // declare an integer variable
        int iCount;
        
        // create a for loop that will execute as long as the variable iCount is < 3
        for (iCount = 0; iCount < 3; iCount++) {
          // write information to the console and then add a carriage return
          Console.WriteLine(sName + " loves Fried SPAM!");
          
          // the WriteLine() prints the string to the console and wraps the cursor to the next line
        }
        
        // wait for input from the keyboard
        Console.ReadLine();
      }
    }
  }
  
  ```

- Save the project and press `F5` to run it (or click the green arrow)

## Notes

The Project code is contained within the Program.cs source code file. It contains using statements which inform the compiler which libraries need to be imported. The namespace allows you to organize code and specify scope. It is similar to a package in Java.

Within the namespace you can write multiple classes. The static void Main specifies the starting method for the application.
