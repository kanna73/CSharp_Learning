namespace Task_async_await
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Main Thread ID: {Thread.CurrentThread.ManagedThreadId}");
            method1();
            method2 ();
            Console.WriteLine("Enter the data");
            string data = Console.ReadLine();
            Console.WriteLine(data);
            Console.ReadLine();
            Console.WriteLine($"Main Thread ID: {Thread.CurrentThread.ManagedThreadId}");


        }

        private static  Task<int> method1()
        {
/*            await Task.Delay(5000);
*/            Console.WriteLine($"async Thread ID: {Thread.CurrentThread.ManagedThreadId}");

            Console.WriteLine("work 1 is happening");
            return 5;
        }
        private static async  void method2()
        {
            await Task.Delay(5000);
            Console.WriteLine($"async Thread ID: {Thread.CurrentThread.ManagedThreadId}");

            Console.WriteLine("work 2 is happening");
        }

    }
}
