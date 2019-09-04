using LoggerContractsLib;
using System;

namespace ConsoleLoggerLib
{
    public class ConsoleLogger : ILoggerContract
    {
        public void Write(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}