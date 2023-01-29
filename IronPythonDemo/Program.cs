using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using System;

namespace IronPythonDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // 创建python解释器
            var engine = Python.CreateEngine();

            SetSearchFile(ref engine);

            // 加载脚本文件
            dynamic py = engine.ExecuteFile(@"PythonScripts/main.py");

            // 调用Python脚本的Test函数
            Console.WriteLine("Test:");
            var data = py.Test();
            Console.WriteLine(data);

            Console.WriteLine();

            // 查看IronPython的Python版本及使用的.NET版本
            Console.WriteLine("Python & .NET Version:");
            var version = py.SysVersion();
            Console.WriteLine(version);

            Console.WriteLine();

            // 使用Python的UUID标准库生成基于时间戳的UUID
            Console.WriteLine("Create UUID By Python:");
            var uuid = py.CreateUUID();
            Console.WriteLine(uuid.ToString());

            Console.WriteLine();

            // 调用requests库
            Console.WriteLine("Use Requests:");
            var resp = py.GetReqTest();
            Console.WriteLine(resp);

            Console.ReadKey();
        }

        /// <summary>
        /// 配置python第三方库路径
        /// </summary>
        /// <param name="engine"></param>
        private static void SetSearchFile(ref ScriptEngine engine)
        {
            var paths = engine.GetSearchPaths();
            paths.Add(@"PythonScripts\Lib");
            paths.Add(@"PythonScripts\Lib\site-packages");
            engine.SetSearchPaths(paths);
        }
    }
}
