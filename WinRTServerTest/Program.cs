using System;
using WinRTServer;

Console.WriteLine("This is client.");

Console.WriteLine("Activating the class...");

var obj = new TestClass();

Console.WriteLine("Calling into the class...");

try
{
    obj.Test();
}
catch (Exception e)
{
    Console.WriteLine(e);
}

Console.ReadLine();
