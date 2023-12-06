﻿using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using WinRTServer;

unsafe
{
    PInvoke.RoInitialize(PInvoke.RO_INIT_TYPE.RO_INIT_MULTITHREADED);

    if (PInvoke.WindowsCreateString("WinRTServer.TestClass", (uint)"WinRTServer.TestClass".Length, out var classId) != 0)
    {
        Console.WriteLine("Failed to create string.");
    }

    if (PInvoke.RoRegisterActivationFactories([classId], [InternalModule.GetActivationFactory], out var cookie) != 0)
    {
        Console.WriteLine("Failed to register activation factories.");
    }

    Console.WriteLine("Waiting for class activation. Press any key to exit the server.");
    Console.ReadLine();
}

internal partial class PInvoke
{
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    internal unsafe delegate int PfnActivationFactoryCallback(void* classId, void** activationFactory);

    internal static unsafe int RoRegisterActivationFactories(void*[] activatableClassIds, PfnActivationFactoryCallback[] activationFactoryCallbacks, out nint cookie)
    {
        fixed (nint* cookieLocal = &cookie)
        {
            fixed (void* activatableClassIdsLocal = activatableClassIds)
            {
                if (activatableClassIds.Length != activationFactoryCallbacks.Length) throw new ArgumentException();
                int result = RoRegisterActivationFactories(activatableClassIdsLocal, activationFactoryCallbacks, (uint)activationFactoryCallbacks.Length, cookieLocal);
                return result;
            }
        }
    }

    [LibraryImport("api-ms-win-core-winrt-l1-1-0.dll")]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    internal static unsafe partial int RoRegisterActivationFactories(void* activatableClassIds, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2), In] PfnActivationFactoryCallback[] activationFactoryCallbacks, uint count, nint* cookie);

    [LibraryImport("api-ms-win-core-winrt-l1-1-0.dll")]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    internal static partial void RoRevokeActivationFactories(nint cookie);

    internal static unsafe int WindowsCreateString(string sourceString, uint length, out void* str)
    {
        fixed (char* sourceStringLocal = sourceString)
        {
            void* strLocal;
            int result = WindowsCreateString(sourceStringLocal, length, &strLocal);
            str = strLocal;
            return result;
        }
    }

    [LibraryImport("api-ms-win-core-winrt-string-l1-1-0.dll")]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    internal static unsafe partial int WindowsCreateString(char* sourceString, uint length, void* @string);

    [LibraryImport("api-ms-win-core-winrt-string-l1-1-0.dll")]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    internal static unsafe partial int WindowsDeleteString(void* @string);

    [LibraryImport("api-ms-win-core-winrt-l1-1-0.dll")]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    internal static partial int RoInitialize(RO_INIT_TYPE initType);

    [LibraryImport("api-ms-win-core-winrt-l1-1-0.dll")]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    internal static partial void RoUninitialize();

    internal enum RO_INIT_TYPE
    {
        RO_INIT_SINGLETHREADED = 0,
        RO_INIT_MULTITHREADED = 1,
    }
}
