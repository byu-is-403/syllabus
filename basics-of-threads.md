<h1>Basics of Threads C#</h1>

## Contents

1. What are Threads
2. Threads in Action
3. Life Cycle of Threads
4. Thread Code
5. Other Resources


## What are Threads?

- Every application uses at least one thread
- A thread is a process moving through time
- They can improve performance but at the same time, misused, can hinder performance
- They should be used to separate computations to separate logical processors
- In a GUI C# app, the UI thread is created automatically and used by the application when executed
- Attempts to access form controls from threads other than the UI thread will cause a cross-thread exception
- All of the UI operations are queued in that thread
- Every command executed in the Main method is executed in the primary or UI thread and this thread ends when Main ends
- Multi-threading is the use of more than one thread and can help increase responsiveness but also increase the chance for a deadlock
- Thread execution is scheduled by the operating system
- There is no guarantee that multiple threads are split into multiple processors
- In one system with a single processor, multiple threads get to take a "turn"
- On a multi processor system, it is hoped that the operating system assigns different threads to different processors
- However, multi-processing has a downside of complexity (scheduling, sharing of resources, timing, etc.)
- The System.Threading namespace provides different thread types (for example, a Timer object is really a thread)


## Using Threads

1. Include the `System.Threading` namespace
2. Create your threads
3. Start the threads
4. Join the threads

  ```csharp
  {
    thread.start();
    
    // ... stuff you want to do while the other thread is busy doing its own thing concurrently
    
    thread.join();
    
    // ... you won't get here until thread has terminated.
  } 
  ```
5. Write the methods called by the Thread constructor and are executed during the running of the thread


## Life Cycle of Threads

![thread-lifecycle](https://cloud.githubusercontent.com/assets/8953261/16710714/0ddadee2-45f6-11e6-9a41-6862eb6762e3.png)

- **Un-started State**: the thread is created but has not been started
- **Ready State (Running)**: thread is ready to run and waiting for the CPU cycle
- **Not Runnable State (Wait, Sleep, Join)**: the thread is not executable because the Sleep or Wait methods have been called or it is (Blocked) being blocked by other I/O operations
- **Dead State(Stopped)**: thread execution is aborted or has been completed
- **Suspend**: Paused by program and waiting for command to resume


## Thread Methods and Code

- **Start**: starts the thread
- **Abort**: begins the process of terminating the thread
- **Join**: blocks the calling thread until a thread terminates or enables us to wait until a thread completes
- **Sleep**: causes the thread to wait a specified number of milliseconds
- **Yield**: causes a thread to yield execution to another thread that is ready to run on the current processor (controlled by the operating system)

```csharp
using System.Threading;
using System.Threading.Tasks; // Provides access to the Thread class


Thread thread1 = new Thread(new ThreadStart(A)); // Creates a new thread object called thread1 and tells the system that when it starts it will use the A method found in the source code

thread1.Start(); // Starts the execution of the thread and in this case will call the A method

thread1.Join(); // Run the thread until it has completed but still run other processes also

static void thread1Starter() {
  for (int iCount = 0; iCount < 100; iCount++) {
      Console.WriteLine("A " + Convert.ToString(iCount));
  }
}

// This is the method that the thread will keep executing

```

## Using Multi-Threads

- Do not use them just because they are cool!
- Do not use them to make things “faster” until you have proven that a single thread implementation is slow
- If not done correctly, multi-threading can cause problems (app freezes, resources exhaust, etc…) which makes it hard to debug


- You MAY want to multi-thread if a particular piece of code takes a long time to complete
- You MAY want to multi-thread if you can run code parallel
- You MAY want to multi-thread if you are waiting a long time for File I/O to complete or respond


- Core = hardware. Correct.
- Thread = how the hardware is supplied with information. Think of it as the 'road' by which the information gets into the CPU core. 
- Some processors, like the i7-2600K, have hyper-threading. This is where each core can take 2 threads. In layman's terms, although the CPU has 4 physical cores, it allows the CPU to act as if it had 8 cores. Generally only useful for high-intensity program that do modelling or video-editing work. Cores don’t share memory because they have their own dedicated memory 1 core 1 thread, so the processing time is still faster than the 4cores with 4 threads, than the dual cores with 4 threads.


## Other Resources

- http://www.dotnetperls.com/thread
- http://www.tutorialspoint.com/csharp/csharp_multithreading.htm
- http://www.dotnetperls.com/thread-join
- https://msdn.microsoft.com/en-us/library/5xt1dysy(v=vs.80).aspx







