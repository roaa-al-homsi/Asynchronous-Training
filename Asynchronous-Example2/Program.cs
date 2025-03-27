using System;
using System.Net;
using System.Threading.Tasks;

namespace Asynchronous_Example2
{
    internal class Program
    {
        public static async Task DownloadAndPrintAsync(string url)
        {
            //using statement ensure that the web client is disposed of properly. 
            string content;
            using (WebClient webClient = new WebClient())
            {
                //simulate some work by adding a delay..
                await Task.Delay(100);
                //Download content of the web page as asynchronous..
                content = await webClient.DownloadStringTaskAsync(url);

            }
            Console.WriteLine($"{url}: {content.Length} download characters");
        }
        public static async Task Main(string[] args)
        {

            Task task1 = DownloadAndPrintAsync("https://www.typing.com/student");
            Console.WriteLine("Task1 is start...");

            Task task2 = DownloadAndPrintAsync("https://svuis.svuonline.org/SVUIS/index.php");
            Console.WriteLine("Task2 is start...");

            //Wait for all tasks to complete.
            await Task.WhenAll(task1, task2);

            Console.WriteLine("All of tasks are done... ");
            Console.ReadKey();

        }
    }
}
