Console.WriteLine("Main Thread: Starting the demo.");

// 1. Creation: Defining two threads and the methods they will run
Thread thread1 = new Thread(WriteX);
Thread thread2 = new Thread(WriteY);

// 2. Setting Priority (Optional but good for demo)
thread1.Priority = ThreadPriority.Lowest;
thread2.Priority = ThreadPriority.Highest;

// 3. Start: Moving threads from 'Unstarted' to 'Running' state
Console.WriteLine("Main Thread: Starting Worker Threads...");
thread1.Start();
thread2.Start();

// 4. Main Thread Activity: Demonstrating that Main isn't blocked
for (int i = 0; i < 5; i++)
{
    Console.WriteLine(" --> Main Thread is doing its own work.");
    Thread.Sleep(50); // Small delay
}

// 5. Join: Main thread waits for the workers to finish before closing
Console.WriteLine("Main Thread: Waiting for workers to finish (Joining)...");
thread1.Join();
thread2.Join();

Console.WriteLine("Demo Complete. Press any key to exit.");
Console.ReadKey();

static void WriteX()
{
    for (int i = 0; i < 50; i++)
    {
        Console.Write("X");
        // 6. Sleep: Thread voluntarily pauses, letting others work
        Thread.Sleep(10);
    }
}

// Task for Thread 2
static void WriteY()
{
    for (int i = 0; i < 50; i++)
    {
        Console.Write("Y");
        Thread.Sleep(10);
    }
}