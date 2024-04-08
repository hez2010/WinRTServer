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

        public void Test([ReadOnlyArray] int[] array)
        {

        }
    }
}
