using System;
using InputReaderContractsLib;
using InputValidatorContractLib;

namespace ConsoleInputReaderLib
{
    public class ConsoleInputReader : IInputReaderContract
    {
        private IInputValidatorContract validatorRef;

        public IInputValidatorContract ValidatorRef { get => validatorRef; set => validatorRef = value; }

        public ConsoleInputReader(IInputValidatorContract validatorRef)
        {
            this.validatorRef = validatorRef;
        }
        public int ReadInput()
        {
            while (true)
            {
                string Input = Console.ReadLine();
                if (validatorRef.Validate(Input))
                {
                    return Int32.Parse(Input);
                }
            }

        }


    }
}