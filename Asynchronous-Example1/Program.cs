using System;
using System.Threading.Tasks;

namespace Asynchronous_Example1
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            //Create and run asynchronous task.
            Task<int> resultTask = PerformAsynchronousOperation();

            //Do some other work while wating for the task to complete. 
            Console.WriteLine("Doing some other work..");

            //wait for the task is complete then retrieve result.
            int result = await resultTask;

            //process the result.
            Console.WriteLine($"result={result}");

            Console.ReadKey();
        }
        static async Task<int> PerformAsynchronousOperation()
        {
            //Simulate an asynchronous operation.
            await Task.Delay(1000);
            return 45;
        }

    }
}
