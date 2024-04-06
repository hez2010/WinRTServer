using Windows.Foundation;

namespace WinRTServer
{
    public sealed class TestClass
    {
        public TestClass()
        {
            Console.WriteLine("TestClass has been activated.");
        }

        public void Test()
        {
            throw new Exception("Exception from server.");
        }
    }
}
