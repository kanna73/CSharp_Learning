namespace Task_async_await
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Main thread is executing.");

           /* // Start an asynchronous task
            Task ioBoundTask = DoAsyncIOBoundWork();

            // Simulate additional user input while waiting for the async task
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine($"Main thread: User input {i}");
                await Task.Delay(1000); // Simulate user input delay
            }

            await ioBoundTask; // Wait for the asynchronous task to complete

            Console.WriteLine("Main thread completed.");*/

            DoSyncIOBoundWork();

            // Simulate additional user input (Note: This will be processed after the synchronous task)
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine($"Main thread: User input {i}");
                System.Threading.Thread.Sleep(1000); // Simulate user input delay
            }

            Console.WriteLine("Main thread completed.");
        }
        static async Task DoAsyncIOBoundWork()
        {
            Console.WriteLine("Async I/O-bound work started.");

            // Simulate an I/O-bound operation by making an HTTP request
            using (var httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.GetAsync("https://www.example.com");
                string content = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Content length: " + content.Length);

            }

            Console.WriteLine("Async I/O-bound work completed.");
        }

        static void DoSyncIOBoundWork()
        {
            Console.WriteLine("Sync I/O-bound work started.");

            // Simulate an I/O-bound operation by making an HTTP request synchronously
            using (var httpClient = new HttpClient())
            {
                HttpResponseMessage response = httpClient.GetAsync("https://www.example.com").Result;
                string content = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine("Content length: " + content.Length);

            }

            Console.WriteLine("Sync I/O-bound work completed.");
        }
    }
}
