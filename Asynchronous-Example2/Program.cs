using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Asynchronous_Example2
{
    internal class Program
    {
        public static async Task DownloadAndPrintAsync(string url)
        {
            string content;
            using (WebClient webClient = new WebClient())
            {
                await Task.Delay(100);
                content = webClient.DownloadDataTaskAsync(url);

            }
            Console.WriteLine($"{url}: {content.Length} download characters");
        }
        static void Main(string[] args)
        {

            Thread thread1 = new Thread(() => DownloadAndPrintAsync("https://programmingadvices.com/"));
            thread1.Start();
            Console.WriteLine("Thread1 is start...");

            Thread thread2 = new Thread(() => DownloadAndPrintAsync("https://www.typing.com/student"));
            thread2.Start();
            Console.WriteLine("Thread2 is start...");


            Thread thread3 = new Thread(() => DownloadAndPrintAsync("https://svuis.svuonline.org/SVUIS/index.php"));
            thread3.Start();
            Console.WriteLine("Thread3 is start...");

            thread1.Join();
            thread2.Join();
            thread3.Join();

            Console.WriteLine("All of threads are done... ");
            Console.ReadKey();

        }
    }
}
