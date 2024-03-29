﻿using System;
using WinRTServer;

Console.WriteLine("This is client.");

Console.WriteLine("Activating the class...");

var obj = new TestClass();

Console.WriteLine("Calling into the class...");

var result = await obj.HelloAsync((x, y) =>
{
    Console.WriteLine($"Calculating {x} * {y}");
    return x * y;
}, 24, 35);

Console.WriteLine($"Get message \"{result.Message}\" after Task.Delay({result.Duration.TotalMilliseconds})");

Console.WriteLine(CalcClass.Add(12, 34));

Console.ReadLine();
