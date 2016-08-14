using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleThreads
{
  class Program
  {
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

    static void Main(string[] args)
    {
      // Create ThreadStart objects that allow you to set what method you want
      // executed when the thread starts
      ThreadStart threadStart1 = new ThreadStart(methodA);
      ThreadStart threadStart2 = new ThreadStart(methodB);

      // Create actual thread objects
      Thread thread1 = new Thread(threadStart1);
      Thread thread2 = new Thread(threadStart2);

      // Tell the system to start the threads
      thread1.Start();
      thread2.Start();

      // tell the system to execute the thread until it completes
      thread1.Join();
      thread2.Join();

      // Pause console window
      Console.ReadLine();
    }
  }
}
