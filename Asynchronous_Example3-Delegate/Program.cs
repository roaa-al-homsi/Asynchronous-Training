using System;
using System.Threading.Tasks;

namespace Asynchronous_Example3_Delegate
{
    internal class Program
    {
        public class CustomEventArgs : EventArgs
        {
            public int parameter1 { get; }
            public string parameter2 { get; }

            public CustomEventArgs(int parameter1, string parameter2)
            {
                this.parameter1 = parameter1;
                this.parameter2 = parameter2;
            }
        }

        public static event EventHandler<CustomEventArgs> CustomEventHandler;
        public static void PrintMessage(object sender, CustomEventArgs e)
        {
            Console.WriteLine($" parameter1:{e.parameter1} , parameter2: {e.parameter2}");
        }

        static async Task PerformAsyncOperation()
        {
            await Task.Delay(1000);

            CustomEventHandler.Invoke(null, new CustomEventArgs(1, "HI"));
        }
        static async Task Main(string[] args)
        {
            CustomEventHandler += PrintMessage;
            Task task1 = PerformAsyncOperation();

            Console.WriteLine("Doing some other work..");

            await task1;
            Console.WriteLine("Done ....");
            Console.ReadKey();
        }
    }
}
