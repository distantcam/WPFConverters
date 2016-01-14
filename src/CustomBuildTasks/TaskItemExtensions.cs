using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.Build.Framework;

public static class TaskItemExtensions
{
    [DebuggerStepThrough]
    public static string FullPath(this ITaskItem item) => item.GetMetadata("FullPath");

    [DebuggerStepThrough]
    public static string RootDir(this ITaskItem item) => item.GetMetadata("RootDir");

    [DebuggerStepThrough]
    public static string Filename(this ITaskItem item) => item.GetMetadata("Filename");

    [DebuggerStepThrough]
    public static string Extension(this ITaskItem item) => item.GetMetadata("Extension");

    [DebuggerStepThrough]
    public static string Directory(this ITaskItem item) => item.GetMetadata("Directory");
}
