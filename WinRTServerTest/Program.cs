using System;
using WinRTServer;


Console.WriteLine("Activating the class...");

var obj = new TestClass();

Console.WriteLine("Calling into the class...");

Console.WriteLine(await obj.HelloAsync());

Console.ReadLine();