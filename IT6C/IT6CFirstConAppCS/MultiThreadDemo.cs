using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT6CFirstConAppCS
{
    internal class MultiThreadDemo
    {
        // Non-generic collection to hold jobs (objects)
        private static ArrayList jobQueue = new ArrayList();
        private static readonly object queueLock = new object();

        static void Main1()
        {
            Console.WriteLine("Spooler service started...");

            // Create multiple worker threads (Users)
            Thread user1 = new Thread(AddPrintJob);
            Thread user2 = new Thread(AddPrintJob);

            user1.Start("Report.pdf");
            user2.Start("Invoice.docx");

            // Wait for users to finish sending jobs
            user1.Join();
            user2.Join();

            ProcessJobs();
            Console.WriteLine("All jobs complete.");
        }

        static void AddPrintJob(object fileName)
        {
            // lock ensures only one thread adds to the ArrayList at a time
            lock (queueLock)
            {
                jobQueue.Add(fileName);
                Console.WriteLine($"[User] Added to queue: {fileName}");
            }
            Thread.Sleep(500); // Simulate network delay
        }

        static void ProcessJobs()
        {
            Console.WriteLine("\nProcessing Spooler Queue:");
            lock (queueLock)
            {
                foreach (object job in jobQueue)
                {
                    Console.WriteLine($"[Printer] Printing: {job}");
                    Thread.Sleep(1000); // Simulate printing time
                }
                jobQueue.Clear();
            }
        }
    }
}
