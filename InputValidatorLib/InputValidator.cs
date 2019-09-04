using System;
using System.Text.RegularExpressions;
using InputValidatorContractLib;
using LoggerContractsLib;

namespace InputValidatorLib
{
    public class InputValidator : IInputValidatorContract
    {

        private ILoggerContract loggerRef;

        public ILoggerContract LoggerRef { get => loggerRef; set => loggerRef = value; }


        public InputValidator(ILoggerContract loggerRef)
        {
            this.loggerRef = loggerRef;
        }

        public bool Validate(string Input)
        {
            if (Regex.IsMatch(Input, @"^\d+$"))
            {
                return true;
            }
            else
            {
                loggerRef.Write("!!!!Choose a valid option!!!!");
                return false;
            }
        }
    }
}
