using System;
using System.Reflection;
using System.Runtime.Versioning;

Console.WriteLine(typeof(object).Assembly.GetCustomAttribute<TargetFrameworkAttribute>().FrameworkDisplayName);
