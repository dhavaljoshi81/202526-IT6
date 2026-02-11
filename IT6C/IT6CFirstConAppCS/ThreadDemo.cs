using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT6CFirstConAppCS
{
    internal class ThreadDemo
    {
        
        static void Main()
        {
            Console.WriteLine("Main thread started.");

            // Create a new Thread instance, passing the method to execute
            Thread newThread = new Thread(new ThreadStart(PrintNumbers));

            // Start the thread
            newThread.Start();

            // The main thread continues its execution
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("Main thread working...");
                Thread.Sleep(50); // Simulate some main thread work
            }

            // Wait for the new thread to complete
            newThread.Join();
            Console.WriteLine("Main thread finished.");
        }

        static void PrintNumbers()
        {
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine($"New thread is printing {i}");
                Thread.Sleep(10); // Simulate some work
            }
        }
    }
}
