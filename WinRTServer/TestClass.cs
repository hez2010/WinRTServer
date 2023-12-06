using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;

namespace WinRTServer
{
    public sealed class TestClass
    {
        public TestClass()
        {
            Console.WriteLine("TestClass has been activated.");
        }

        public IAsyncOperation<string> HelloAsync()
        {
            Console.WriteLine("HelloAsync has been called.");
            return AsyncInfo.Run(async token =>
            {
                await Task.Delay(1000, token);
                return "Hello from server after 1 sec.";
            });
        }
    }
}
