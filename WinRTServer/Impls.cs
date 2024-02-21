using Windows.Foundation;

namespace WinRTServer
{
    public struct HelloStruct
    {
        public string Message;
        public TimeSpan Duration;
    }

    public delegate int BinaryDelegate(int x, int y);

    public sealed class CalcClass
    {
        public static int Add(int x, int y)
        {
            Console.WriteLine($"Calculating {x} + {y}");
            return x + y;
        }
    }

    public sealed class TestClass
    {
        public TestClass()
        {
            Console.WriteLine("TestClass has been activated.");
        }

        public IAsyncOperation<HelloStruct> HelloAsync(BinaryDelegate func, int x, int y)
        {
            Console.WriteLine("HelloAsync has been called.");
            Console.WriteLine($"Calling into the client, result = {func(x, y)}");

            async Task<HelloStruct> HelloAsyncCore(BinaryDelegate func, int x, int y)
            {
                await Task.Delay(1000);
                return new HelloStruct
                {
                    Message = "Hello from server",
                    Duration = TimeSpan.FromSeconds(1)
                };
            }

            return HelloAsyncCore(func, x, y).AsAsyncOperation();
        }
    }
}
