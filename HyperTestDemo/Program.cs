using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Reflection;
namespace HyperTestDemo
{
    class Program
    {
        public void Mayur()
        {
            Console.WriteLine("Hello World!");
            Assembly assembly = Assembly.LoadFrom("/HyperTestDemo/HyperTestDemo.dll");
            foreach (Type type in assembly.GetTypes())
            {
                foreach (MethodInfo methodInfo in type.GetMethods())
                {
                    var attributes = methodInfo.GetCustomAttributes(true);
                    foreach (var attr in attributes)
                    {
                        if (attr.ToString() == "NUnit.Framework.TestAttribute")
                        {
                            var methodName = methodInfo.Name;
                            Console.WriteLine(methodName);
                        }
                    }
                }
            }
        }
    }
}
