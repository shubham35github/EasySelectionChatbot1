using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerContractsLib
{
    public interface ILoggerContract
    {
        void Write(string msg);
    }
}
